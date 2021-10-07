using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailNote : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {

        float temp = GameMng.Instance.currentspeed / 30;
        this.transform.localScale = new Vector3(temp, 1, temp);

        if (this.transform.position.y < 0)
        {
            this.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            this.GetComponent<ParticleSystem>().Stop();
        }       
    }
}
