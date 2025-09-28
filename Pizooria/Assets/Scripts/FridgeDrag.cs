using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FridgeDrag : MonoBehaviour
{

    public static FridgeDrag Instance;

    public Sprite defaultSprite;
    public Image image;
    public TextMeshProUGUI nameText, countText;

    private FridgeSlot originSlot;
    private uint count;
    private IngredientObject objectDragged;

    public bool IsLeftClick;

    private void Awake() => Instance = this;

    public void StartDrag(FridgeSlot slot, uint count, IngredientObject obj)
    {
        originSlot = slot;
        this.count = count;
        objectDragged = obj;

        image.sprite = obj.SelfSprite;
        nameText.text = obj.name;
        countText.text = count.ToString();

        IsLeftClick = (count > 1); 
        Fridge.IsDragGoing = true;
    }

    private void Update()
    {
        if (!Fridge.IsDragGoing) return;

        transform.position = Input.mousePosition;

        if (Input.GetMouseButtonUp(0))
        {
            EndDrag(linksklick: true);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            EndDrag(linksklick: false);
        }
    }

    private void EndDrag(bool linksklick)
    {
        Fridge.IsDragGoing = false;

        FridgeSlot targetSlot = FridgeManager.Instance.GetSlotUnderMouse();
        if (targetSlot != null)
        {
            uint toMove = linksklick ? count : 1;

            
            uint leftover = targetSlot.AddItems(objectDragged, toMove);

            
            if (leftover > 0)
            {
                originSlot.AddItems(objectDragged, leftover);
            }

            
            originSlot.UpdateUI();
            targetSlot.UpdateUI();
        }
        else
        {
            uint toReturn = linksklick ? count : 1;
            originSlot.AddItems(objectDragged, toReturn);
            originSlot.UpdateUI();
        }

        ResetDrag();
    }
    private void ResetDrag()
    {
        image.sprite = defaultSprite;
        nameText.text = "";
        countText.text = "";
    }
}
