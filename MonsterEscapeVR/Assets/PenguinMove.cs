using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinMove : MonoBehaviour
{
    public Animator ani; //Æë±Ï ¾Ö´Ï¸ÅÀÌÅÍ
    float random;
    void Start()
    {
        random = UnityEngine.Random.Range(0f, 10f);
        print(random);
    }

    // Update is called once per frame
    void Update()
    {
        if(random >= 6)
        {
            ani.SetBool("Grooming", true);
        }
        else
        {

        }




        
    }
}
