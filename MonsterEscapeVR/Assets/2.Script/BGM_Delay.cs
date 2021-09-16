using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Delay : MonoBehaviour
{
    AudioSource bm;
    float count;
    bool isPlay;
    void Start()
    {
        bm = this.gameObject.GetComponent<AudioSource>();
        bm.Stop();
        isPlay = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if(count >= 3 && isPlay == false )
        {
            bm.Play();
            isPlay = true;
        }

        
    }
}
