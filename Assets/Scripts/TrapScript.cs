using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapScript : MonoBehaviour
{
    
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("test");
        Destroy(collider.gameObject);
    }
    
}
