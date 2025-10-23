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
            return new CraftUnit(craft_result, (uint)craft_result.AmmountPerCost);
        }
        return null;
    }
#nullable disable
}
