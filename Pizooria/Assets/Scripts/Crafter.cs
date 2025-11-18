using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

static public class Crafter 
{
    static public bool CraftEquals(CraftUnit[] rhs, CraftUnit[] lhs)
    {
        if(rhs.Length != lhs.Length) return false;
        for(int i = 0; i < rhs.Length; ++i)
        {
            if(!lhs.Contains(rhs[i])) return false;
        }
        return true;
    }


#nullable enable
    // returns null if there's no craft
    static public CraftUnit? Craft(CraftUnit[] craft)
    {
        if((craft.Length == 0) || (craft == null)) return null;

        IngredientObject? craft_result = IngredientCatalogue.instance.Find(obj => CraftEquals(craft, obj.Craft));
        if(craft_result != null)
        {
            return new CraftUnit(craft_result, craft_result.AmmountPerCost);
        }
        return null;
    }
#nullable disable
    // checks in FridgeManager, does player have nececcary ingredients to craft obj 
    static public bool CanCraft(IngredientObject obj)
    {
        if((obj.Craft.Length == 0) || (obj.Craft == null)) return false;
        if(FridgeManager.Instance.BuyedIngredients == null) return false;
        if(FridgeManager.Instance.BuyedIngredients.Count == 0) return false;

        foreach(CraftUnit craft_unit in obj.Craft)
        {
            bool found_any = false;
            foreach(CraftUnit inv_unit in FridgeManager.Instance.BuyedIngredients)
            {
                if(inv_unit.Ingredient == craft_unit.Ingredient)
                {
                    if(inv_unit.Count < craft_unit.Count) return false;
                    found_any = true;
                }
            }
            if(!found_any) return false;
        }

        return true;
    }
    
    static public bool TryFridgeCraft(IngredientObject obj)
    {
        if(!CanCraft(obj)) return false;

        Crafter.UnsafeFridgeCraft(obj);
        return true;
    }

    // USE TryFridgeCraft INSTEAD, UNLESS YOU REALLY KNOW WHAT ARE YOU DOING 
    static public void UnsafeFridgeCraft(IngredientObject obj)
    {
       foreach(CraftUnit craft_unit in obj.Craft)
       {
           Debug.Log($"Decreasing {craft_unit.Ingredient.name}");
           Debug.Log($"{craft_unit.Ingredient.name} count is {craft_unit.Count}");
           FridgeManager.Instance.DecreaseCountFromManager(craft_unit.Ingredient, craft_unit.Count);

       }
       FridgeManager.Instance.AddItemToManager(obj);
    }
}
