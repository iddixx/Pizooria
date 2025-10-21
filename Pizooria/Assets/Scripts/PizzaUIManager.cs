
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class PizzaUIManager : MonoBehaviour
{
    public Transform pizzaPanel;
    public GameObject pizzaItemPrefab;
    public GameObject dropZone;
    public PizzaObject testPizzaObject;

    public List<GameObject> spawnedPizzaItems = new List<GameObject>();

    void Start()
    {
        BakeRandomPizzaForTesting();
        Debug.Log(BakedPizzasContainer.Instance);
        Debug.Log(BakedPizzasContainer.Instance.OnPizzaPushed);
        BakedPizzasContainer.Instance.OnPizzaPushed.AddListener(UpdateSpawnedPizzaItems);
        


        UpdateSpawnedPizzaItems();
    }

    private void BakeRandomPizzaForTesting()
    {

        Pizza randomPizza = PizzaManager.Instance.GetRandomPizza();
        PizzaBaker.Instance.StartBaking(randomPizza);


        
    }

    private void UpdateSpawnedPizzaItems()
    {
        if (pizzaItemPrefab == null || pizzaPanel == null) return;

        var pizzas = BakedPizzasContainer.Instance.Pizzas;
        Debug.Log(pizzas.Count);
        foreach (var pizza in pizzas)
        {

            if (spawnedPizzaItems.Exists(i =>
                i.GetComponent<DraggablePizza>()?.pizza == pizza))
            {
                continue;
            }

            GameObject item = Instantiate(pizzaItemPrefab, pizzaPanel);
            Image img = item.GetComponent<Image>();

            if (pizza.ScriptableObject is PizzaObject pizzaObj)
            {
                img.sprite = pizzaObj.BakedSprite;
            }

            var drag = item.GetComponent<DraggablePizza>();
            if (drag == null)
            {
                drag = item.AddComponent<DraggablePizza>();
            }

            drag.originalParent = pizzaPanel;
            drag.dropZone = dropZone;
            drag.pizza = pizza;
            drag.pizzaObject = item;

            spawnedPizzaItems.Add(item);
        }
    }



    public void RemovePizza(GameObject pizzaItem)
    {
        var drag = pizzaItem.GetComponent<DraggablePizza>();
        if (drag != null)
        {
            BakedPizzasContainer.Instance.Pizzas.Remove(drag.pizza);
        }

        spawnedPizzaItems.Remove(pizzaItem);
        Destroy(pizzaItem);
    }
}