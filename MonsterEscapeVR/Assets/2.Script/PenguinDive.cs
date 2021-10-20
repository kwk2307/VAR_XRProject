using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinDive : MonoBehaviour
{
    float time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 2.5f)
        {
            this.transform.Translate(0,-0.05f, 0.01f);
        }
        
    }
}
