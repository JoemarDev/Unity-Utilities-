using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastVR : MonoBehaviour
{

    public Camera vrHeadSet;
    [SerializeField] float distanceOfRay = 3f;
    Ray ray;
    RaycastHit hitObject;
   
  
    void Update()
    {
        ray = new Ray(transform.position, vrHeadSet.transform.forward);
        Debug.DrawRay(  transform.localPosition, vrHeadSet.transform.forward ,Color.red);

        if (Physics.Raycast(ray, out hitObject, 3f))
        {
            //tag objects in inspector
            if (hitObject.collider.tag == "house")
            {
                Debug.Log("hi");
            }
        }
    }
}
