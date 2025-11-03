using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using System.Linq;
using UnityEngine;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using Unity.VisualScripting;
using System.ComponentModel;
using UnityEngine.EventSystems;
public class FridgeManager : MonoBehaviour
{
    public List<FridgeSlot> slots = new List<FridgeSlot>();
    public List<CraftUnit> BuyedIngredients = new List<CraftUnit>();
    // make it use CraftUnit instead of IngredientObject, to have the count of Ingerdients
    //
    public Fridge fridge;
    
    public FridgeSlot slotTaking;

    public static FridgeManager Instance;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnBeforeSceneLoad()
    {
        if (FindObjectOfType<FridgeManager>() == null)
        {
            GameObject go = new GameObject("FridgeManager");
            go.AddComponent<FridgeManager>();
            DontDestroyOnLoad(go);
        }

        Debug.Log("Fridge initialized before scene load.");
    }

    public FridgeSlot GetSlotUnderMouse()
    {
        
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        foreach (var result in results)
        {
            FridgeSlot slot = result.gameObject.GetComponent<FridgeSlot>();
            if (slot != null)
            {
                return slot;
            }
        }

        return null;
    }
    public void AddItem(IngredientObject itemObject,uint amount)
    {
        for (int i = 0; i < slots.Count; i++) 
        {
            AddItemToSlot(i,itemObject,amount);
        }
    }
    public bool AddItemToSlot(int slotIndex, IngredientObject itemObject, uint amount)
    {
        
        bool couldAdd = false;
        if (slotIndex < 0 || slotIndex >= slots.Count)
        {
            Debug.LogError("slotIndex out of range!");
            return false;
        }
        FridgeSlot slot = slots[slotIndex];
        if (slot.ingredient == null)
        {
            slot.ingredient = new Ingredient(itemObject);
            slot.ingredient.StackCount = amount;
        }
        else
        {
            if (slot.ingredient.ScriptableObject == itemObject)
            {
                slot.ingredient.StackCount += amount;
            }
            else
            {

                return false;
            }
        }
        return couldAdd;
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        // StartCoroutine(PrintIngredientsEvery(5)); // for testing purposes
    }
    
    
    public void AddItemToManager(IngredientObject item)
    {
        bool found = false;
        for(int i = 0; i < BuyedIngredients.Count; ++i)
        {
            if(BuyedIngredients[i].Ingredient == item)
            {
                found = true;
                CraftUnit found_unit = BuyedIngredients[i];
                found_unit.Count += (uint)item.AmmountPerCost;
                BuyedIngredients.RemoveAt(i);
                BuyedIngredients.Add(found_unit);
            }
        }

        if(!found)
        {
            BuyedIngredients.Add(new CraftUnit(item, (uint)item.AmmountPerCost));
        }
    }

    public void DecreaseCountFromManager(IngredientObject item)
    {
        bool found = false;
        for(int i = 0; i < BuyedIngredients.Count; ++i)
        {
            if(BuyedIngredients[i].Ingredient == item)
            {
                found = true;
                CraftUnit found_unit = BuyedIngredients[i];
                if((found_unit.Count - 1) == 0)
                {
                    BuyedIngredients.RemoveAt(i);
                }
                else
                {
                    BuyedIngredients.RemoveAt(i);
                    BuyedIngredients.Add(found_unit);
                }
            }
        }

        if(!found)
        {
            throw new System.ArgumentException("You cannot decrease count of item that is not in fridge!");
        }
    }

    // public void PrintIngredients()
    // {
    //     if(!BuyedIngredients.Any())
    //     {
    //         Debug.Log("[]");
    //         return;
    //     }
    //
    //     string result = "[";
    //     result += $"{BuyedIngredients[0].Ingredient.name}";
    //     for(int i = 1; i < BuyedIngredients.Count; ++i)
    //     {
    //         result += $" ,{BuyedIngredients[i]Ingredient.name}";
    //     }
    //     result += $"]";
    //     Debug.Log(result);
    // }

    // public IEnumerator PrintIngredientsEvery(float seconds)
    // {
    //     while(true)
    //     {
    //         PrintIngredients();
    //         yield return new WaitForSeconds(seconds);
    //     }
    // }
}
