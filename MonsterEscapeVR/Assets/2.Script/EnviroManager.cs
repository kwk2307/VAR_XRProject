using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroManager : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Enemy")
        {
            print("������Ʈ�� �ε���");
            other.transform.position -= Vector3.forward * 110;
        }
        else
        {
            print("hit");
        }
    }

}
