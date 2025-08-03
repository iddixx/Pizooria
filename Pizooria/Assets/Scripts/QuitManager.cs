using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuitManager : MonoBehaviour
{
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
