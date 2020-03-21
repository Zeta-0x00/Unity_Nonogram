using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
public class Mainenu : MonoBehaviour
{
    public string path;
    public void LoadNonogram()
    {
        path = EditorUtility.OpenFilePanel("Overwrite with txt", "", "txt");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("We're out");
    }
}
