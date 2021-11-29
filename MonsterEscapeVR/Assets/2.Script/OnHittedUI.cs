using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHittedUI : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MiniEnemy")
        {
            StartCoroutine(GameObject.Find("UIMng").GetComponent<UIMng>().HittedUI());
        } 
    }
}
