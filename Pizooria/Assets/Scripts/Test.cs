using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Fridge fridge;
    public Ingredient ingredient;
    private void Start()
    {
        fridge = FindObjectOfType<Fridge>();


    }
    public void OnClick()
    {
        ingredient = fridge.slots[1].GetIngredient();
    }
}
