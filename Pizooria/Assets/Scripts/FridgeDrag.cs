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
    
    public uint count;
    public IngredientObject Object;
    
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
                if (fridge.slotTaking.AddtoSlot(count,Object))
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
                if (!fridge.slotTaking.AddtoSlot(count,Object))
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
        oldSlot.spriteRenderer.sprite = image.sprite;

        oldSlot.nameText.text = nameText.text;


        oldSlot.countText.text = countText.text;


        oldSlot.isEmpty = false;

    }
    public void GiveLeftBack() 
    {

        oldSlot.Ingredient.StackCount += 1;
        oldSlot.countText.text = oldSlot.Ingredient.StackCount.ToString();
        if (oldSlot.Ingredient.StackCount - 1 <= 0)
        {
            oldSlot.nameText.text = nameText.text;
            oldSlot.spriteRenderer.sprite = image.sprite;


            oldSlot.isEmpty = false;
        }
        oldSlot.IsTaking = false;
    }
    
    public void ResetOldSlot()
    {
        oldSlot.spriteRenderer.sprite = defaultSprite;

        oldSlot.nameText.text = defaultName;
        oldSlot.countText.text = defaultCount;
        
        oldSlot.Ingredient.StackCount = 0;
        oldSlot.Ingredient.StackCount = 0;

        
        oldSlot.isEmpty = true;
    }
    
    
    public void ResetDrag()
    {
        image.sprite = defaultSprite;

        nameText.text = "";
        countText.text = "";
        
        count = 0;
        
        
    }
    public void ResetTake()
    {
        foreach (FridgeSlot slot in fridge.slots) 
        {
            slot.IsTaking = false;
        }
    }
}
