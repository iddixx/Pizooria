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
    public Sprite SelfSprite;
    public uint MaxStack;
    public uint Identifier;
    public CraftType Craft;
}

