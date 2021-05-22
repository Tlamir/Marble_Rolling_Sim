using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class ButtonClick : MonoBehaviour
{
    public float delayTime = 5.0f;
    private bool gatesChanged = true;
    public GameObject SpawnerA;
    public GameObject SpawnerB;
    public GameObject Marble;
    public GameObject R1;
    public GameObject R2;
    public GameObject R3;
    public Text scoreText;
    private int score=0;
    public List<States> stateList = new List<States>();
    Vector3 r1VectorRight;
    Vector3 r2VectorRight;
    Vector3 r3VectorRight;
    Vector3 r1VectorLeft;
    Vector3 r2VectorLeft;
    Vector3 r3VectorLeft;
    public float waitTime = 3.0f;



    string r1;
    string r2;
    string r3;
    string result = "r";

    void Start()
    {
        
        ReadXml();
        //Right 0 values
        r1VectorRight = new Vector3(0.0f, 0.0f, 125);
        r2VectorRight = new Vector3(0.0f, 0.0f, 120);
        r3VectorRight = new Vector3(0.0f, 0.0f, 125);
        //Left 1 values
        r1VectorLeft = new Vector3(0.0f, 0.0f, 228);
        r2VectorLeft = new Vector3(0.0f, 0.0f, 59);
        r3VectorLeft = new Vector3(0.0f, 0.0f, 45);

    }
    public void ResetScene()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void RetunMenu()
    {
        SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
    }

    public void ButtonClickA()
    {
        if (gatesChanged)
        {
            Instantiate(Marble, new Vector3(SpawnerA.transform.position.x, SpawnerA.transform.position.y)
                        , Quaternion.identity);
            gatesChanged = false;

            StartCoroutine(ChangeGates("A"));

        }
        
    }

    public void ButtonClickB()
    {
        if (gatesChanged)
        {
            Instantiate(Marble, new Vector3(SpawnerB.transform.position.x, SpawnerB.transform.position.y)
                       , Quaternion.identity);
            gatesChanged = false;
            StartCoroutine(ChangeGates("B"));
        }
        
    }

    public IEnumerator ChangeGates(string Gate)
    {

        //Get gates current angles 
        //R1 0-->125 | 1-->228
        //R2 0-->120 | 1-->59
        //R3 0-->129 | 1-->45

        //R1
        if (R1.transform.localRotation.eulerAngles == r1VectorRight)
            r1 = "0";
        else
            r1 = "1";
        //R2
        if (R2.transform.localRotation.eulerAngles == r2VectorRight)
            r2 = "0";
        else
            r2 = "1";
        //R3
        if (R3.transform.localRotation.eulerAngles == r3VectorRight)
            r3 = "0";
        else
            r3 = "1";

        foreach (var state in stateList)
        {
            
            // GameObject R!,R2 nad R3 must be converted from GameObject to string 
            if (String.Equals(Gate,"A"))
            {
                if (String.Equals(r1, state.R1) && String.Equals(r2, state.R2) && String.Equals(r3, state.R3) && String.Equals(result,state.Result))
                {
                    //Ball dropped from A
                    
                    yield return new WaitForSeconds(waitTime);
                    SetR1(state.AR1);
                    SetR2(state.AR2);
                    SetR3(state.AR3);
                    result = state.AResult;
                    gatesChanged = true;

                    if (String.Equals(state.AResult,"a"))
                        scoreText.text = (score+=10).ToString();
                    break;

                }
            }
            else
            {
                if (String.Equals(r1, state.R1) && String.Equals(r2, state.R2) && String.Equals(r3, state.R3) && String.Equals(result, state.Result))
                {
                    //Ball dropped from B
                    
                    yield return new WaitForSeconds(waitTime);
                    SetR1(state.BR1);
                    SetR2(state.BR2);
                    SetR3(state.BR3);
                    result = state.BResult;
                    gatesChanged = true;
                    if (String.Equals(state.BResult, "a"))
                        scoreText.text = (score += 10).ToString();
                    break;
                }
            } 
        }
    }

  

    public void SetR1(string r1)
    {
        if (String.Equals(r1, "0"))
            R1.transform.eulerAngles = r1VectorRight;
        else
            R1.transform.eulerAngles = r1VectorLeft;
    }
    public void SetR2(string r2)
    {
        if (String.Equals(r2, "0"))
            R2.transform.eulerAngles = r2VectorRight;
        else
            R2.transform.eulerAngles = r2VectorLeft;
    }
    public void SetR3(string r3)
    {
        if (String.Equals(r3, "0"))
            R3.transform.eulerAngles = r3VectorRight;
        else
            R3.transform.eulerAngles = r3VectorLeft;
    }


    public void ReadXml()
    {
        XDocument xDoc = XDocument.Load(@"data/DfaTable.xml");
        XElement rootElement = xDoc.Root;
        foreach (XElement State in rootElement.Elements())
        {
            States tempState = new States();
            tempState.R1 = State.Element("r1").Value;
            tempState.R2 = State.Element("r2").Value;
            tempState.R3 = State.Element("r3").Value;      
            tempState.Result = State.Element("result").Value;

            foreach (XElement stateA  in State.Elements("responseA"))
            {           
                tempState.AR1 = stateA.Element("aR1").Value;
                tempState.AR2 = stateA.Element("aR2").Value;
                tempState.AR3 = stateA.Element("aR3").Value;
                tempState.AResult = stateA.Element("aResult").Value;
            }

            foreach (XElement stateB in State.Elements("responseB"))
            {
                tempState.BR1 = stateB.Element("bR1").Value;
                tempState.BR2 = stateB.Element("bR2").Value;
                tempState.BR3 = stateB.Element("bR3").Value;
                tempState.BResult = stateB.Element("bResult").Value;
            }
            stateList.Add(tempState);
        }
    }
}
