using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Marble : MonoBehaviour
{

 
    void OnBecameInvisible()
    {
        Destroy(gameObject);
        
    }

}
