using UnityEngine;
using UnityEngine.UI;

public class PizzaView : MonoBehaviour
{ 
    public PizzaObject Pizza { get; private set; }
    public Image Image;

    public void Display(PizzaObject pizza)
    {
        Pizza = pizza;
        Image.sprite = pizza.SelfSprite;
    }
}