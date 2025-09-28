using UnityEngine;

using UnityEngine.UI;

using UnityEngine.EventSystems;

using System.Collections.Generic;



/*public class PizzaUIManager : MonoBehaviour

{

    public Transform pizzaPanel;

    public GameObject pizzaItemPrefab;

    public GameObject dropZone;

    public List<Pizza> P;

    public Pizza pizzaObject;



    public List<GameObject> spawnedPizzaItems = new List<GameObject>();



    void Start()

    {

        if (pizzaObject != null)

        {

            PizzaBaker.Instance.StartBaking(pizzaObject);

        }

    }

    private void Update()

    {

        var pizzas = BakedPizzasContainer.Instance.Pizzas;



        foreach (var pizza in pizzas)

        {

            if (spawnedPizzaItems.Exists(i => i.GetComponent<DraggablePizza>().pizza == pizza))

            {

                continue;

            }





            GameObject item = Instantiate(pizzaItemPrefab, pizzaPanel);

            Image img = item.GetComponent<Image>();



            img.sprite = ((PizzaObject)pizza.ScriptableObject).BakedSprite;



            var drag = item.AddComponent<DraggablePizza>();

            drag.originalParent = pizzaPanel;

            drag.dropZone = dropZone;

            drag.pizza = pizza;



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

}*/