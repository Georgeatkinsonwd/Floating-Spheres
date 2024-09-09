using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RayCastChangeColour : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    RaycastHit hitInfo;
    public GameObject hitObject;
    public Material defaultMaterial;
    public Material hitMaterial;
    
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
       if(Physics.Raycast(ray, out hitInfo, 600f, layerMask))
        {
            GameObject hitSphere = hitInfo.transform.gameObject;

            if(hitSphere != null)
            {
                Renderer selectedHitSphere = hitInfo.transform.GetComponent<Renderer>();
                selectedHitSphere.material = hitMaterial;
                hitObject = hitInfo.transform.gameObject;
            }
         
           // hitInfo.collider.gameObject.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
        }
        else
        {
           Debug.Log("hit nothing");
            if(hitObject != null)
            {
                Renderer hitObjectRenderer = hitObject.transform.GetComponent<Renderer>();
                hitObjectRenderer.material = defaultMaterial;
                hitObject = null;
            }
        }
    }
}
