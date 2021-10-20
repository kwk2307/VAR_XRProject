using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinDive : MonoBehaviour
{
    float time;
    bool start = false;
    public Animator ani;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(start == true)
        {
            time += Time.deltaTime;
            if (time > 2.5f)
            {
                this.transform.Translate(0, -0.05f, 0.01f);
            }

        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Æë±Ï ´ÙÀÌºù ¹ßµ¿!");
        start = true;
        ani.SetBool("DiveStart", true);
    }
}
