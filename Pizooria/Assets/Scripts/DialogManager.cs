using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Random = UnityEngine.Random;

[System.Serializable]
public class DialogChance
{
    public DialogData dialogData;
    [Range(0f, 1f)]
    public float chance = 0.1f;
}

public class DialogManager : MonoBehaviour
{
    public List<DialogChance> dialogs = new List<DialogChance>();
    public Customer customer;

    public DialogData currentDialog;
    private DialogData lastDialog;

    public void ShowNextDialog()
    {
        List<DialogChance> pool = new List<DialogChance>(dialogs);
        if (dialogs.Count > 2 && lastDialog != null)
        {
            pool.RemoveAll(dc => dc.dialogData == lastDialog);
        }

        float totalChance = 0f;
        foreach (var dc in pool)
            totalChance += dc.chance;

        float roll = Random.value * totalChance;
        float cum = 0f;

        foreach (var dc in pool)
        {
            cum += dc.chance;
            if (roll <= cum)
            {
                currentDialog = dc.dialogData;
                break;
            }
        }

        ShowDialog(currentDialog);
    }

    public void ShowDialog(DialogData dialog)
    {
        lastDialog = dialog;
        currentDialog = dialog;

        customer.Display(dialog);
    }
}