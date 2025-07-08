using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class FridgeSlot : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI countText, nameText;

    public Fridge fridge;

    
    public Sprite defaultSprite;
    public string defaultName;
    public string defaultCount;
    
    public int slotCount = 0;
    public uint maxStack = 0;
    
    public bool isEmpty;
    public bool IsTaking = false;
    
    private void Start()
    {
        fridge = FindObjectOfType<Fridge>();
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

            fridge.SetRightDrag(this, image.sprite,1,maxStack, nameText.text);
            UpdateText();
        }
    }
    public void TakeAllItems()
    {
        if (!isEmpty && !Fridge.IsDragGoing) 
        {
            
            fridge.SetLeftDrag(this, image.sprite, slotCount, maxStack, nameText.text);
            ResetVisuals();
        } 
    }
    public void UpdateText()
    {
        slotCount -= 1;
        
        if (slotCount <= 0)
        {
            isEmpty = true;
            ResetVisuals() ;
        }
        else
        {
            countText.text = slotCount.ToString();
        }
        
    }
    public void ResetVisuals()
    {
        image.sprite = defaultSprite;

        countText.text = defaultCount;
        nameText.text = defaultName;
       
    }

    public bool AddtoSlot(Sprite SelfSprite,string name, int count,uint MaxStack)
    {
        bool couldplace = false;
        if (isEmpty || nameText.text == name)
        {

            if (slotCount + count > MaxStack)
            {
                return false;
            }
            slotCount += count;
            maxStack = MaxStack;
            image.sprite = SelfSprite;

            nameText.text = name;
            countText.text = slotCount.ToString();
            isEmpty = false;
            couldplace = true;
        }

        return couldplace;
    }
    public bool AddItemtoSlot(IngredientObject item,int count)
    {
        bool couldplace = false;
        if (isEmpty || nameText.text == item.name)
        {
            
            if (slotCount + count > item.MaxStack )
            {
                return false;
            }
            slotCount += count;
            maxStack = item.MaxStack;
            image.sprite = item.SelfSprite;
            
            nameText.text = item.name;
            countText.text = slotCount.ToString();
            isEmpty = false; 
            couldplace = true;
        }

        return couldplace;
    }
}
