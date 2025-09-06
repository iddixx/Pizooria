using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CraftUnit
{
    public IngredientObject Ingredient;
    public uint Count;
    public CraftUnit(IngredientObject ingredient, uint count)
    {
        if(count == 0) throw new System.ArgumentException("You shouldn't assign 0 to Count in CraftUnit");
        Ingredient = ingredient;
        Count = count;
    }
}

[CreateAssetMenu(fileName = "IngredientObject", menuName = "Pizooria/IngredientObject")]
public class IngredientObject : ScriptableObject 
{
    public uint MaxStack = 999;
    public int Cost;
    public int AmmountPerCost; // i know that Ammount is incorrect, but everything breaks when i change it
    public Sprite SelfSprite;
    public CraftUnit[] Craft = System.Array.Empty<CraftUnit>();
}

