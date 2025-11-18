using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public DialogData data;

    public event Action OnSatisfied;
    public event Action OnFailed;

    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DialogText;
    public Image CustomerImage;
    public PizzaView PizzaView;

    public Animator animationS;
    public Animator animationD;
    public AnimationClip Stars;
    public AnimationClip Dislike;

    private void Awake()
    {
    }

    public void Display(DialogData data)
    {
        this.data = data;

        NameText.text = data.characterName;
        DialogText.text = data.dialogText;
        CustomerImage.sprite = data.characterSprite;

        PizzaView.Display(data.Pizza);
    }

    public void ReceivePizza(Pizza pizza)
    {
        if (pizza.ScriptableObject == data.Pizza)
        {
            ReceivedRightPizza();
        }
        else
        {
            ReceivedWrongPizza();
        }
        BakedPizzasContainer.Instance.RemovePizza(pizza);
    }

    [ContextMenu("Receive right pizza")]
    public void ReceivedRightPizza()
    {
        animationS.SetTrigger("Like");
        OnSatisfied?.Invoke();
        Debug.Log("Correct pizza! Added " + data.successValue + " coins.");
    }

    [ContextMenu("Receive wrong pizza")]
    public void ReceivedWrongPizza()
    {
        animationD.SetTrigger("Dislike");
        OnFailed?.Invoke();
        Debug.Log("Wrong pizza! Subtracted " + data.failValue + " coins.");
    }
}