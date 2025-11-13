using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BakedPizzasContainer : MonoBehaviour
{
    public static BakedPizzasContainer Instance { get; private set; }
    public List<Pizza> Pizzas { get; private set; }

    // you should handle pizza removal yourself
    public UnityEvent OnPizzaPushed = new();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnBeforeSceneLoad()
    {
        if (FindObjectOfType<BakedPizzasContainer>() == null)
        {
            GameObject self = new GameObject("BakedPizzasContainer");
            Instance = self.AddComponent<BakedPizzasContainer>();
            Instance.Pizzas = new List<Pizza>();
            DontDestroyOnLoad(self);
        }
    }

    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Debug.LogWarning("Destroyed second instance of BakedPizzasContainer, because it's singleton", this);
            Destroy(this); 
        } 
        else 
        { 
            Instance = this;
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
        OnPizzaPushed?.Invoke();
    }
    
    public void RemovePizza(Pizza pizza)
    {
        Pizzas.Remove(pizza);
        OnPizzaPushed?.Invoke();
    }
}
