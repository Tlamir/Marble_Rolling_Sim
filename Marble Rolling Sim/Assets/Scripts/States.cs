using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States
{
    private string AB;
    private string r1;
    private string r2;
    private string r3;
    private string result;

    public States(string AB, string r1, string r2, string r3, string result)
    {
        this.AB = AB;
        this.r1 = r1;
        this.r2 = r2;
        this.r3 = r3;
        this.result = result;
    }

    public string getAB { get => AB; set => AB = value; }

    public string getr1 { get => r1; set => r1 = value; }

    public string getr2 { get => r2; set => r2 = value; }

    public string getr3 { get => r3; set => r3 = value; }

    public string getresult { get => result; set => result = value; }


}
