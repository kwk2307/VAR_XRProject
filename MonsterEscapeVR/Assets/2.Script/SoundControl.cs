using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    AudioSource sharkNoise; //��� �����Ҹ�

    void Start()
    {
        sharkNoise = GameObject.Find("SharkNoise").GetComponent<AudioSource>(); //��� �����Ҹ�
        
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
