using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pizza : Ingredient
{
    public float BakingTime;
    override protected void Start()
    {
        if(OptScriptableObject is PizzaObject pizza_so)
        {
            base.Start();
            BakingTime = pizza_so.BakingTime;
        }
        else
        {
            throw new System.ArgumentException("Pizza expects PizzaObject, instead of IngredientObject");
        }

    }
}
