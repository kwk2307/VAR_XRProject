using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearGo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position += new Vector3(0, 5, 0); //창은 위에서부터 내려와야 하니깐
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 7);
    }
}
