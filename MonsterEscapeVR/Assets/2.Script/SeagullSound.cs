using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullSound : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;

    public int num;
    public float time;
    void Start()
    {
        
    }

    
    void Update()
    {
        time += Time.deltaTime;
        
        if (time > 3.0f)
        {
            num = Random.Range(1, 100);
            time = 0;
        }
        if (num > 90)
        {
            
            audioSource1.Play();
        }
        else if(num>50 && num <= 90)
        {
            
            audioSource2.Play();
        }
        else
        {
           
            audioSource3.Play();
        }
    }
}
