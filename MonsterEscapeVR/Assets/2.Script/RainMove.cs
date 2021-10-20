using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainMove : MonoBehaviour
{
    [SerializeField] private GameObject rain;
    private void OnTriggerEnter(Collider other)
    {

        rain.transform.GetChild(6).GetChild(5).transform.position -= new Vector3(0, 0, -10);
        
    }
}
