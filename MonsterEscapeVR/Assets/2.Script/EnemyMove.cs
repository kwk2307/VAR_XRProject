using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    public int GameMode; //1번 - 악어, 2번 - 상어, 3번 - 크라켄

    public float speed = 5f;
    public float attackPower = 1f;
    public float delayCount;

    private GameObject player; //플레이어를 담을 변수
    public GameObject GameOverUI; // 게임오버(실패)UI
     GameObject GameOverUI_player; // 플레이어 캔버스에 있는 게임오버 UI
    Animator ani; //적의 애니 컨트롤러
    AudioSource sound; //포효 소리

    Light lit;

    bool start = false;
    float delayTime;
    public static float enumSpeed; //적의 속도

    GameObject angImage;
    float angDis; //분노모드에 들어갈 수치
    Color color;
    bool angEnter=false;
    bool angry = false;

    void Start()
    {
        //플레이어를 찾아서 담는다
        player = GameObject.Find("Player");

        Destroy(GameObject.Find("BGM")); //브금을 지운다. 모드에 맞는 브금이랑 겹치면 안되니깐

        GameOverUI_player = GameObject.Find("PlayerCanvas").transform.Find("GameOverUI_Fail").gameObject;
        ani = GetComponent<Animator>(); //애니매이터 담기

        //크아아앙 소리 할당
        sound = GetComponent<AudioSource>();

        lit = GameObject.Find("Directional Light").GetComponent<Light>(); //빛을 찾아 담는다

        if (GameMode == 1)
        {
            enumSpeed = 2; //악어의 스피트
            angDis = 900;
        }
        else if(GameMode == 2)
        {
            enumSpeed = 2f; //상어의 스피드
            angDis = 900;
        }
        else
        {
            enumSpeed = 2; // 크라켄의 스피드
            angDis = 900;
        }
        angImage = GameObject.Find("Angry");
        color = angImage.GetComponent<Image>().color;
        color.a = 0f;
        angImage.GetComponent<Image>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
        delayCount += Time.deltaTime;
        if(delayCount >= 3)
        {
            if (GameMode == 1 && delayCount >= 6) //악어 
            {
                if ( start == false)
                {
                    print(1);
                    //포효 소리 재생
                    sound.Play();

                    //다시 이 곳에 안들어오도록 막는다
                    start = true;


                }
                //플레이어를 쫓아간다.
                transform.position -= Vector3.forward * enumSpeed * Time.deltaTime; ; //플레이어의 속도에 따라 앞,뒤로 이동한다.
                

            }
            if (GameMode == 2) //상어 
            {
                if (delayCount >= 3 && start == false)
                {
                    //크아아앙
                    ani.SetBool("Angry", true);

                    //포효 소리 재생
                    sound.Play();

                    //다시 이 곳에 안들어오도록 막는다
                    start = true;


                }
                if (delayCount >= 6)
                {
                    //크아앙은 멈추고
                    ani.SetBool("Angry", false);

                    //플레이어를 쫓아간다.
                    transform.position -= Vector3.forward * enumSpeed * Time.deltaTime; ; //플레이어의 속도에 따라 앞,뒤로 이동한다.

                }

            }
            if (GameMode == 3) //크라켄
            {
                //크라켄의 포효
                if(delayCount >= 3.5 && start ==false)
                {
                    sound.Play();
                    start = true;
                }
                if (delayCount >= 6)
                {
                    //플레이어를 쫓아간다.
                    transform.position -= Vector3.forward * enumSpeed * Time.deltaTime; ; //플레이어의 속도에 따라 앞,뒤로 이동한다.

                    

                }
                    

            }

            

        }

       if(angDis > GameMng.Instance.currentdistance && angry==false) //분노모드에 들어가기 위한 조건
        {
            angry = true;
            if (angEnter == false)
            {
                color.a = 1;
                angImage.GetComponent<Image>().color = color;

                sound.Play(); //포효소리 재생
                angEnter = true;

            }
           

            StartCoroutine(AngryAlpha());

            if(angDis < GameMng.Instance.currentdistance - 100) //분노모드는 100m동안 유지
            {
                angDis -= 200;
                color.a = 0;
                angImage.GetComponent<Image>().color = color;

            }

        }
       


    }
    // 충돌했을경우
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            // 게임오버(실패) 사운드가 재생

            // 게임오버(실패) 이팩트가 실행

            // 적이 제자리에 멈춘다
            enumSpeed = GameMng.Instance.currentspeed;
            // 경과시간 카운트가 멈춘다
            //SpectatorViewUI1 sv = GameObject.Find("Spectator_Canvas").GetComponent<SpectatorViewUI1>();
            //sv.count = 0;

            // 게임오버 UI가 활성화된다.
            GameOverUI.SetActive(true);

            //적의 이동 멈춤
            




            ani.SetBool("Byte", true); //게임이 끝나면 적이 입을 앙앙거린다.
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

    IEnumerator AngryAlpha() //분노모드 이미지 알파값 왔다갔다
    {
        print("분노모드 코루틴 진입");
        color.a = Mathf.Lerp(1, 0.7f, 2);
        angImage.GetComponent<Image>().color = color;
        yield return new WaitForSeconds(2f);
        color.a = Mathf.Lerp(0.7f, 1, 2);
        angImage.GetComponent<Image>().color = color;
        yield return new WaitForSeconds(2f);

        angry = false;

    }

}
