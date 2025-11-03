using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(HorizontalLayoutGroup), typeof(Button))] // DO NOT CHANGE THIS LINE
public class UICraftView : MonoBehaviour
{
    public IngredientObject From;
    public UICraftUnitView UnitPrefab;
    public Image SeparatorPrefab;
    private List<GameObject> _items = new List<GameObject>();
    private Button _self_button;

    private void Awake()
    {
        _self_button = GetComponent<Button>();
        SetCraft(From);
    }

    private void CraftAction() => Crafter.UnsafeFridgeCraft(From);
    private void OnEnable()
    {
        _self_button.onClick.AddListener(CraftAction);
    }

    private void OnDisable()
    {
        _self_button.onClick.RemoveListener(CraftAction);
    }

    public void SetCraft(IngredientObject craft)
    {
        if((craft.Craft == null) || (craft.Craft.Length == 0))
        {
            throw new System.ArgumentException("UICraftView cannot display non-existent craft");
        }
        _self_button.onClick.RemoveListener(CraftAction);

        while(_items.Any())
        {
            Destroy(_items[0]);
            _items.RemoveAt(0);
        }

        foreach(CraftUnit curr_unit in craft.Craft)
        {
            UICraftUnitView unit_view = Instantiate(UnitPrefab, this.transform);
            unit_view.SetUnit(curr_unit);
        }

        Image separator = Instantiate(SeparatorPrefab, this.transform);
        _self_button.targetGraphic = separator;

        CraftUnit craft_result = new CraftUnit(craft, (uint)craft.AmmountPerCost);

        UICraftUnitView result_view = Instantiate(UnitPrefab, this.transform);
        result_view.SetUnit(craft_result);

        From = craft;
        _self_button.onClick.AddListener(CraftAction);
    }
}
