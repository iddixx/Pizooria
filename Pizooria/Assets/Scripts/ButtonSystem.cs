using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSystem : MonoBehaviour
{
    public event Action OnItemBought;
    public void Buy()
    {
        OnItemBought?.Invoke();
    }
}
