using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 5f;
    public float attackPower = 1f;
    

    private GameObject player; //�÷��̾ ���� ����
    void Start()
    {
        //�÷��̾ ã�Ƽ� ��´�
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        //�÷��̾ �Ѿư���.
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);

        
    }
}
