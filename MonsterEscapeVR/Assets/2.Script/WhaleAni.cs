using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleAni : MonoBehaviour
{
    public Animation ani; //고래 애니
    public AudioSource sound; //고래 소리
     public float speed;
    bool go = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(go == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ani.Play();
        sound.Play();
        go = true;
    }
}
