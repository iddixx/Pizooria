using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PizzaBaker : MonoBehaviour
{
    public static PizzaBaker Instance { get; private set; }
    public int SimultaneouslyBakingLimit = 4;
    private List<Pizza> _baking_pizzas; 

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnBeforeSceneLoad()
    {
        if (FindObjectOfType<PizzaBaker>() == null)
        {
            GameObject self = new GameObject("PizzaBaker");
            Instance = self.AddComponent<PizzaBaker>();
            Instance._baking_pizzas = new List<Pizza>();
            DontDestroyOnLoad(self);
        }
    }

    public bool CanStartBaking()
    {
        if((_baking_pizzas.Count + 1) > SimultaneouslyBakingLimit)
        {
            return false;
        }
        return true;
    }

    public void StartBaking(Pizza pizza)
    {
        if((_baking_pizzas.Count + 1) > SimultaneouslyBakingLimit)
        {
            throw new System.InvalidOperationException($"You can bake only {SimultaneouslyBakingLimit} pizzas at the same time");
        }
        if(!pizza.IsBaked)
        {
            throw new System.ArgumentException($"You can't bake already baked pizza");
        }
        _baking_pizzas.Add(pizza);
    }

    private void Update()
    {
        foreach(Pizza pizza in _baking_pizzas)
        {
            if(pizza.IsBaked)
            {
                BakedPizzasContainer.Instance.PushPizza(pizza);
                _baking_pizzas.Remove(pizza);
            }
        }
    }
}
