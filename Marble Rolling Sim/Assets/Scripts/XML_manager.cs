using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization; //Needed for XML Functionality
using System.IO;


public class XML_manager : MonoBehaviour
{
    public GameObject r1;
    public GameObject r2;
    public GameObject r3;
    public GameObject SpawnerA;
    public GameObject SpawnerB;
    public GameObject marble;
    string tmp;
    public float delayTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoopFunction(delayTime));

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private IEnumerator LoopFunction(float waitTime)
    {
        XmlTextReader xtr = new XmlTextReader("/Users/Tlamir/Documents/GitHub/Marble_Rolling_Sim/Marble Rolling Sim/Assets/Xml/wOdataset.xml");
        while (xtr.Read())
        {
            if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "AB")
            {
                tmp = xtr.ReadString();
                if (string.Equals(tmp, "A"))
                {
                    //Drop ball from A gate 
                    Debug.Log("Drop ball from A gate");
                    Instantiate(marble, new Vector3(SpawnerA.transform.position.x, SpawnerA.transform.position.y)
                        , Quaternion.identity);
                }
                else
                {
                    //Drop ball from B gate
                    Debug.Log("Drop ball from B gate");
                    Instantiate(marble, new Vector3(SpawnerB.transform.position.x, SpawnerB.transform.position.y)
                        , Quaternion.identity);
                }
            }
            if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "r1")
            {
                tmp = xtr.ReadString();
                if (string.Equals(tmp, "1"))
                {
                    //Gate lean towards left
                    r1.transform.rotation = Quaternion.Euler(0, 0, 228);
                    Debug.Log("r1:sol Yatirildi");
                }
                else
                {
                    //Gate lean towards right
                    r1.transform.rotation = Quaternion.Euler(0, 0, 125);
                    Debug.Log("r1:sagaa Yatirildi");
                }
            }
            if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "r2")
            {
                tmp = xtr.ReadString();
                if (string.Equals(tmp, "1"))
                {
                    //Gate lean towards left
                    r2.transform.rotation = Quaternion.Euler(0, 0, 59);
                    Debug.Log("r2:sol Yatirildi");
                }
                else
                {
                    //Gate lean towards right
                    r2.transform.rotation = Quaternion.Euler(0, 0, 120);
                    Debug.Log("r2:sagaa Yatirildi");
                }
            }
            if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "r3")
            {
                tmp = xtr.ReadString();
                if (string.Equals(tmp, "1"))
                {
                    //Gate lean towards left
                    r3.transform.rotation = Quaternion.Euler(0, 0, 45);
                    Debug.Log("r3:sol Yatirildi");
                    yield return new WaitForSeconds(waitTime);
                }
                else
                {
                    //Gate lean towards right
                    r3.transform.rotation = Quaternion.Euler(0, 0, 129);
                    Debug.Log("r3:sagaa Yatirildi");
                    yield return new WaitForSeconds(waitTime);
                }
            }

        }

       
          
        
    }



}












