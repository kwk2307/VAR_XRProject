using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    [SerializeField] private GameObject water;
    private void OnTriggerEnter(Collider other)
    {
      
        water.transform.GetChild(9).transform.position -= new Vector3(0, 0, 100);
        water.transform.GetChild(9).SetAsFirstSibling();
        this.transform.position += new Vector3(0, 0, -10);
    }
}
