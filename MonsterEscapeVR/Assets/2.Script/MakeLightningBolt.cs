using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeLightningBolt : MonoBehaviour
{
    float num;
    

    LineRenderer render;
    void Start()
    {

        render = GetComponent<LineRenderer>();
        InvokeRepeating("BoltOn", 0, 3);
        InvokeRepeating("BoltOff", 1, 3);

    }

    // Update is called once per frame
    void Update()
    {

    }


    void BoltOn()
    {
        num += Time.deltaTime;
        print(num);
        if(num > Random.Range(0, 1))
        {
            render.enabled = true;

        }
    
    

     }
    void BoltOff()
    {
        render.enabled = false;
        num -= Time.deltaTime;

    }



}
