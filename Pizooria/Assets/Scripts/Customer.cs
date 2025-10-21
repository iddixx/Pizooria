using UnityEngine;

public class Customer : MonoBehaviour
{
    public Pizza currentPizza;
    public DialogData data;

    public void ReceivePizza(Pizza pizza)
    {
        currentPizza = pizza;

        Debug.Log("Customer received pizza: " + pizza.ScriptableObject.name);

        if (data != null && data.Pizza != null)
        {
            if (pizza.ScriptableObject == data.Pizza)
            {
                FinanceSystem.coins += data.successValue;
                Debug.Log("Correct pizza! Added " + data.successValue + " coins.");
            }
            else
            {
                FinanceSystem.coins -= data.failValue;
                Debug.Log("Wrong pizza! Subtracted " + data.failValue + " coins.");
            }
            FindObjectOfType<FinanceSystem>().ChangeText();
        }
        else
        {
            Debug.Log("No desired pizza set for customer.");
        }
    }
}