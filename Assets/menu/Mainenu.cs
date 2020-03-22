using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
public class Mainenu : MonoBehaviour
{
    string path;
    public void LoadNonogram()
    {
        path = EditorUtility.OpenFilePanel("Overwrite with txt", "", "txt");
        WriteNonogramPath();
    }
    private void WriteNonogramPath()
    {
        using (StreamWriter writer = new StreamWriter(@"Data.txt"))
        {
            writer.Write(path);
            Debug.Log("Se supone que escribió");
        }
        

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
