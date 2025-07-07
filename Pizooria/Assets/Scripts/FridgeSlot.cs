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

    public int slotCount = 0;
    public uint maxStack = 0;
    public bool isEmpty;

    private void Start()
    {
        fridge = FindObjectOfType<Fridge>();
    }
    public void TakeItem()
    {
        fridge.SetDrag(this,image.sprite,slotCount,maxStack,nameText.text);
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
            image.sprite = item.SelfSprite;
            
            nameText.text = item.name;
            countText.text = slotCount.ToString();
            isEmpty = false; 
            couldplace = true;
        }

        return couldplace;
    }
}
