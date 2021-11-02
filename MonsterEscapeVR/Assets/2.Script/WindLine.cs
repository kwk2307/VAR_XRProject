using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindLine : MonoBehaviour
{
    public GameObject[] wind;
    float ran;
    float num;
    void Start()
    {
        num = Random.Range(1.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(num >= 5)
        {
            wind[Random.Range(0,9)].SetActive(true);
            num = Random.Range(1.0f, 10.0f);
        }
        else
        {
            wind[Random.Range(0, 9)].SetActive(false);
            num = Random.Range(1.0f, 10.0f);
        }
    }
}
