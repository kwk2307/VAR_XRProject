using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroManager : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        print("¿ÀºêÁ§Æ®°¡ ºÎµúÈû");
        other.transform.position -= Vector3.forward * 110;
    }

}
