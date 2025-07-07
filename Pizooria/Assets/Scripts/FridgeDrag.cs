using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FridgeDrag : MonoBehaviour
{
    public RectTransform _rect;
    public TextMeshProUGUI nameText,countText;
    public Image image;

    public int count;
    public uint maxStack;
    private void Update()
    {
        _rect.position = Input.mousePosition;
    }
}
