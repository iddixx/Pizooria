using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinanceSystem : MonoBehaviour
{
    public static int coins { get; private set; } = 100;
    public static event Action OnCoinsChanged;
    
    public TextMeshProUGUI text;
    
    
    private void Start()
    {
        ChangeText();
        OnCoinsChanged += ChangeText;
    }
    
    private void OnDestroy()
    {
        OnCoinsChanged -= ChangeText;
    }

    public static void UseCoins(int amount)
    {
        coins -= amount;
        OnCoinsChanged?.Invoke();
    }
   
    public static void AddCoins(int amount)
    {
        coins += amount;
        OnCoinsChanged?.Invoke();
    }
    
    public void ChangeText()
    {
        text.text = $"Coins:{coins}";
    }
}