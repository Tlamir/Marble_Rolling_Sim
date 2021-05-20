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
    public bool ballDropped=false;
    public GameObject SpawnerA;
    public GameObject SpawnerB;
    public GameObject Marble;
    public GameObject R1;
    public GameObject R2;
    public GameObject R3;
    public Text scoreText;
    private int score=0;
    public List<States> stateList = new List<States>();
    Vector3 r1VectorRigth;
    Vector3 r2VectorRigth;
    Vector3 r3VectorRigth;
    Vector3 r1VectorLeft;
    Vector3 r2VectorLeft;
    Vector3 r3VectorLeft;
    public float waitTime = 3.0f;



    string r1;
    string r2;
    string r3;

    void Start()
    {
        
        ReadXml();
        //Right 0 values
        r1VectorRigth = new Vector3(0.0f, 0.0f, 125);
        r2VectorRigth = new Vector3(0.0f, 0.0f, 120);
        r3VectorRigth = new Vector3(0.0f, 0.0f, 125);
        //Left 1 values
        r1VectorLeft = new Vector3(0.0f, 0.0f, 228);
        r2VectorLeft = new Vector3(0.0f, 0.0f, 59);
        r3VectorLeft = new Vector3(0.0f, 0.0f, 45);

    }
    public void ResetScene()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void ButtonClickA()
    {
        if (!ballDropped)
        {
            Instantiate(Marble, new Vector3(SpawnerA.transform.position.x, SpawnerA.transform.position.y)
                        , Quaternion.identity);
            ballDropped = true;
            StartCoroutine(ChangeGates("A"));

        }
        
    }

    public void ButtonClickB()
    {
        if (!ballDropped)
        {
            Instantiate(Marble, new Vector3(SpawnerB.transform.position.x, SpawnerB.transform.position.y)
                       , Quaternion.identity);
            ballDropped = true;
            StartCoroutine(ChangeGates("B"));
        }
       
    }

    public IEnumerator ChangeGates(string Gate)
    {
        
        //Get Current rotation values
        //R1
        if (R1.transform.localRotation.eulerAngles == r1VectorRigth)
            r1 = "0";
        else
            r1 = "1";
        //R2
        if (R2.transform.localRotation.eulerAngles == r2VectorRigth)
            r2 = "0";
        else
            r2 = "1";
        //R3
        if (R3.transform.localRotation.eulerAngles == r3VectorRigth)
            r3 = "0";
        else
            r3 = "1";

        foreach (var state in stateList)
        {
            
            // GameObject R!,R2 nad R3 must be converted from GameObject to string 
            if (String.Equals(Gate,"A"))
            {
                Debug.Log(R3.transform.localRotation.eulerAngles);
                Debug.Log(r3VectorRigth);
                Debug.Log("Yarak");
                Debug.Log(r1);
                Debug.Log(r2);
                Debug.Log(r3);


                if (String.Equals(r1, state.R1) && String.Equals(r2, state.R2) && String.Equals(r3, state.R3))
                {
                    Debug.Log("xxxxxxxxxxxx");

                    //Ball dropped from A
                    //Set ar1,ar2,ar3 Response
                    //R1 = state.response.R1;
                    yield return new WaitForSeconds(waitTime);
                    SetR1(state.AR1);
                    SetR2(state.AR2);
                    SetR3(state.AR3);
                    if (String.Equals(state.AResult,"a"))
                        scoreText.text = (score+=10).ToString();
                    ballDropped = false;
                }
            }
            else
            {
                if (String.Equals(r1, state.R1) && String.Equals(r2, state.R2) && String.Equals(r3, state.R3))
                {
                    //Ball dropped from B
                    //Set br1,br2,br3 Response
                    //R1 = state.response.R1;
                    yield return new WaitForSeconds(waitTime);
                    SetR1(state.BR1);
                    SetR2(state.BR2);
                    SetR3(state.BR3);
                    if (String.Equals(state.BResult, "a"))
                        scoreText.text = (score += 10).ToString();
                    ballDropped = false;
                }
            }
         
        }




        //Get gates current angles 
        //R1 0-->125 | 1-->228
        //R2 0-->120 | 1-->59
        //R3 0-->129 | 1-->45

        
    }

  

    public void SetR1(string r1)
    {
        if (String.Equals(r1, "0"))
        {

            R1.transform.eulerAngles = r1VectorRigth;
        }
        else
        {
            R1.transform.eulerAngles = r1VectorLeft;
        }
    }
    public void SetR2(string r2)
    {
        if (String.Equals(r2, "0"))
        {
            R2.transform.eulerAngles = r2VectorRigth;
        }
        else
        {
            R2.transform.eulerAngles = r2VectorLeft;
        }
    }
    public void SetR3(string r3)
    {
        if (String.Equals(r3, "0"))
        {
            R3.transform.eulerAngles = r3VectorRigth;
        }
        else
        {
            R3.transform.eulerAngles = r3VectorLeft;
        }
    }


    public void ReadXml()
    {
        XDocument xDoc = XDocument.Load(@"data/newXML.xml");
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
