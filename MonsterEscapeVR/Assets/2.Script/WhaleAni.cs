using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleAni : MonoBehaviour
{
    public Animation ani; //�� �ִ�
    public AudioSource sound; //�� �Ҹ�
     public float speed;
    bool go = false;
    float destroyTime;

    // Update is called once per frame
    void Update()
    {
        if(go == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            destroyTime += Time.deltaTime;
            if (destroyTime >= 10f)
            {
                //Destroy(this.transform);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ani.Play();
        sound.Play();
        go = true;
    }
}
