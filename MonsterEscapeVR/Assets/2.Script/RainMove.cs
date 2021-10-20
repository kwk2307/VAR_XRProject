using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainMove : MonoBehaviour
{
    [SerializeField] private GameObject rain;
    private void OnTriggerEnter(Collider other)
    {
        rain.transform.position += new Vector3(0, 0, -10);        
    }
}
