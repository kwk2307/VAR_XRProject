using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailNote : MonoBehaviour
{
    private TrailRenderer tr;
    private ParticleSystem ps;
    private void Start()
    {
        tr = this.GetComponentInChildren<TrailRenderer>();
        ps = this.GetComponentInChildren<ParticleSystem>();     
    }
    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < 0)
        {
            tr.emitting = true;
            ps.Play();
        }
        else
        {
            tr.emitting = false;
            //tr.Clear();
            ps.Pause();
        }
    }
}
