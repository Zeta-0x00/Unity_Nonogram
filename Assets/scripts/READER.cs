using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class READER
{
  #region Properties
    private string path;
    private string[] text;
    private int x, y;
    private Dictionary<int, String> Keys = new Dictionary<int, string>();
    private List<List<int>> NX = new List<List<int>>();
    private List<List<int>> NY = new List<List<int>>();
    #endregion

    #region Methods
    private void StartDictionary()
    {
        this.Keys.Add(1, "A");
        this.Keys.Add(2, "B");
        this.Keys.Add(3, "C");
        this.Keys.Add(4, "D");
        this.Keys.Add(5, "E");
        this.Keys.Add(6, "F");
        this.Keys.Add(7, "G");
        this.Keys.Add(8, "H");
        this.Keys.Add(9, "I");
        this.Keys.Add(10, "J");
        this.Keys.Add(11, "K");
        this.Keys.Add(12, "L");
        this.Keys.Add(13, "M");
        this.Keys.Add(14, "N");
        this.Keys.Add(15, "O");
        this.Keys.Add(16, "P");
        this.Keys.Add(17, "Q");
        this.Keys.Add(18, "R");
        this.Keys.Add(19, "S");
        this.Keys.Add(20, "T");
        this.Keys.Add(21, "U");
        this.Keys.Add(22, "V");
        this.Keys.Add(23, "W");
        this.Keys.Add(24, "X");
        this.Keys.Add(25, "Y");
        this.Keys.Add(26, "Z");
    }

    public READER(string rute)
    {
        this.path = rute;
        this.Refactor();
        this.StartDictionary();
    }
    public Dictionary<int, String> GetDic()
    {
        return this.Keys;
    }
    public string GetPath()
    {
        return this.path;
    }
    public void SetPath(string newpath)
    {
        this.path = newpath;
    }
    public void Refactor()
    {
        this.text = System.IO.File.ReadAllText(path).Split('\n');
        this.Asing();
    }
    private void Asing()
    {
        bool flag = false;
        foreach (var z in this.text[0])
        {
            if (char.IsDigit(z) && !flag)
            {
                this.x = (this.x * 10) + (int)(z - '0');
            }
            if (!char.IsDigit(z))
            {
                flag = true;
            }
            if (char.IsDigit(z) && flag)
            {
                this.y = (this.y * 10) + (int)(z - '0');
            }
        }
        this.Castter();
    }
    private void Castter()
    {
        int aux = 0;
        for (int i = 2; i <= x + 1; i++)
        {
            List<int> m = new List<int>();

            foreach (var z in this.text[i])
            {
                if (char.IsDigit(z))
                {
                    aux = (aux * 10) + (int)(z - '0');
                }
                if (!aux.Equals(0))
                {
                    m.Add(aux);
                    aux = 0;
                }
            }
            m.Add(aux);
            aux = 0;
            this.NX.Add(m);
        }

        for (int i = x + 3; i < this.text.Length; i++)
        {
            List<int> m = new List<int>();
            foreach (var z in this.text[i])
            {
                if (char.IsDigit(z))
                {
                    aux = (aux * 10) + (int)(z - '0');
                }
                if (!aux.Equals(0))
                {
                    m.Add(aux);
                    aux = 0;
                }
            }
            m.Add(aux);
            aux = 0;
            this.NY.Add(m);
        }


    }
    public String[] GetData()
    {
        String axisX = "";
        String axisY = "";
        for(int z =0; z<this.NX.Count; z++)
        {
            foreach (int v in NX[z])
            {
                if (!v.Equals(0))
                {
                    axisX += this.Keys[v];
                }
            }
            if(z < this.NX.Count-1)
            {
                axisX += " ";
            }
            
        }
        for(int z=0; z<this.NY.Count; z++)
        {
            foreach (int v in NY[z])
            {
                if (!v.Equals(0))
                {
                    axisY += this.Keys[v];
                }
            }
            if (z < this.NY.Count - 1)
            {
                axisY += " ";
            }
        }
        String[] k = { axisX, axisY };
        return k;
    }
    public string ToHex(String T)
    {
        //Method to debug Hexa
        var sb = new StringBuilder();
        var bytes = Encoding.Unicode.GetBytes(T);
        foreach (var t in bytes)
        {
            sb.Append(t.ToString("X2"));
        }
        return sb.ToString();
    }
    #endregion
}
