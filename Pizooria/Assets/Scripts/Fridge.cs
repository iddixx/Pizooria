using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Progress;

public class Fridge : MonoBehaviour
{
    public List<FridgeSlot> slots = new List<FridgeSlot>();

    public FridgeSlot slotTaking;
    public FridgeDrag drag;
    public static bool IsDragGoing = false;
    public void SetRightDrag(FridgeSlot oldslot, Sprite sprite, int count, uint maxstack, string name)
    {
        drag.oldSlot = oldslot;

        drag.image.sprite = sprite;

        drag.nameText.text = name;
        drag.countText.text = "1";
        drag.count = count;

        drag.maxStack = maxstack;
        drag.IsLeftClick = false;
        IsDragGoing = true;
    }
    public void SetLeftDrag(FridgeSlot oldslot,Sprite sprite,int count,uint maxstack, string name)
    {
        drag.oldSlot = oldslot;

        drag.image.sprite = sprite;
        
        drag.nameText.text = name;
        drag.countText.text = count.ToString();
        
        drag.count = count;
        drag.maxStack = maxstack;
        drag.IsLeftClick = true ;
        IsDragGoing = true;
    }
    public bool IsASlotTaking()
    {
        bool isTaking = false;
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].IsTaking)
            {
                slotTaking = slots[i];
                
                return true;
            }
        }
        return isTaking;
    }
    public void AddItemToFridge(IngredientObject Item)
    {
        for (int i = 0;i < slots.Count; i++)
        {
            if (slots[i].AddItemtoSlot(Item,100)) 
            {
                break;
            }
        }
    }

}
