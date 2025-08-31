using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pizza : Ingredient
{
    public float BakingTime;
    public bool IsBaked { get; private set; }
    override protected void Start()
    {
        if(MaxStack > 1)
        {
            Debug.LogWarning($"MaxStack in Pizza can't be greater than 1, setting to 1", this);
            MaxStack = 1;
        }
        base.Start();

        if(ScriptableObject is PizzaObject pizza_so)
        {
            BakingTime = pizza_so.BakingTime;
        }
        else
        {
            throw new System.ArgumentException("Pizza expects PizzaObject, instead of IngredientObject");
        }
    }

    public IEnumerator StartBaking()
    {
        yield return new WaitForSeconds(BakingTime);
        IsBaked = true;
        PizzaObject so = ScriptableObject as PizzaObject;
        _sprite_renderer.sprite = so.BakedSprite;
    }
}
