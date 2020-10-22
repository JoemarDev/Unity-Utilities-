using System;
using UnityEngine;

public class MicInput : MonoBehaviour
{
    public static float MicLoudnessPeak;
    public static float MicLoudnessRMS;

    private string _device;
    private AudioSource source;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    //mic initialization
    private void InitMic()
    {
        if (_device == null) _device = Microphone.devices[0];
        source.clip = Microphone.Start(_device, true, 999, 44100);
    }

    private void StopMicrophone()
    {
        Microphone.End(_device);
    }

    private readonly int _sampleWindow = 128; // 

    //get data from microphone into audioclip
    private void LevelMax()
    {
        float levelMax = 0;
        var waveData = new float[_sampleWindow];
        var micPosition = Microphone.GetPosition(null) - (_sampleWindow + 1); // null means the first microphone
        if (micPosition < 0) return;
        source.clip.GetData(waveData, micPosition);
        // Getting a peak on the last 128 samples
        for (var i = 0; i < _sampleWindow; i++)
        {
            var wavePeak = waveData[i] * waveData[i] ;
            if (levelMax < wavePeak) levelMax = wavePeak;
        }

        MicLoudnessPeak = levelMax;

        MicLoudnessRMS = ComputeRMS(waveData,micPosition,_sampleWindow);
        Debug.Log(MicLoudnessRMS);
    }


    private void Update()
    {
        // levelMax equals to the highest normalized value power 2, a small number because < 1
        // pass the value to a static var so we can access it from anywhere
        LevelMax();
    }

    private bool _isInitialized;

    // start mic when scene starts
    private void OnEnable()
    {
        InitMic();
        _isInitialized = true;
    }

    //stop mic when loading a new level or quit application
    private void OnDisable()
    {
        StopMicrophone();
    }

    private void OnDestroy()
    {
        StopMicrophone();
    }
    
    public float ComputeRMS(float[] buffer, int offset, int length)
    {
        // sum of squares
        var sos = 0f;
        float val;
        // if (offset + length > buffer.Length) length = buffer.Length - offset;
        for (var i = 0; i < length; i++)
        {
            val = buffer[i];
            sos += val * val;
        }

        // return sqrt of average
        return Mathf.Sqrt(sos / length);
    }

    public float ComputeDB(float[] buffer, int offset, int length)
    {
        float rms;
        rms = ComputeRMS(buffer, offset, length);
        // could divide rms by reference power, simplified version here with ref power of 1f.
        // will return negative values: 0db is the maximum.
        return 10 * Mathf.Log10(rms);
    }


    // make sure the mic gets started & stopped when application gets focused
    private void OnApplicationFocus(bool focus)
    {
        if (focus)
            //Debug.Log("Focus");

            if (!_isInitialized)
            {
                //Debug.Log("Init Mic");
                InitMic();
                _isInitialized = true;
            }

        if (!focus)
        {
            //Debug.Log("Pause");
            StopMicrophone();
            //Debug.Log("Stop Mic");
            _isInitialized = false;
        }
    }
    
    private void OnGUI()
    {
        // No microphone  
        if (!_isInitialized)
        {
            //Print a red "Microphone not connected!" message at the center of the screen  
            GUI.contentColor = Color.red;
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 50), "Microphone not connected!");
        }
    }
}