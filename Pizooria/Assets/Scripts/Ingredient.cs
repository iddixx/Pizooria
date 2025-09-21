using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Ingredient
{
    public readonly IngredientObject ScriptableObject;
    public readonly uint MaxStack;
    // public uint Identifier;
    public UnityEvent<Ingredient> OnStackChange;

    protected uint _stack_count = 0;
    public virtual uint StackCount
    { 
        set
        {
            if(value >= MaxStack)
            {
                Debug.LogWarning($"{value} >= MaxStack");
                _stack_count = MaxStack;
                OnStackChange?.Invoke(this);
                return;
            }
            _stack_count = value;
            OnStackChange?.Invoke(this);
        }
        get => _stack_count;
    }

    public Ingredient(IngredientObject ScriptableObject)
    {
        if(ScriptableObject == null)
        {
            throw new System.ArgumentException("Ingredient should be initialized with ScriptableObject");
        }

        this.ScriptableObject = ScriptableObject;
        this.MaxStack = ScriptableObject.MaxStack;
    }
}

