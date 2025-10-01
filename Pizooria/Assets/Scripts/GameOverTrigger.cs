using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    public int Pizzas;
    public GameOverManager Manager;
    public void Trigger()
    {
        Manager.AddInfo(new DaysPlayedInfo(1));
        Manager.AddInfo(new GameOverPizzasInfo(Pizzas));
        
        Manager.ShowGameOverScreen();
    }
}
