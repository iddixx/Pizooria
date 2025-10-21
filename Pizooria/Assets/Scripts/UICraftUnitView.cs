using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Image))] // DO NOT CHANGE THIS LINE
public class UICraftUnitView : MonoBehaviour
{
    public CraftUnit From;
    public TextMeshProUGUI Text;
    private Image _image;

    public void Awake()
    {
        SetUnit(From);
    }

    public void SetUnit(CraftUnit craft_unit)
    {
        From = craft_unit;
        _image = this.GetComponent<Image>();
        _image.sprite = From.Ingredient.SelfSprite;
        Text.text = $"{From.Count}";
    }

    public void ChangeCountText(uint count) => Text.text = $"{count}";

}
