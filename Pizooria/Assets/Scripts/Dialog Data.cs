using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogData", menuName = "ScriptableObjects/DialogData", order = 1)]
public class DialogData : ScriptableObject
{
    public string characterName;
    public Sprite characterSprite;

    [TextArea(3, 10)]
    public string dialogText;
    public int failValue;
    public int successValue;

    [Header("Pizza is needed")]
    public PizzaObject Pizza;

}
