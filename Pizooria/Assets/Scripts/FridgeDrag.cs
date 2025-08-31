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
    public string defaultName;
    public string defaultCount;
    
    public int count;
    
    public uint maxStack;
    public bool IsLeftClick;
    private void Start()
    {
        
        fridge = FindObjectOfType<Fridge>();
        
    }
    private void Update()
    {
        _rect.position = Input.mousePosition;
        if (Input.GetMouseButtonUp(0) && Fridge.IsDragGoing && IsLeftClick)
        {
            Fridge.IsDragGoing = false;
            if (fridge.IsASlotTaking())
            {
                if (fridge.slotTaking.AddtoSlot(image.sprite,nameText.text,count,maxStack))
                {
                    ResetOldSlot();
                }
                else
                {
                    GiveRightBack();
                }
            }
            else
            {
                GiveRightBack();
            }
            ResetDrag();
            ResetTake();
        }
        if (Input.GetMouseButtonUp(1) && Fridge.IsDragGoing && !IsLeftClick)
        {
            Fridge.IsDragGoing = false;
            if (fridge.IsASlotTaking())
            {
                if (!fridge.slotTaking.AddtoSlot(image.sprite, nameText.text, count, maxStack))
                {
                    GiveLeftBack();
                }
                
            }
            else
            {
                GiveLeftBack();
            }
            ResetDrag();
            ResetTake();
        }
    }
    public void GiveRightBack()
    {
        oldSlot.image.sprite = image.sprite;

        oldSlot.nameText.text = nameText.text;


        oldSlot.countText.text = countText.text;


        oldSlot.isEmpty = false;

    }
    public void GiveLeftBack() 
    {

        oldSlot.slotCount += 1;
        oldSlot.countText.text = oldSlot.slotCount.ToString();
        if (oldSlot.slotCount - 1 <= 0)
        {
            oldSlot.nameText.text = nameText.text;
            oldSlot.image.sprite = image.sprite;


            oldSlot.isEmpty = false;
        }
        oldSlot.IsTaking = false;
    }
    
    public void ResetOldSlot()
    {
        oldSlot.image.sprite = defaultSprite;

        oldSlot.nameText.text = defaultName;
        oldSlot.countText.text = defaultCount;
        
        oldSlot.slotCount = 0;
        oldSlot.maxStack = 0;

        
        oldSlot.isEmpty = true;
    }
    
    
    public void ResetDrag()
    {
        image.sprite = defaultSprite;

        nameText.text = "";
        countText.text = "";
        
        count = 0;
        maxStack = 0;
        
    }
    public void ResetTake()
    {
        foreach (FridgeSlot slot in fridge.slots) 
        {
            slot.IsTaking = false;
        }
    }
}
