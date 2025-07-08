using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftClickDown : MonoBehaviour, IPointerDownHandler
{
    public FridgeSlot slot;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            slot.TakeAllItems(); 
        }
    }
}
