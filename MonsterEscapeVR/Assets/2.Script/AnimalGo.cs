using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalGo : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }

}
