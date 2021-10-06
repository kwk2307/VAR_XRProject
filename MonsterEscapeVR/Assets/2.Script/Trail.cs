using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class Trail : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        float temp = GameMng.Instance.currentspeed/10;
        this.transform.localScale = new Vector3(temp, 1, temp);
    }
}
