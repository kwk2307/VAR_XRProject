using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDistance : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 f_pos;
    private Vector3 pos;

    
    private void Start()
    {
        f_pos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = player.transform.position;

        GameMng.Instance.currentdistance += pos.z - f_pos.z;
        GameMng.Instance.currentspeed = player.GetComponent<Rigidbody>().velocity.magnitude;

        UIMng.Instance.update_distance();
        UIMng.Instance.update_speed();

        f_pos = pos;
    }
}
