using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
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
    protected SpriteRenderer _sprite_renderer;

    virtual protected void Start()
    {
        _sprite_renderer = this.GetComponent<SpriteRenderer>();
        if(ScriptableObject == null)
        {
            throw new System.ArgumentException("ScriptableObject is required for IngredientObject");
        }
        // this.Identifier = ScriptableObject.Identifier;
        this.MaxStack = ScriptableObject.MaxStack;
        this._sprite_renderer.sprite = ScriptableObject.SelfSprite;
    }
}

