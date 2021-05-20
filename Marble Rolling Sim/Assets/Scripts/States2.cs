using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public  class States2
{

    private string r1Field;

    private string r2Field;

    private string r3Field;

    private string resultField;

    private StatesStateInputGate[] inputGateField;


    public States2(string r1Field, string r2Field, string r3Field, string resultField, StatesStateInputGate[] inputGateField)
    {

        this.r1Field = r1Field;
        this.r2Field = r2Field;
        this.r3Field = r3Field;
        this.resultField = resultField;
        this.inputGateField = inputGateField;
    }

    /// <remarks/>
    public string r1
    {
        get
        {
            return this.r1Field;
        }
        set
        {
            this.r1Field = value;
        }
    }

    /// <remarks/>
    public string r2
    {
        get
        {
            return this.r2Field;
        }
        set
        {
            this.r2Field = value;
        }
    }

    /// <remarks/>
    public string r3
    {
        get
        {
            return this.r3Field;
        }
        set
        {
            this.r3Field = value;
        }
    }

    /// <remarks/>
    public string result
    {
        get
        {
            return this.resultField;
        }
        set
        {
            this.resultField = value;
        }
    }

    public StatesStateInputGate[] inputGate
    {
        get
        {
            return this.inputGateField;
        }
        set
        {
            this.inputGateField = value;
        }
    }
}


public partial class StatesStateInputGate
{

    private string resr1Field;

    private string resr2Field;

    private string resr3Field;

    private string resresultField;

    private string idField;

    public StatesStateInputGate(string resr1Field, string resr2Field, string resr3Field, string resresultField, string idField)
    {

        this.resr1Field = resr1Field;
        this.resr2Field = resr2Field;
        this.resr3Field = resr3Field;
        this.resresultField = resresultField;
        this.idField = idField;
    }

    /// <remarks/>
    public string resr1
    {
        get
        {
            return this.resr1Field;
        }
        set
        {
            this.resr1Field = value;
        }
    }

    /// <remarks/>
    public string resr2
    {
        get
        {
            return this.resr2Field;
        }
        set
        {
            this.resr2Field = value;
        }
    }

    /// <remarks/>
    public string resr3
    {
        get
        {
            return this.resr3Field;
        }
        set
        {
            this.resr3Field = value;
        }
    }

    /// <remarks/>
    public string resresult
    {
        get
        {
            return this.resresultField;
        }
        set
        {
            this.resresultField = value;
        }
    }

    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

