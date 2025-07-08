using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightClickDown : MonoBehaviour, IPointerDownHandler
{
    public FridgeSlot slot;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            slot.TakeOneItem();
        }
    }
}

