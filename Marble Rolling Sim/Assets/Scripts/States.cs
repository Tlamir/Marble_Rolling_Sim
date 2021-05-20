using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States
{
    private string r1;
    private string r2;
    private string r3;
    private string result;
    private string aR1;
    private string aR2;
    private string aR3;
    private string aResult;
    private string bR1;
    private string bR2;
    private string bR3;
    private string bResult;




    public States()
    {   
    }

    public string R1 { get => r1; set => r1 = value; }
    public string R2 { get => r2; set => r2 = value; }
    public string R3 { get => r3; set => r3 = value; }
    public string Result { get => result; set => result = value; }
    public string AR1 { get => aR1; set => aR1 = value; }
    public string AR2 { get => aR2; set => aR2 = value; }
    public string AR3 { get => aR3; set => aR3 = value; }
    public string AResult { get => aResult; set => aResult = value; }
    public string BR1 { get => bR1; set => bR1 = value; }
    public string BR2 { get => bR2; set => bR2 = value; }
    public string BR3 { get => bR3; set => bR3 = value; }
    public string BResult { get => bResult; set => bResult = value; }
}

