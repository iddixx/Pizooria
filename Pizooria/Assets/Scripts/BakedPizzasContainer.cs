using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakedPizzasContainer : MonoBehaviour
{
    public static BakedPizzasContainer Instance { get; private set; }
    public List<Pizza> Pizzas { get; private set; }

    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Debug.Log("Destroyed second instance of BakedPizzasContainer, because it's singleton", this);
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
            DontDestroyOnLoad(Instance.gameObject);
        } 
    }

    // throws an exception if pizza is not baked
    public void PushPizza(Pizza pizza)
    {
        if(!pizza.IsBaked)
        {
            throw new System.ArgumentException("You cannot push raw pizza");
        }
        Pizzas.Add(pizza);
    }
}
