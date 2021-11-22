using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinMove : MonoBehaviour
{
    public Animator ani; //Æë±Ï ¾Ö´Ï¸ÅÀÌÅÍ
    float random;
    bool enter = false;
    void Start()
    {
        random = UnityEngine.Random.Range(0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (enter == false)
        {
            if (random >= 8)
            {
                enter = true;
                StartCoroutine(Grooming());
                

            }
            else if(random >= 6)
            {
                enter = true;
                StartCoroutine(Flap());
                
            }
            else if(random >= 4)
            {
                enter = true;
                StartCoroutine(Walk());
            }
            else 
            {
                enter = true;
                StartCoroutine(TurnR());
            }
        }
        




        
    }

    IEnumerator Grooming()
    {
        ani.SetBool("Grooming", true);
        yield return new WaitForSeconds(3f);
        ani.SetBool("Grooming", false);
        random = UnityEngine.Random.Range(0f, 10f);
        enter = false;
    }
    IEnumerator Flap()
    {
        ani.SetBool("Flap", true);
        yield return new WaitForSeconds(3f);
        ani.SetBool("Flap", false);
        random = UnityEngine.Random.Range(0f, 10f);

        enter = false;
    }
    IEnumerator Walk()
    {
        ani.SetBool("Walk", true);
        yield return new WaitForSeconds(3f);
        ani.SetBool("Walk", false);
        random = UnityEngine.Random.Range(0f, 10f);

        enter = false;
    }
    IEnumerator TurnR()
    {
        ani.SetBool("TurnR", true);
        yield return new WaitForSeconds(3f);
        ani.SetBool("TurnR", false);
        random = UnityEngine.Random.Range(0f, 10f);

        enter = false;
    }
}
