using System;
using System.Linq;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Transform Container;
    public ShopButton Prefab;
    public ButtonSystem ButtonSystem;

    private void Awake()
    {
        foreach (var ingredient in IngredientCatalogue.instance.Ingredients.Where(m => m.Cost > 0))
        {
            ShopButton button = Instantiate(Prefab, Container);
            button.Ingredient = ingredient;
            button.Target = ButtonSystem;
            button.Init(); 
        }
    }
}