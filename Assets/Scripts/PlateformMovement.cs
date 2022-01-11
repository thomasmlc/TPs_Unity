using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformMovement : MonoBehaviour
{
    public float rotationSpeed = 15;
    
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.forward * -horizontalAxis * Time.deltaTime * rotationSpeed);
        transform.Rotate(Vector3.right * verticalAxis * Time.deltaTime * rotationSpeed);
    }
}
