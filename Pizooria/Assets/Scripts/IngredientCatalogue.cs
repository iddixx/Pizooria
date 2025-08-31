using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredientCatalogue", menuName = "Pizooria/IngredientCatalogue")]
public class IngredientCatalogue : ScriptableObject
{
    public IngredientObject[] Ingredients;

    public IngredientObject GetByID(uint id)
    {
        if(id >= Ingredients.Length)
            throw new System.ArgumentException($"Ingredient with id {id} does not exist");

        return Ingredients[(int)id];
    }
    
    // returns -1 if there is no such object in catalogue
    public int GetIDByIngredientObject(IngredientObject obj)
    {
        return System.Array.IndexOf(Ingredients, obj);
    }
}
