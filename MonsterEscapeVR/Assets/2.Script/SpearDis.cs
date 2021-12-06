using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearDis : MonoBehaviour
{
    float time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 3.2f)
        {
            Destroy(transform.gameObject);
        }
    }
}
