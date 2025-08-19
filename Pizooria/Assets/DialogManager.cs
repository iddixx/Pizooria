using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public enum PizzaType
{
    Margherita,
    Pepperoni,
    Hawaiian,
}

[CreateAssetMenu(fileName = "DialogData", menuName = "ScriptableObjects/DialogData", order = 1)]
public class DialogData : ScriptableObject
{
    public string characterName;
    
    public string dialogText;
    public PizzaType pizzaType;
    public float failValue;
    public float successValue;
}

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
    public int numberOfPeople = 5;
    public TMP_Text nameText;
    public TMP_Text dialogText;
    public GameObject dialogBar;
    public float money = 100f;

    private DialogData currentDialog;
    private DialogData lastDialog;

    void Start()
    {
        ShowNextDialog();
    }

    void ShowNextDialog()
    {
        numberOfPeople--;
        if (numberOfPeople <= 0)
        {
            EndDay();
            return;
        }

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

        lastDialog = currentDialog;

        nameText.text = currentDialog.characterName;
        dialogText.text = currentDialog.dialogText;
    }

    public void OnSkip()
    {
        StartCoroutine(SkipRoutine());
    }

    IEnumerator SkipRoutine()
    {
        // Debug.Log("Skip: логіка ще не дописана");
        money -= currentDialog.failValue;

        yield return new WaitForSeconds(1f);
        dialogBar.SetActive(false);

        yield return new WaitForSeconds(1f);
        dialogBar.SetActive(true);

        ShowNextDialog();
    }

    public void OnGiveUp()
    {
        StartCoroutine(GiveUpRoutine());
    }

    IEnumerator GiveUpRoutine()
    {
        // Debug.Log("GiveUp: логіка ще не дописана");
        money += currentDialog.successValue;

        yield return new WaitForSeconds(1f);
        dialogBar.SetActive(false);

        yield return new WaitForSeconds(1f);
        dialogBar.SetActive(true);

        ShowNextDialog();
    }

    void EndDay()
    {
        Debug.Log("End of Day: всі діалоги пройдені.");
    }
}