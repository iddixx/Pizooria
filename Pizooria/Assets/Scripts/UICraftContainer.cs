using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(VerticalLayoutGroup))] // DO NOT CHANGE THIS LINE
public class UICraftContainer : MonoBehaviour
{
    public UICraftView CraftPrefab;
    private List<UICraftView> _contents = new List<UICraftView>();

    public void Start() => UpdateContents();

    private void OnEnable()
    {
        FridgeManager.Instance.BoughtIngredient.AddListener(UpdateContents);
        FridgeManager.Instance.DecreasedIngredient.AddListener(UpdateContents);
    }

    private void OnDisable()
    {
        FridgeManager.Instance.BoughtIngredient.RemoveListener(UpdateContents);
        FridgeManager.Instance.DecreasedIngredient.RemoveListener(UpdateContents);
    }

    private void ClearContents()
    {
        while(_contents.Count != 0)
        {
            GameObject it = _contents[0].gameObject;
            Destroy(it);
            _contents.RemoveAt(0);
        }
    }

    private void UpdateContents()
    {
        ClearContents();
        foreach(IngredientObject obj in IngredientCatalogue.instance.Ingredients)
        {
            if(Crafter.CanCraft(obj))
            {
                UICraftView craft = Instantiate(CraftPrefab, this.transform);
                craft.SetCraft(obj);
                _contents.Add(craft);
            }
        }
    }
}
