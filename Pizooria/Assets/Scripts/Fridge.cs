using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Fridge : MonoBehaviour
{
    public static bool IsDragGoing = false;

    public FridgeManager manager; 
    public List<FridgeSlot> slots = new List<FridgeSlot>();

    private void Start()
    {
        if (manager == null)
            manager = FindObjectOfType<FridgeManager>();
        
        foreach (var slot in slots)
        {
            slot.UpdateUI();
        }

        
        foreach (var item in manager.BuyedIngredients)
        {
            AddItemToFridge(item,(uint)item.AmmountPerCost);
        }
    }

    public void AddItemToFridge(IngredientObject obj, uint amount = 1)
    {
        uint remaining = amount;
        
        foreach (var slot in slots)
        {
            if (slot.ingredient != null && slot.ingredient.ScriptableObject == obj)
            {
                remaining = slot.AddItems(obj, remaining);
                if (remaining == 0) return; 
            }
        }

        
        foreach (var slot in slots)
        {
            if (slot.isEmpty)
            {
                remaining = slot.AddItems(obj, remaining);
                if (remaining == 0) return; 
            }
        }

        if (remaining > 0)
        {
            Debug.LogWarning($"Nicht genug Platz für {remaining} Stück von {obj.name}");
        }
    }
}