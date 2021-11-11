using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniEnemy : MonoBehaviour
{
    GameObject player;
    float time;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, 0.2f); //�÷��̾ ���� ���󰣴�
        this.transform.position = new Vector3(transform.position.x, Mathf.Sin(time)*9f, transform.position.z);//���������� ���󰡰�

        // �������� �� ���Ͱ� ��ġ�ϵ���
        transform.LookAt(player.transform.position);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player") //�÷��̾�� �浹�� ���
        {
            //���ǵ带 ��´�
            other.transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 5000) * Time.deltaTime);
            
            
        }


        Destroy(this.gameObject);
    }
}
