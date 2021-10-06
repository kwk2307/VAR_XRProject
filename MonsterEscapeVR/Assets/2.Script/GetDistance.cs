using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDistance : MonoBehaviour
{
    [SerializeField] GameObject water;
    private Vector3 f_pos;
    private Vector3 pos;

    
    private void Start()
    {
        f_pos = water.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = water.transform.position;

        GameMng.Instance.currentdistance += pos.z - f_pos.z;
        GameMng.Instance.currentspeed = water.GetComponent<Rigidbody>().velocity.magnitude;

        UIMng.Instance.update_distance();
        UIMng.Instance.update_speed();

        f_pos = pos;
    }
}
