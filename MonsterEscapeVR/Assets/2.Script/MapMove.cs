using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    [SerializeField] private GameObject water;
    private void OnTriggerEnter(Collider other)
    {
        print("hit");
        water.transform.GetChild(6).transform.position -= new Vector3(0, 0, 70);
        water.transform.GetChild(6).SetAsFirstSibling();
        this.transform.position += new Vector3(0, 0, -10);
    }
}
