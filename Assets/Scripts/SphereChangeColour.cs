using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereChangeColour : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere")){
            other.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
    }

    

}
