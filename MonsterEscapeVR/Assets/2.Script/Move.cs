using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    int a = 1;
    void Update()
    {
        if (transform.position.x < -39.0f)
        {
            a = -1;
        }
        else if (transform.position.x > -37.0f)
        {
            a = 1;
        }
        transform.Translate(Vector3.left * 1.0f * Time.deltaTime * a);
    }
}