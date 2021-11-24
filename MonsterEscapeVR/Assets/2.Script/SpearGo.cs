using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearGo : MonoBehaviour
{
    public GameObject target;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 2f);
    }
}
