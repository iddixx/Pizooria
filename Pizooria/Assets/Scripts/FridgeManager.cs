using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeManager : MonoBehaviour
{
    public List<IngredientObject> BuyedIngredients = new List<IngredientObject>();
    
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
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
    }
    
    public List<IngredientObject> GetIngridients()
    {
        return BuyedIngredients;
    }
    public void ClearList()
    {
        BuyedIngredients.Clear();
    }
    public void AddItemToManager(IngredientObject item)
    {
        BuyedIngredients.Add(item);
    }
}
