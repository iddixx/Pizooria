using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogData", menuName = "ScriptableObjects/DialogData", order = 1)]
public class DialogData : ScriptableObject
{
    public string characterName;

    public string dialogText;
    public PizzaType pizzaType;
    public int failValue;
    public int successValue;
}
