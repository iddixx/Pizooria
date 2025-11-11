using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Pizza : Ingredient
{
    public float bakingEndTime = -1f;
    
    public bool IsBaked
    {
        get
        {
            PizzaObject pizza_so = ScriptableObject as PizzaObject;
            if(Time.time >= bakingEndTime) return true;
            return false;
        }
    }


    public Pizza(IngredientObject ScriptableObject) : base(ScriptableObject)
    {
        if(ScriptableObject is not PizzaObject pizza_so)
        {
            throw new System.ArgumentException("Pizza should be initialized with PizzaObject, instead of IngredientObject");
        }

        if(MaxStack > 1)
        {
            throw new System.ArgumentException("MaxStack in Pizza can't be greater than 1, setting to 1");
        }
    }

        
}
