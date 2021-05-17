using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public bool ballDropped=false;
    public GameObject SpawnerA;
    public GameObject SpawnerB;
    public GameObject Marble;
    public GameObject R1;
    public GameObject R2;
    public GameObject R3;
    public List<States> stateList = new List<States>();
    Vector3 r1VectorRigth;
    Vector3 r2VectorRigth;
    Vector3 r3VectorRigth;
    Vector3 r1VectorLeft;
    Vector3 r2VectorLeft;
    Vector3 r3VectorLeft;
    string r1;
    string r2;
    string r3;

    void Start()
    {
        ReadXml();
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
            ChangeGates("A");
        }
        
    }

    public void ButtonClickB()
    {
        if (!ballDropped)
        {
            Instantiate(Marble, new Vector3(SpawnerB.transform.position.x, SpawnerB.transform.position.y)
                       , Quaternion.identity);
            ballDropped = true;
            ChangeGates("B");
        }
       
    }

    public void ChangeGates(string Gate)
    {
        //Right 0 values
        r1VectorRigth= new Vector3(0.0f, 0.0f, 125);
        r2VectorRigth = new Vector3(0.0f, 0.0f, 120);
        r3VectorRigth = new Vector3(0.0f, 0.0f, 129);
        //Left 1 values
        r1VectorLeft = new Vector3(0.0f, 0.0f, 228);
        r2VectorLeft = new Vector3(0.0f, 0.0f, 59);
        r3VectorLeft = new Vector3(0.0f, 0.0f, 45);
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
            if (r1==state.getr1 && r2 == state.getr2 && r3 == state.getr3 && Gate==state.getAB )
            {
                //Set r1,r2,r3 Response
                //R1 = state.response.R1;
            }
        }


        //Get gates current angles 
        //R1 0-->125 | 1-->228
        //R2 0-->120 | 1-->59
        //R3 0-->129 | 1-->45
        // Vector3 r1 = R1.transform.localRotation.eulerAngles;
        // Vector3 r2 = R2.transform.localRotation.eulerAngles;
        // Vector3 r3 = R3.transform.localRotation.eulerAngles;
        
    }

    public void ReadXml()
    {
        XDocument xDoc = XDocument.Load(@"data/wOdataset.xml");
        XElement rootElement = xDoc.Root;
        foreach (XElement State in rootElement.Elements())
        {

            States tempState = new States(State.Element("AB").Value, State.Element("r1").Value, State.Element("r2").Value,
                State.Element("r3").Value, State.Element("result").Value);
            //Debug.Log(tempState.AB);
            //Debug.Log(State.Element("r1").Value);
            stateList.Add(tempState);
        }

        
    }
}
