using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class Ingredient : MonoBehaviour
{
    public IngredientObject ScriptableObject;
    public uint MaxStack;
    // public uint Identifier;
    public UnityEvent<Ingredient> OnStackChange;

    public virtual uint StackCount
    { 
        set
        {
            if(value >= MaxStack)
            {
                Debug.LogWarning($"{value} >= MaxStack", this);
                _stack_count = MaxStack;
                OnStackChange?.Invoke(this);
                return;
            }
            _stack_count = value;
            OnStackChange?.Invoke(this);
        }
        get => _stack_count;
    }
    protected uint _stack_count = 0;
    protected Image _sprite_renderer;

    public void UpdateValues()
    {
        _sprite_renderer = this.GetComponent<Image>();
        if (ScriptableObject != null)
        {
            // this.Identifier = ScriptableObject.Identifier;
            this.MaxStack = ScriptableObject.MaxStack;
            this._sprite_renderer.sprite = ScriptableObject.SelfSprite;
        }
    }
    virtual protected void Start()
    {
        _sprite_renderer = this.GetComponent<Image>();
        if(ScriptableObject != null)
        {
            // this.Identifier = ScriptableObject.Identifier;
            this.MaxStack = ScriptableObject.MaxStack;
            this._sprite_renderer.sprite = ScriptableObject.SelfSprite;
        }
        
    }
}

