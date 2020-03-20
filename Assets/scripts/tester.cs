using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class tester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        READER reader = new READER("C:/Users/Zeta/Documents/TestFile.txt");
        String[] Da = reader.GetData();
        Debug.Log(Da[0]);
        Debug.Log(Da[1]);
        Nonogram.Solve(Da[0],Da[1]);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
