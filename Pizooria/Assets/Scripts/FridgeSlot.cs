using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class FridgeSlot : MonoBehaviour
{
    public Image spriteRenderer;
    public TextMeshProUGUI countText, nameText;

    public Ingredient ingredient;

    public bool isEmpty => ingredient == null || ingredient.StackCount == 0;

    public void TakeOneItem()
    {
        if (isEmpty) return;

        
        FridgeDrag.Instance.StartDrag(this, 1, ingredient.ScriptableObject);
        ingredient.StackCount -= 1;

        if (ingredient.StackCount == 0)
            ingredient = null;

        UpdateUI();
    }

    public void TakeAllItems()
    {
        if (isEmpty) return;

        FridgeDrag.Instance.StartDrag(this, ingredient.StackCount, ingredient.ScriptableObject);
        ingredient = null;

        UpdateUI();
    }

    public uint AddItems(IngredientObject obj, uint count)
    {
        if (ingredient == null)
            ingredient = new Ingredient(obj);

        if (ingredient.ScriptableObject != obj)
            return count; 

        uint space = obj.MaxStack - ingredient.StackCount;
        uint toAdd = (count < space) ? count : space;
        ingredient.StackCount += toAdd;

        UpdateUI();

        return count - toAdd;
    }

    public void UpdateUI()
    {
        if (isEmpty)
        {
            spriteRenderer.sprite = null;
            nameText.text = "";
            countText.text = "";
        }
        else
        {
            spriteRenderer.sprite = ingredient.ScriptableObject.SelfSprite;
            nameText.text = ingredient.ScriptableObject.name;
            countText.text = ingredient.StackCount.ToString();
        }
    }
}
