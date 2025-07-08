using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FridgeSlot : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI countText, nameText;

    public Fridge fridge;

    
    public Sprite deafaultSprite;

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
        if (Fridge.IsDragGoing && isEmpty) 
        {
            IsTaking = false;
        } 
    }
    public void OnEnter()
    {
        if (Fridge.IsDragGoing && isEmpty)
        {
            IsTaking = true;
        }
    }
    public void TakeAllItems()
    {
        if (!isEmpty && !Fridge.IsDragGoing) 
        {
            
            fridge.SetDrag(this, image.sprite, slotCount, maxStack, nameText.text);
            ResetVisuals();
        } 
    }
    public void ResetVisuals()
    {
        image.sprite = deafaultSprite;
        
        countText.text = "";
        nameText.text = "";
       
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
