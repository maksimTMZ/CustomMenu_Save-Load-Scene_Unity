using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EDITOR : MonoBehaviour
{
    [MenuItem("Custom/MyMenu/SaveScene")]
    static void SaveScene()
    {
        GameManager manager = FindObjectOfType<GameManager>();
        if (manager != null)
            manager.Save();
        else
            Debug.Log("Error");
    }

    [MenuItem("Custom/MyMenu/LoadScene")]
    static void LoadScene()
    {
        GameManager manager = FindObjectOfType<GameManager>();
        if (manager != null)
            manager.Load();
        else
            Debug.Log("Error");
    }
}
