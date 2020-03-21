using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Threading;
using System.Diagnostics;

public class tester : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private  GameObject Cube1;
    [SerializeField]
    private  GameObject Cube2;
    private List<GameObject> Matrix;
    private String[] DataSet;
    double contX = -7;
    double contY = 0;
    private Vector3 Pos;
    void Start()
    {
        READER reader = new READER("C:/Users/Zeta/Documents/TestFile.txt");
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
        DataSet = result.Split('\n');
        Vector3 Pos = new Vector3((float)contX, (float)contY, 0);
        CreateNonogram();
    }
    /*private async Task WaitOneSecondAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        //Debug.Log("Finished waiting.");
    }*/

    // Update is called once per frame
    void Update()
    {
      //  DestroyMatrix();
        
      //  CreateNonogram();
    }
    /*IEnumerator Waiting()
    {
        yield return new waitForSeconds(1);
    }*/
    private void CreateNonogram()
    {
        var Angle = Camera.main.transform.rotation;
        Pos[0] = (float) -7;
        Pos[1] = (float) 4;
        Pos[2] = (float) 0;
        for(int i = 0; i < DataSet.Length; i++)
        {
            foreach (var item in DataSet[i])
            {
                //Waiting();
                if(item == '#')
                {
                    Matrix.Add(Instantiate(Cube2,Pos,Angle));
                }
                if(item == '.')
                {
                    Matrix.Add(Instantiate(Cube1,Pos,Angle));
                }
                Pos[0] += (float)0.2001;
            }
            Pos[0] = (float)-7;
            Pos[1] -= (float)0.25;

        }
    }
    private void DestroyMatrix()
    {
        foreach(var z in this.Matrix)
        {
            Destroy(z);
        }
    }
}
