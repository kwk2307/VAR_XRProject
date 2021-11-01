using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDistance : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 f_pos;
    private Vector3 pos;
    private Vector3 goalPos;

    
    private void Start()
    {
        f_pos = player.transform.position;
        goalPos = GameObject.Find("EndPoint").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
 

        pos = player.transform.position;

        GameMng.Instance.currentdistance += pos.z - f_pos.z;
        GameMng.Instance.currentspeed = player.GetComponent<Rigidbody>().velocity.magnitude;

        UIMng.Instance.update_distance();

        f_pos = pos;

        GameMng.Instance.goaldistance = Vector3.Distance(goalPos, pos); // 목적지까지 남은 거리 계산
        
    }
}
