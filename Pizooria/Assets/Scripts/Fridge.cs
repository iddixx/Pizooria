using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    public List<FridgeSlot> slots = new List<FridgeSlot>();

    public FridgeDrag drag;
    public void SetDrag(FridgeSlot oldslot,Sprite sprite,int count,uint maxstack, string name)
    {
        drag.image.sprite = sprite;
        drag.nameText.text = name;
        drag.countText.text = count.ToString();
        drag.count = count;
        drag.maxStack = maxstack;
    }
    public void AddItemToFridge(IngredientObject Item)
    {
        for (int i = 0;i < slots.Count; i++)
        {
            if (slots[i].AddItemtoSlot(Item,1)) 
            {
                break;
            }
        }
    }

}
