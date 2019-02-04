using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleObjectFader : MonoBehaviour
{
    public GameObject objectToFade;
    [SerializeField] float fadeTransition;
    [SerializeField] float timeWhenObjectAppears;
    [SerializeField] float timeWhenObjectDissappers;

    bool objectHasAppeared = false;

    void Start()
    {
        objectToFade.GetComponent<MeshRenderer>().material.color = new Color(0f, 0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > timeWhenObjectAppears && !objectHasAppeared)
        {
            ObjectAppeared();


        }
        if (Time.timeSinceLevelLoad > timeWhenObjectDissappers)
        {
            objectHasAppeared = true;
            ObjectDissAppeared();
        }
    }

    void ObjectAppeared()
    {

        Color visable = new Color(1f, 1f, 1f, 1f);

        objectToFade.GetComponent<MeshRenderer>().material.color =
            Color.Lerp(objectToFade.GetComponent<MeshRenderer>().material.color, visable, fadeTransition * Time.deltaTime);


    }
    void ObjectDissAppeared()
    {
        Color invisable = new Color(0f, 0f, 0f, 0f);

        objectToFade.GetComponent<MeshRenderer>().material.color =
        Color.Lerp(objectToFade.GetComponent<MeshRenderer>().material.color, invisable, fadeTransition * Time.deltaTime);

    }

}

