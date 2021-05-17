using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject marble;
    // Start is called before the first frame update
    void Start()
    {
        /*Instantiate(marble, new Vector3(this.transform.position.x, this.transform.position.y)
                       , Quaternion.identity);*/
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void Spawnxx()
    {
        Instantiate(marble, new Vector3(this.transform.position.x, this.transform.position.y)
                        , Quaternion.identity);
    }

    
}
