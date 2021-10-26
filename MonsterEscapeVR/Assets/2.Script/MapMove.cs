using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    [SerializeField] private GameObject water;
    private void OnTriggerEnter(Collider other)
    {
        water.transform.GetChild(13).transform.position -= new Vector3(0, 0, 140);
        water.transform.GetChild(13).SetAsFirstSibling();
        this.transform.position += new Vector3(0, 0, -10);
    }
}
