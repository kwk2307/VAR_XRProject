using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroManager : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Enemy")
        {
            print("¿ÀºêÁ§Æ®°¡ ºÎµúÈû");
            other.transform.position -= Vector3.forward * 110;
        }
        else
        {
            print("hit");
        }
    }

}
