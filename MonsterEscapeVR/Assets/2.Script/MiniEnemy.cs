using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniEnemy : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, 0.3f); //플레이어를 향해 날라간다
        this.transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time)*10f, transform.position.z);
        print(Time.time);
    }
}
