using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName = "IngredientCatalogue", menuName = "Pizooria/IngredientCatalogue")]
public class IngredientCatalogue : ScriptableObject
{
    public IngredientObject[] Ingredients;
    private static IngredientCatalogue _instance;

    public static IngredientCatalogue instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = Resources.Load<IngredientCatalogue>("IngredientCatalogue");
            }
            return _instance;
        }
    }

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

    // returns null if doesn't exist
    public bool Exists(System.Func<IngredientObject, bool> pred) => Ingredients.Any(pred);
}
