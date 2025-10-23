
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PizzaManager : MonoBehaviour
{
    public static PizzaManager Instance { get; private set; }
    
    public IngredientCatalogue ingredientCatalogue;
    
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public Pizza GetRandomPizza()
    {
        // IngredientObject[] allPizzaObjects = System.Array.FindAll<IngredientObject>(IngredientCatalogue.instance.Ingredients, Obj => Obj is PizzaObject);
        List<PizzaObject> allPizzaObjects = new List<PizzaObject>();

        Debug.Log(ingredientCatalogue);
        Debug.Log(ingredientCatalogue.Ingredients);
        foreach(IngredientObject obj in ingredientCatalogue.Ingredients)
        {

            if(obj is PizzaObject)
            {
                allPizzaObjects.Add(obj as PizzaObject);
            }
        }

        if (allPizzaObjects.Count == 0) return null;

        PizzaObject randomPizzaObject = allPizzaObjects[Random.Range(0, allPizzaObjects.Count)] as PizzaObject;

        Pizza randomPizza = new Pizza(randomPizzaObject);
        randomPizza.bakingEndTime = Time.time + 1f;
        return randomPizza;
    }
}