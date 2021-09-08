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
        
    }

    // Update is called once per frame
    void Update()
    {
        delayCount += Time.deltaTime;
        if (delayCount >= 3)
        {

            //플레이어를 쫓아간다.
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);

        }
    }
    // 충돌했을경우
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            // 게임오버(실패) 사운드가 재생

            // 게임오버(실패) 이팩트가 실행

            // 상어가 제자리에 멈춘다
            speed = 0;
            // 경과시간 카운트가 멈춘다
            SpectatorViewUI sv = GameObject.Find("Spectator_Canvas").GetComponent<SpectatorViewUI>();
            sv.count = 0;

            // 게임오버 UI가 활성화된다.
            GameOverUI.SetActive(true);
        }
    }
    
}
