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
        transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, 0.2f); //플레이어를 향해 날라간다
        this.transform.position = new Vector3(transform.position.x, Mathf.Sin(time)*9f, transform.position.z);//포물선으로 날라가게

        // 진행방향과 앞 벡터가 일치하도록
        transform.LookAt(player.transform.position);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player") //플레이어와 충돌할 경우
        {
            //스피드를 깍는다
            other.transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 5000) * Time.deltaTime);
            
            
        }


        Destroy(this.gameObject);
    }
}
