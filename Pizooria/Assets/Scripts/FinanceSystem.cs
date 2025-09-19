using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinanceSystem : MonoBehaviour
{
    public ButtonSystem Target;
    public TextMeshProUGUI text;
    static public int coins = 100;
    
    private void Start()
    {
        Target.OnItemBought += ChangeText;
        ChangeText();
    }
    public void ChangeText()
    {
        text.text = $"Coins:{coins}";

    }
}