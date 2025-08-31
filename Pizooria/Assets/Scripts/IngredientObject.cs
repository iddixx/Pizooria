using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum CraftType
{
    NOT_READY
}

[CreateAssetMenu(fileName = "IngredientObject", menuName = "Pizooria/IngredientObject")]
public class IngredientObject : ScriptableObject 
{
    public uint MaxStack = 999;
    public int Cost;
    public int AmmountPerCost; // i know that Ammount is incorrect, but everything breaks when i change it
    public Sprite SelfSprite;
    public CraftType Craft;
}

