using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopButton : MonoBehaviour
{
    public ButtonSystem Target;
    public int Cost;
    
    public Color CanColor, CannotColor;
    public Coins Coins;
    public Image image;
    private void Start()
    {
        Target.OnItemBought += SetColor;   
        SetColor();
    }
    public void SetColor()
    {
        image.color = CouldBuy() ? CanColor : CannotColor;  
    }
    public bool CouldBuy() 
    {
        return Coins.coins >= Cost;
    }
    
    public void Buy()
    {
        if (CouldBuy())
        {
            Coins.coins -= Cost;
            
            Target.Buy();
            
            Debug.Log(Coins.coins);

        }

    }
}
