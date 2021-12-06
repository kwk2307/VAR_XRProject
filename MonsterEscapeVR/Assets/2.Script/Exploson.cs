using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploson : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(Distory());
    }
    IEnumerator Distory()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this);
    }
}
