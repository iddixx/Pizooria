using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
public class GameOverManager : MonoBehaviour
{
    List<IGameoverInfo> infos = new List<IGameoverInfo>();
    List<GameObject> texts = new List<GameObject>(); 
    public GameObject textPrefab;
    public Transform contentParent;
    public TextMeshProUGUI GameOver;
    public void AddInfo(IGameoverInfo asdf)
    {
        infos.Add(asdf);
    }
    public void ShowGameOverScreen()
    {
        StartCoroutine(ShowInfosStepByStep());
        /*foreach (var inf in texts)
        {
            Destroy(inf.gameObject);
        }

        foreach (var inf in infos) 
        {
            Debug.Log(inf.GetLabel() + ": " + inf.GetValue());
            GameObject entry = Instantiate(textPrefab, contentParent);
            entry.GetComponent<TextMeshProUGUI>().text = inf.GetLabel() + ": " + inf.GetValue();
            texts.Add(entry);
        }
        
        infos.Clear();*/
    }
    private IEnumerator ShowInfosStepByStep()
    {
        foreach (var inf in texts)
        {
            Destroy(inf.gameObject);
        }
        Color color = GameOver.color;
        float time = 0f;
        float duration = 1f;
        while (time < duration)
        {
            
            time += Time.deltaTime;
            float t = Mathf.Clamp01(time  / duration);
            color.a = t; 
            GameOver.color = color;
            yield return null;
        }


        foreach (var inf in infos)
        {
            GameObject entry = Instantiate(textPrefab, contentParent);
            TextMeshProUGUI text = entry.GetComponent<TextMeshProUGUI>();
            text.text = inf.GetLabel() + ": " + inf.GetValue();
            texts.Add(entry);



            yield return StartCoroutine(FadeInText(text,duration));
        }
        infos.Clear(); 
        yield return null;
    }
    private IEnumerator FadeInText(TextMeshProUGUI text, float duration)
    {
        Color color = text.color;
        color.a = 0;
        text.color = color;

        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = Mathf.Clamp01(time / duration);
            color.a = t;
            text.color = color;
            yield return null;
        }
    }
}


