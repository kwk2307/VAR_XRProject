using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 5f;
    public float attackPower = 1f;
    public float delayCount;

    private GameObject player; //플레이어를 담을 변수
    GameObject endPoint; //종착지를 담을 변수.
    public GameObject GameOverUI; // 게임오버(실패)UI
    public GameObject GameOverUI_player; // 플레이어 캔버스에 있는 게임어보 UI

    public float enterAngDis = 30f; //분노모드로 들어갈 거리 설정
    GetDistance distance; //겟디스턴스 스크립트에서 디스턴스(플레이어와 엔드포인트 사이의 거리) 가져온다.

    void Start()
    {
        //플레이어를 찾아서 담는다
        player = GameObject.Find("Player");

        Destroy(GameObject.Find("BGM")); //브금을 지운다. 모드에 맞는 브금이랑 겹치면 안되니깐
        endPoint = GameObject.Find("EndPoint"); //종착지를 찾아 담는다.

        distance = GameObject.Find("Distance_p").GetComponent<GetDistance>();
        
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
            //플레이어 캔버스에 있는 게임오버 UI도 활성화
            GameOverUI_player.SetActive(true);
        }
    }

    //분노모드 돌입 구현

    
}
