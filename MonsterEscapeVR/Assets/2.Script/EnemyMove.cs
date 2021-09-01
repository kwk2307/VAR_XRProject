using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 5f;
    public float attackPower = 1f;
    

    private GameObject player; //플레이어를 담을 변수
    void Start()
    {
        //플레이어를 찾아서 담는다
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        //플레이어를 쫓아간다.
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);

        
    }
}
