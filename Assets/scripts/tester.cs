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
    void Start()
    {
        path = System.IO.File.ReadAllText("Data.txt");
        Vector3 Pos = new Vector3((float) -7, (float) 4, 0);
        Angle = Camera.main.transform.rotation;
        DataSet = Solved().ToList<string>();
        CreateNonogram();
    }
    private string[] Solved()
    {
        READER reader = new READER(path);
        String[] Da = reader.GetData();
        int[] v = reader.GetDims();
        UnityEngine.Debug.Log("Dimentions: "+v[0]+" x "+v[1]);
        Stopwatch watch = new Stopwatch();
        watch.Start();
        string result = Nonogram.Solve(Da[0],Da[1]);
        watch.Stop();
        UnityEngine.Debug.Log("Tiempo de ejecución = "+watch.Elapsed);
        Matrix = new List<GameObject>();
        //UnityEngine.Debug.Log(result);
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
        for(int i = 0; i < this.DataSet.Count(); i++)
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
        }
        UnityEngine.Debug.Log(this.Matrix.Count);
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
