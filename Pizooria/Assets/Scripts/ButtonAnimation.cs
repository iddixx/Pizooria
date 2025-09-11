using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent(typeof(EventTrigger))]
public class ButtonAnimation : MonoBehaviour
{
    
    public float NormalSize = 1f;
    public void OnPointerDown()
    {
        transform.DOScale(NormalSize * 0.7f,0.3f);
    }
    public void OnPointerUp()
    {
        transform.DOScale(NormalSize, 0.3f);
    }
}
