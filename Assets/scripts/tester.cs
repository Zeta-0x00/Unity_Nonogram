using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
//using System.Threading;

public class tester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        READER reader = new READER("C:/Users/Zeta/Documents/TestFile.txt");
        String[] Da = reader.GetData();
        Debug.Log(Da[0]);
        Debug.Log(Da[1]);
        //Stopwatch = reloj = new Stopwatch();
        //reloj.Start();
        Debug.Log("\n"+Nonogram.Solve(Da[0],Da[1]));
        //reloj.Stop();
        //Debug.Log(reloj.Elapsed);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
