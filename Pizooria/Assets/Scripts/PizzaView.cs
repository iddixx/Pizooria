using UnityEngine;
using UnityEngine.UI;

public class PizzaView : MonoBehaviour
{ 
    public Pizza Pizza { get; private set; }
    public Image Image;

    public void Display(Pizza pizza)
    {
        Pizza = pizza;
        Image.sprite = pizza.ScriptableObject.SelfSprite;
    }
}