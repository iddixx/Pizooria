using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FridgeDrag : MonoBehaviour
{
    public RectTransform _rect;
    
    public TextMeshProUGUI nameText,countText;
    public Image image;

    public Fridge fridge;
    public FridgeSlot oldSlot;

    public Sprite defaultSprite;

    public int count;
    public uint maxStack;
    private void Start()
    {
        fridge = FindObjectOfType<Fridge>();
    }
    private void Update()
    {
        _rect.position = Input.mousePosition;
        if (Input.GetMouseButtonUp(0) && Fridge.IsDragGoing)
        {
            Fridge.IsDragGoing = false;
            if (fridge.IsASlotTaking())
            {
                SetNewSlot(fridge.slotTaking);
                fridge.slotTaking = null;
                ResetOldSlot();
                ResetDrag();
            }
            else
            {
                SetOldSlot();
                ResetDrag();
            }
        }
    }
    public void ResetOldSlot()
    {
        oldSlot.image.sprite = defaultSprite;

        oldSlot.nameText.text = "Name";
        oldSlot.countText.text = "0";
        
        oldSlot.slotCount = 0;
        oldSlot.maxStack = 0;

        
        oldSlot.isEmpty = true;
    }
    public void SetNewSlot(FridgeSlot slot)
    {
        slot.image.sprite = image.sprite;

        slot.nameText.text = nameText.text;
        slot.countText.text = countText.text;
        
        slot.slotCount = count;
        slot.maxStack = maxStack;
        
        slot.IsTaking = false;
        slot.isEmpty = false;
    }
    public void SetOldSlot()
    {
        oldSlot.image.sprite = image.sprite;

        oldSlot.nameText.text = nameText.text;
        oldSlot.countText.text = countText.text;

        
        oldSlot.isEmpty = false;
    }
    public void ResetDrag()
    {
        image.sprite = defaultSprite;

        nameText.text = "";
        countText.text = "";
        
        count = 0;
        maxStack = 0;
        
    }
}
