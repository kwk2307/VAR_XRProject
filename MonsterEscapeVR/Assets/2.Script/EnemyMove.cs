using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 5f;
    public float attackPower = 1f;
    public float delayCount;

    private GameObject player; //플레이어를 담을 변수
    public GameObject GameOverUI; // 게임오버(실패)UI
    void Start()
    {
        //플레이어를 찾아서 담는다
        player = GameObject.Find("Player");

        Destroy(GameObject.Find("BGM")); //브금을 지운다. 모드에 맞는 브금이랑 겹치면 안되니깐
        
    }

    // Update is called once per frame
    void Update()
    {
        delayCount += Time.deltaTime;
        if (delayCount >= 3)
        {

            //플레이어를 쫓아간다.
            transform.position -= Vector3.forward * speed;


        }
    }
    // 충돌했을경우
    private void OnCollisionEnter(Collision collision)
    {
        print("충돌");
        if (collision.gameObject.name.Contains("Player"))
        {
            // 게임오버(실패) 사운드가 재생

            // 게임오버(실패) 이팩트가 실행

            // 상어가 제자리에 멈춘다
            speed = 0;
            // 경과시간 카운트가 멈춘다
            SpectatorViewUI1 sv = GameObject.Find("Spectator_Canvas").GetComponent<SpectatorViewUI1>();
            sv.count = 0;

            // 게임오버 UI가 활성화된다.
            GameOverUI.SetActive(true);
        }
    }
    
}
