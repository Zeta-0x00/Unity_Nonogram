using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
class READER
{
    #region Properties
    private Dictionary<int, String> Keys = new Dictionary<int, string>();
    private string[] text;
    private string path;
    private int x, y;
    private List<string> linesY = new List<string>();
    private List<string> linesX = new List<string>();
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

    public READER(string texto)
    {
        path = texto;
        StartDictionary();
        Refactor();
    }

    private void Refactor()
    {
        text = System.IO.File.ReadAllText(path).Split('\n');
        Asing();
    }
    private void Asing()
    {
        int a = 0;
        foreach (var v in text[0])
        {
            if (v.Equals(','))
            {
                this.x = a;
                a = 0;
            }
            if (char.IsDigit(v))
            {
                a = (a * 10) + (int)(v - '0');
            }
        }
        this.y = a;
        for (int i = 2; i <= this.x + 1; i++)
        {
            int acum = 0;
            string line = "";
            foreach (var z in text[i])
            {
                if (z.Equals(','))
                {
                    line = line + this.Keys[acum];
                    acum = 0;
                }
                if (char.IsDigit(z))
                {
                    acum = (acum * 10) + (int)(z - '0');
                }
            }
            line = line + this.Keys[acum];
            acum = 0;
            linesX.Add(line);
        }
        int c = x + 3;
        while (c < text.Length)
        {
            int acum = 0;
            string line = "";
            foreach (var z in text[c])
            {
                if (z.Equals(','))
                {
                    line = line + this.Keys[acum];
                    acum = 0;
                }
                if (char.IsDigit(z))
                {
                    acum = (acum * 10) + (int)(z - '0');
                }
            }
            line = line + this.Keys[acum];
            acum = 0;
            linesY.Add(line);
            c++;
        }
    }
    public List<List<string>> GetData()
    {
        List<List<string>> d = new List<List<string>>();
        d.Add(linesX);
        d.Add(linesY);
        return d;
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