using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocodileMove : MonoBehaviour
{
    public float speed = 5f;
    public float attackPower = 1f;
    public float delayCount;

    private GameObject player; //플레이어를 담을 변수
    public GameObject GameOverUI; // 게임오버(실패)UI
     GameObject GameOverUI_player; // 플레이어 캔버스에 있는 게임오버 UI
    Animator ani; //애니
    private float delayTime;

    Light lit;

    void Start()
    {
        //플레이어를 찾아서 담는다
        player = GameObject.Find("Player");

        Destroy(GameObject.Find("BGM")); //브금을 지운다. 모드에 맞는 브금이랑 겹치면 안되니깐

        GameOverUI_player = GameObject.Find("PlayerCanvas").transform.Find("GameOverUI_Fail").gameObject;
        ani = GetComponent<Animator>();

        lit = GameObject.Find("Directional Light").GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        delayCount += Time.deltaTime;
        if (delayCount >= 6.5)
        {
            //크아아앙
            ani.SetBool("Angry", true);

            //플레이어를 쫓아간다.
            transform.position -= Vector3.forward * speed;


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
            SpectatorViewUI1 sv = GameObject.Find("Spectator_Canvas").GetComponent<SpectatorViewUI1>();
            sv.count = 0;

            // 게임오버 UI가 활성화된다.
            GameOverUI.SetActive(true);
            

            ani.SetBool("GoByte", true); //게임이 끝나면 악어가 입을 앙앙거린다.
        }
    }
    private void OnCollisionStay(Collision collision)//플레이어 캔버스에 있는 게임오버 UI도 활성화
    {
        //바로 게임오버 UI가 뜨면 어색하자너
        delayTime += Time.deltaTime;
        if (delayTime >= 3) //3초 동안은 실패연출 봐라
        {
            GameOverUI_player.SetActive(true);

        }

        //조명도 어둡게 해봅시다
        StartCoroutine(FadeOut());

    }
    IEnumerator FadeOut()
    {
        lit.intensity -= Time.deltaTime;
        yield return 1;
    }


}
