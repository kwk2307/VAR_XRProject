using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBoxCreate : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Vector3 dir = other.transform.position;
        dir.z -= 110;
        Instantiate(other,new Vector3(dir.x, dir.y, dir.z), Quaternion.identity);
       
    }
}
