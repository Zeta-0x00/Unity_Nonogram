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
    void Start()
    {
        READER reader = new READER("C:/Users/Zeta/Documents/TestFile.txt");
        String[] Da = reader.GetData();
        //UnityEngine.Debug.Log(Da[0]);
        //UnityEngine.Debug.Log(Da[1]);
        Stopwatch watch = new Stopwatch();
        watch.Start();
        string result = Nonogram.Solve(Da[0],Da[1]);
        watch.Stop();
        UnityEngine.Debug.Log("Tiempo de ejecución = "+watch.Elapsed);
        Matrix = new List<GameObject>();
        UnityEngine.Debug.Log(result);
        String[] DataSet = result.Split('\n');
        double contX = -7;
        double contY = 4;
        var Angle = Camera.main.transform.rotation;
        Vector3 Pos = new Vector3((float)contX, (float)contY, 0);
        for(int i = 0; i < DataSet.Length; i++)
        {
            foreach (var item in DataSet[i])
            {
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
