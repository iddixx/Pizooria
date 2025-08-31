using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ShopButton : MonoBehaviour
{
    public ButtonSystem Target;
    
    public IngredientObject Ingredient;
    public Color CanColor = Color.green, CannotColor = Color.red;
    public FinanceSystem Coins;
    public Image buttonImage,ingredient;
    public TextMeshProUGUI costText,ammounttext;
    private void Start()
    {
        

        Target.OnItemBought += SetColor;

        ammounttext.text = $"{Ingredient.AmmountPerCost}X";
        costText.text = $"{Ingredient.Cost}$";

        ingredient.sprite = Ingredient.SelfSprite;
        

        SetColor();
    }
    public void SetColor()
    {
        costText.color = CouldBuy() ? CanColor : CannotColor;  
    }
    public bool CouldBuy() 
    {
        return FinanceSystem.coins >= Ingredient.Cost;
    }
    
    public void Buy()
    {
        if (CouldBuy())
        {
            FinanceSystem.coins -= Ingredient.Cost;
            if (Ingredient == null)
            {
                Debug.LogError("Ingredient ist null im ShopButton!");
                return;
            }

            if (FridgeManager.Instance != null)
            {
                FridgeManager.Instance.AddItemToManager(Ingredient);
            }
            
            Target.Buy();
            Debug.Log(FinanceSystem.coins);

        }

    }
}
