using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPizzasInfo : IGameoverInfo
{
    public int Value;
    public GameOverPizzasInfo(int value)
    {
        Value = value;
    }
    public string GetLabel() => "Pizzas";
    public string GetValue() => Value.ToString();
    
}
