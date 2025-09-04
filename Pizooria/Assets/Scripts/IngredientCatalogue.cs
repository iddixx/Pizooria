using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "IngredientCatalogue", menuName = "Pizooria/IngredientCatalogue")]
public class IngredientCatalogue : ScriptableSingleton<IngredientCatalogue>
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

    // returns null if not found
#nullable enable
    public IngredientObject? Find(System.Func<IngredientObject, bool> pred) => Ingredients.FirstOrDefault(pred);
#nullable disable
}
