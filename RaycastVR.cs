using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastVR : MonoBehaviour
{

    private Camera _camera;
    public float rayRange = 4;
  
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
        Ray ray = _camera.ScreenPointToRay(point);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayRange))
        {
         
            GameObject hitObject = hit.transform.gameObject;
            //implement the below when using interfaces
            //if (hitObject.transform.GetComponent<IInteractable>() == null)
            //{
            // 
            //    return;
            //}
            //hitObject.GetComponent<IInteractable>().Interact();
            
        }

    }
}
