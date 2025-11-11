
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class PizzaUIManager : MonoBehaviour
{
    public Pizza DraggingPizza;
    public BakedPizzaGameView viewPrefab;
    public BakedPizzaGameView dragPrefab;
    public Transform pizzaPanel;

    public List<BakedPizzaGameView> spawnedPizzaItems = new List<BakedPizzaGameView>();

    void Start()
    {
        DragSystem.Instance.OnDragEnded += ended =>
        {
            DraggingPizza = null;
            UpdateSpawnedPizzaItems();
        };
        
        BakedPizzasContainer.Instance.OnPizzaPushed.AddListener(UpdateSpawnedPizzaItems);
        UpdateSpawnedPizzaItems();
        
        BakeRandomPizzaForTesting();
    }

    private void BakeRandomPizzaForTesting()
    {

        Pizza randomPizza = PizzaManager.Instance.GetRandomPizza();
        PizzaBaker.Instance.StartBaking(randomPizza);
        
        randomPizza = PizzaManager.Instance.GetRandomPizza();
        randomPizza.bakingEndTime += 3;
        PizzaBaker.Instance.StartBaking(randomPizza);

    }

    private void UpdateSpawnedPizzaItems()
    {
        var pizzas = BakedPizzasContainer.Instance.Pizzas;
        int i = 0;
        foreach (var pizza in pizzas)
        {
            var item = GetItem(i);
            item.Display(pizza);
            i++;
        }

        for (; i < spawnedPizzaItems.Count; i++)
        {
            spawnedPizzaItems[i].gameObject.SetActive(false);
        }
    }

    private BakedPizzaGameView GetItem(int i)
    {
        if (spawnedPizzaItems.Count >= i)
        {
            var item = Instantiate(viewPrefab, pizzaPanel);
            item.Link(this);
            spawnedPizzaItems.Add(item);
            return item;
        }
        else
        {
            var item = spawnedPizzaItems[i];
            item.gameObject.SetActive(true);

            return item;
        }
    }

    public void BeginDrag(BakedPizzaGameView view)
    {
        DraggingPizza = view.Pizza;
        var drag = Instantiate(dragPrefab, pizzaPanel);
        drag.DisplayDrag(DraggingPizza);
        DragSystem.Instance.StartDrag(drag);
    }


    public void RemovePizza(Pizza pizza)
    {
        BakedPizzasContainer.Instance.Pizzas.Remove(pizza);
    }
}