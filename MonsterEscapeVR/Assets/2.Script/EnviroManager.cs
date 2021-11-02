using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroManager : MonoBehaviour
{
    public float distance = 110;
    public float delayTime = 0f;
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Enemy")
        {
            other.transform.position -= Vector3.forward * distance;
            //Instantiate(other);
            //Destroy(other.gameObject);
        }
        else
        {

        }
    }

}
