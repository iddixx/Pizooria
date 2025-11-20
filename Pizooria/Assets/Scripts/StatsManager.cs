using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public GameOverManager GameOverManager;
    
    public int GavePizzas;
    
    public void GivePizza()
    {
        GavePizzas++;
    }

    public void EndGame()
    {
        GameOverManager.Clear();
        GameOverManager.AddInfo(new GameOverPizzasInfo(GavePizzas));
        GameOverManager.ShowGameOverScreen();
    }
}