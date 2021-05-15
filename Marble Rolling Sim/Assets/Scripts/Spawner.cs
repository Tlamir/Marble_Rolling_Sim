using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject marble;
    public int numberToSpawn;
    public int limit = 20;
    public float rate;

    float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = rate;
    }

    // Update is called once per frame
    void Update()
    {
        
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                for (int i = 0; i < numberToSpawn; i++)
                {
                    Instantiate(marble, new Vector3(this.transform.position.x, this.transform.position.y)
                        , Quaternion.identity);
                }
                spawnTimer = rate;
            }
        
    }

    
}
