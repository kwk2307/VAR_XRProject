using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroManager : MonoBehaviour
{
    public float distance = 110;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Enemy")
        {
            print(other.transform.name + " ¸¦ µÚ·Îº¸³¿");
            other.transform.position -= Vector3.forward * distance;
        }
        else
        {
            print("hit");
        }
    }

}
