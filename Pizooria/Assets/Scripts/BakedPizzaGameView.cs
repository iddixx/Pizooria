using UnityEngine;
using UnityEngine.EventSystems;

public class BakedPizzaGameView : MonoBehaviour, IBeginDragHandler
{
    public PizzaView PizzaView;
    public CanvasGroup CanvasGroup;
    public Pizza Pizza { get; private set; }
    public PizzaUIManager Manager { get; private set; }

    public void Link(PizzaUIManager manager)
    {
        Manager = manager;
    }

    public void Display(Pizza pizza)
    {
        Pizza = pizza;
        PizzaView.Display(pizza.ScriptableObject);
        if (pizza == Manager.DraggingPizza)
        {
            CanvasGroup.alpha = 0.6f;
        }
        else
        {
            CanvasGroup.alpha = 1;
        }
    }

    public void DisplayDrag(Pizza pizza)
    {
        Pizza = pizza;
        PizzaView.Display(pizza.ScriptableObject);
        CanvasGroup.blocksRaycasts = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }
}