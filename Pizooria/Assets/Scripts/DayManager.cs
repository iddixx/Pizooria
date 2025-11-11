using System;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public int PeopleLeft;
    
    public int PeoplePerDay;
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
        PeopleLeft = PeoplePerDay;
        ShowNextCustomer();
    }

    private void CustomerOnOnFailed()
    {
        FinanceSystem.UseCoins(DialogManager.currentDialog.failValue);
        ShowNextCustomer();
    }

    private void CustomerOnOnSatisfied()
    {
        FinanceSystem.AddCoins(DialogManager.currentDialog.successValue);
        ShowNextCustomer();
    }

    public void ShowNextCustomer()
    {
        if (PeopleLeft <= 0)
        {
            EndDay();
            return;
        }

        DialogManager.ShowNextDialog();
        PeopleLeft--;
    }

    public void EndDay()
    {
        Debug.Log("End day");
    }
}