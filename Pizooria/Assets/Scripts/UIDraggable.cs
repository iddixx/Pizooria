using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine;

public class UIDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform receiver;
    public UnityEvent<UIDraggable> OnReceive;

    public bool IsBeingDragged { get; private set; }

    public virtual void OnBeginDrag(PointerEventData data)
    {
        IsBeingDragged = true;
    }

    public virtual void OnDrag(PointerEventData data)
    {
        transform.position = data.position;
    }

    public virtual void OnEndDrag(PointerEventData data)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(data, results);

        foreach(RaycastResult result in results)
        {
            if(result.gameObject.transform == receiver)
            {
                OnReceive?.Invoke(this);
                break;
            }
        }

        IsBeingDragged = false;
    }

    public static void OnReceiveDissapear(UIDraggable drag) => Destroy(drag.gameObject);
}

