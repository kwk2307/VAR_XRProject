using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject responeZone;
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = responeZone.transform.position;
    }
}
