using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroManager : MonoBehaviour
{
    public float distance = 110;
    public float delayTime = 0f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Enemy")
        {
            print(other.transform.name + " ¸¦ µÚ·Îº¸³¿");
            other.transform.position -= new Vector3()
        }
        else
        {
            print("hit");
        }
    }

}
