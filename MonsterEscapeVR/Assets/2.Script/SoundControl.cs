using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    AudioSource sharkNoise; //상어 울음소리

    void Start()
    {
        sharkNoise = GameObject.Find("SharkNoise").GetComponent<AudioSource>(); //상어 울음소리
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlaySharkNoise()
    {
        sharkNoise.Play();
    }


}
