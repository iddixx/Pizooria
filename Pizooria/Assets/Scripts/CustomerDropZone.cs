using System;
using UnityEngine;
using UnityEngine.UI;

public class CustomerDropZone : MonoBehaviour, IDragDropZone
{
    public Customer Customer;

    public Image AcceptOutline;

    public void Start()
    {
        AcceptOutline.enabled = false;
    }

    public bool CanAccept(IDragObject dragObject)
    {
        return dragObject.DragData is Pizza;
    }

    public void BeginAccepting(IDragObject dragObject)
    {
        AcceptOutline.enabled = true;
    }

    public void EndAccepting()
    {
        AcceptOutline.enabled = false;
    }

    public void Accept(IDragObject dragObject)
    {
        Customer.ReceivePizza((Pizza)dragObject.DragData);
    }
}