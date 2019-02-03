using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour {

    int TouchMove()
    {
        int axis = 0;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
           float centrePoint= Screen.width / 2;
            if (touch.position.x < centrePoint && touch.phase == TouchPhase.Began)
            {
                axis = -1;
            }
            if (touch.position.x > centrePoint)
            {
                axis = 1;
            }
        }
        return axis;
    }
}
