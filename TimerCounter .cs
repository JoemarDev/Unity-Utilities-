﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerCounter  : MonoBehaviour {

    [SerializeField] GameObject timer;
    public InputField userInput;

    [SerializeField]GameObject button;

    float timeUpdater;
    public float speedOfTime = 2.5f;
    long initialvalue;

    long totalTime;
    string displayCounter;
    
    private void FixedUpdate()
    {
       
        if (initialvalue > 1)
        {
           
            timeUpdater += Time.fixedDeltaTime * speedOfTime;
            print(timeUpdater);
            long roundedsecs = (long)timeUpdater;
            totalTime = initialvalue + roundedsecs;
            displayCounter = totalTime.ToString("n");

            timer.GetComponent<Text>().text = displayCounter.Remove(displayCounter.Length - 3);
            DisableFields();

        }
    }

    public void TextInputInitialValue()
    {
        initialvalue = long.Parse( userInput.text);
    }

    public void DisableFields()
    {
        button.SetActive(false);
        userInput.gameObject.SetActive(false);
        
    }

}
