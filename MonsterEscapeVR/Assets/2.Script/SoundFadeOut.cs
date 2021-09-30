using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFadeOut : MonoBehaviour
{
    AudioSource sound;
    float time;
    void Start()
    {
        sound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 3)
        {
            StartCoroutine(FadeOut());

        }
        

    }
    IEnumerator FadeOut()
    {
        sound.volume -= Time.deltaTime;
        print(sound.volume);
        yield return 1;
    }
}
