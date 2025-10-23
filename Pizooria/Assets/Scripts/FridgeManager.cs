using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
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
    public List<IngredientObject> BuyedIngredients = new List< IngredientObject>();
    
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
        
    }
    
    
    public void AddItemToManager(IngredientObject item)
    {
        BuyedIngredients.Add(item);
    }
}
