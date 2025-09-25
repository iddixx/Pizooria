using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class FridgeSlot : MonoBehaviour
{
    public Image spriteRenderer;
    public TextMeshProUGUI countText, nameText;
    public Ingredient Ingredient;
    public Fridge fridge;

    
    public Sprite defaultSprite;
    public string defaultName;
    public string defaultCount;
    
    
    
    public bool isEmpty;
    public bool IsTaking = false;
    
    private void Start()
    {
        fridge = FindObjectOfType<Fridge>();
    }
    
    public Ingredient GetIngredient()
    {
        return Ingredient;
    }
    public void OnExit()
    {
        if (Fridge.IsDragGoing) 
        {
            IsTaking = false;
        }
        
    }
    public void OnEnter()
    {
        if (Fridge.IsDragGoing)
        {
            IsTaking = true;
        }
        
    }
    public void TakeOneItem()
    {
        if (!isEmpty && !Fridge.IsDragGoing)
        {

            fridge.SetRightDrag(this, 1,Ingredient.ScriptableObject);
            UpdateText();
        }
    }
    public void TakeAllItems()
    {
        if (!isEmpty && !Fridge.IsDragGoing) 
        {
            
            fridge.SetLeftDrag(this, Ingredient.StackCount, Ingredient.ScriptableObject);
            ResetVisuals();
        } 
    }
    public void UpdateText()
    {
        Ingredient.StackCount -= 1;
        
        if (Ingredient.StackCount <= 0)
        {
            isEmpty = true;
            ResetVisuals() ;
        }
        else
        {
            countText.text = Ingredient.StackCount.ToString();
        }
        
    }
    public void ResetVisuals()
    {
        spriteRenderer.sprite = defaultSprite;

        countText.text = defaultCount;
        nameText.text = defaultName;
       
    }

    public bool AddtoSlot(uint count,IngredientObject Object)
    {
        if(Ingredient == null)
        {
            Ingredient = new Ingredient(Object);
        }
        bool couldplace = false;
        if (isEmpty || Ingredient.ScriptableObject == Object)
        {
            // Ingredient.ScriptableObject = Object;
            // Ingredient.UpdateValues();
            if (Ingredient.StackCount + count > Object.MaxStack)
            {
                return false;
            }
            Ingredient.StackCount += count;
            // Ingredient.MaxStack = Object.MaxStack;
            spriteRenderer.sprite = Object.SelfSprite;

            nameText.text = Object.name;
            countText.text = Ingredient.StackCount.ToString();
            isEmpty = false;
            couldplace = true;
        }

        return couldplace;
    }
    public bool AddItemtoSlot(IngredientObject Object,int count)
    {
        bool couldplace = false;
        if (isEmpty || nameText.text == Object.name)
        {
            // Ingredient.ScriptableObject = Object;
            // Ingredient.UpdateValues();
            if(Ingredient == null)
            {
                Ingredient = new Ingredient(Object);
            }

            if (Ingredient.StackCount + count > Object.MaxStack )
            {
                
                return false;
            }
            Ingredient.StackCount += (uint)count;
            // Ingredient.MaxStack = Object.MaxStack;
            Debug.Log($"is null {spriteRenderer == null}");
            spriteRenderer.sprite = Object.SelfSprite;
            
            nameText.text = Object.name;
            countText.text = Ingredient.StackCount.ToString();
            isEmpty = false; 
            couldplace = true;
        }

        return couldplace;
    }
}
