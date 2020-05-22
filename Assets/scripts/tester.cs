using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Threading;
using System.Diagnostics;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;
public class tester : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private  GameObject Cube1;
    [SerializeField]
    private  GameObject Cube2;
    [SerializeField]
    private  GameObject Cube3;
    private List<GameObject> Matrix;
    private Vector3 Pos;
    private string path;
    private List<string> DataSet;
    UnityEngine.Quaternion Angle;
    private int startPoint;
    void Start()
    {
        startPoint = 0;
        path = System.IO.File.ReadAllText("Data.txt");
        Vector3 Pos = new Vector3((float) -7, (float) 4, 0);
        Angle = Camera.main.transform.rotation;
        DataSet = Solved().ToList<string>();
        CreateNonogram();
    }
    private string[] Solved()
    {
        READER reader = new READER(path);
        List<List<String>> Da = reader.GetData();
            string x = "";
            for (int i = 0; i < Da[0].Count; i++)
            {
                x = x + Da[0][i];
                if (i < Da[0].Count-1)
                {
                    x = x + ' ';
                }
            }
            string y = "";
            for (int i = 0; i < Da[1].Count; i++)
            {
                y = y + Da[1][i];
                if (i < Da[1].Count - 1)
                {
                    y = y + ' ';
                }
            }
        Stopwatch watch = new Stopwatch();
        watch.Start();
        string result = Nonogram.Solve(x,y);
        watch.Stop();
        UnityEngine.Debug.Log("Tiempo de ejecución = "+watch.Elapsed);
        Matrix = new List<GameObject>();
        return result.Split('\n');
    }
    public void GoMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    private void CreateNonogram()
    {
        Pos[0] = (float) -7;
        Pos[1] = (float) 4;
        Pos[2] = (float) 0;
        for(int i = startPoint; i < this.DataSet.Count(); i++)
        {
            foreach (var item in this.DataSet[i])
            {
                if(item == '#')
                {
                    this.Matrix.Add(Instantiate(Cube2,Pos,Angle));
                }
                if(item == '.')
                {
                    this.Matrix.Add(Instantiate(Cube1,Pos,Angle));
                }
                if(item == '?')
                {
                    this.Matrix.Add(Instantiate(Cube3,Pos,Angle));
                }
                Pos[0] += (float)0.2001;
            }
            Pos[0] = (float)-7;
            Pos[1] -= (float)0.25;
            startPoint = i;
        }
        UnityEngine.Debug.Log("Tamaño de nonogram "+this.Matrix.Count);
        UnityEngine.Debug.Log("Tamaño de DATASET "+this.DataSet.Count);
    }
    public void NewNonogram()
    {
        this.path = EditorUtility.OpenFilePanel("Overwrite with txt", "", "txt");
        DestroyMatrix();
        DataSet = Solved().ToList<string>();
        CreateNonogram();
    }
    public void DestroyMatrix()
    {
        UnityEngine.Debug.Log("DataSet = "+ DataSet.Count);
        DataSet.Clear();
        DataSet = new List<String>();
        UnityEngine.Debug.Log("DataSet = "+ DataSet.Count);
        foreach(var z in this.Matrix)
        {
            Destroy(z);
        }
        UnityEngine.Debug.Log("Matrix = "+this.Matrix.Count);
        this.Matrix.Clear();
        UnityEngine.Debug.Log("Matrix = "+this.Matrix.Count);
    }
}
