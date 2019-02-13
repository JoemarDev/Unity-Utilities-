using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistantAudio : MonoBehaviour {

    public Transform player;
    AudioSource sound;
    [SerializeField] float distanceOfAudio = 50;
    // Use this for initialization
    void Start()
    {
        sound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!player) return;
        var d = Vector3.Distance(player.position, transform.position);
        Debug.Log(d);
        
       
        sound.volume = Map(d, 0, distanceOfAudio, 1, -1);
        Debug.Log(sound.volume);
    }

    public  float Map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }
}
