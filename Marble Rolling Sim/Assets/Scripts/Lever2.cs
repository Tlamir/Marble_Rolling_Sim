using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever2 : MonoBehaviour
{
    float rate=3.0f;
    float rotateTimer;
    bool rotate=false;
    // Start is called before the first frame update
    void Start()
    {
        rotateTimer = rate;
    }

    // Update is called once per frame
    void Update()
    {
        rotateTimer -= Time.deltaTime;
        if (rotateTimer <= 0f)
        {
            if (rotate)
            {
                transform.Rotate(0, 0, 61);
                rotate = false;
            }
            else
            {
                transform.Rotate(0, 0, -61);
                rotate = true;
            }
            rotateTimer = rate;
        }
    }
}
