using System;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public StatsManager StatsManager; 

    public DialogManager DialogManager;
    public Customer Customer;

    private void Start()
    {
        Customer.OnSatisfied += CustomerOnOnSatisfied;
        Customer.OnFailed += CustomerOnOnFailed;
        
        StartDay();
    }

    public void StartDay()
    {
        ShowNextCustomer();
    }

    private void CustomerOnOnFailed()
    {
        FinanceSystem.UseCoins(DialogManager.currentDialog.failValue);
        StatsManager.EndGame();
    }

    private void CustomerOnOnSatisfied()
    {
        FinanceSystem.AddCoins(DialogManager.currentDialog.successValue);
        StatsManager.GivePizza();
        ShowNextCustomer();
    }

    public void ShowNextCustomer()
    {
        DialogManager.ShowNextDialog();
    }
}