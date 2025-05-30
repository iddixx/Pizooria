using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Ingredient : MonoBehaviour
{
    public IngredientObject OptScriptableObject;
    public uint MaxStack;
    public uint Identifier;
    public UnityEvent<Ingredient> OnStackChange;

    public uint StackCount
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
    private uint _stack_count = 0;
    private SpriteRenderer _sprite_renderer;

    private void Start()
    {
        _sprite_renderer = this.GetComponent<SpriteRenderer>();
        if(OptScriptableObject != null)
        {
            this.Identifier = OptScriptableObject.Identifier;
            this.MaxStack = OptScriptableObject.MaxStack;
            this._sprite_renderer.sprite = OptScriptableObject.SelfSprite;
        }
    }
}

