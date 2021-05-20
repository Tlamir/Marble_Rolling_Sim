using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Marble : MonoBehaviour
{
    public bool marbleDeleted = false;

 
    void OnBecameInvisible()
    {
        Destroy(gameObject);
        marbleDeleted = true;
    }
}
