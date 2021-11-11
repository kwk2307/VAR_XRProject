using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMinion : MonoBehaviour
{
    public GameObject minion;
    float time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > Random.Range(5.0f, 10.0f))
        {
            Instantiate(minion);
            minion.transform.position = transform.position;
            time = 0;
        }
    }
}
