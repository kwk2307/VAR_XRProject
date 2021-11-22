using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum e_state
{
    playing,
    waiting,
}

public class EnemyMove : MonoBehaviour
{
    public int GameMode; //1번 - 악어, 2번 - 상어, 3번 - 크라켄
    
    public float delayCount;

    private GameObject player; //플레이어를 담을 변수

    Animator ani; //적의 애니 컨트롤러
    
    Light lit;
   
    private float enumSpeed; //적의 속도

    private GameObject angImage;
    private Color color;

    float angDis; //분노모드에 들어갈 수치
    float angDuration; //분노 지속시간

    bool angEnter = false;
    bool angry = false;
    float angryinterval;
    //float time;

    private e_state enemyState = e_state.waiting;

    public GameObject[] minionFactory;
    public GameObject gazePointer;
    public AudioSource gunCocking;

    void Start()
    {
        //플레이어를 찾아서 담는다
        player = GameObject.Find("Player");

        //GameOverUI_player = GameObject.Find("PlayerCanvas").transform.Find("GameOverUI_Fail").gameObject;
        ani = GetComponent<Animator>(); //애니매이터 담기

        lit = GameObject.Find("Directional Light").GetComponent<Light>(); //빛을 찾아 담는다

        if (GameMode == 1)
        {
            enumSpeed = 2.8f; //악어의 스피트
            angDis = -40; //angDis만큼 가면 분노모드!
            angDuration = 5; //얼마동안 분노할 것인가?
            angryinterval = 100; //얼마뒤에 다시 분노할 것인가?
        }
        else if(GameMode == 2)
        {
            enumSpeed = 3.4f; //상어의 스피트
            angDis = -40; //angDis만큼 가면 분노모드!
            angDuration = 20; //얼마동안 분노할 것인가?
            angryinterval = 70; //얼마뒤에 다시 분노할 것인가?
        }
        else
        {
            enumSpeed = 3.8f; // 크라켄의 스피드
            angDis = -20;
            angDuration = 15;
            angryinterval = 60; //얼마뒤에 다시 분노할 것인가?
        }
        angImage = GameObject.Find("Angry");
        color = angImage.GetComponent<Image>().color;
        color.a = 0f;
        angImage.GetComponent<Image>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(GameMng.Instance.playerState == state.playing)
        {
            
            if(enemyState == e_state.waiting)
            {
                enemyState = e_state.playing;
                //포효 소리 넣기 
                SoundMng.Instance.Enemy_s();

                

            }

            if(enemyState == e_state.playing)
            {
                //분노 애니 
                ani.SetBool("Start", true);

                if (GameMode == 1) //악어 
                {
                    if (GameMng.Instance.time >= 6)
                    {
                        

                        //플레이어를 쫓아간다.
                        transform.position -= Vector3.forward * enumSpeed * Time.deltaTime;
                        
                    }

                }
                else if (GameMode == 2) //상어 
                {

                    if (GameMng.Instance.time >= 6)
                    {
                        //플레이어를 쫓아간다.
                        transform.position -= Vector3.forward * enumSpeed * Time.deltaTime; ; //플레이어의 속도에 따라 앞,뒤로 이동한다.
                        
                    }

                }
                if (GameMode == 3) //크라켄
                {
                    if (GameMng.Instance.time >= 6)
                    {
                        //플레이어를 쫓아간다.
                        transform.position -= Vector3.forward * enumSpeed * Time.deltaTime; ; //플레이어의 속도에 따라 앞,뒤로 이동한다.
                        

                    }
                }
            }
        }

       //print("플레이어의 거리" + GameMng.Instance.currentdistance);
       if(angDis >= GameMng.Instance.currentdistance) //분노모드에 들어가기 위한 조건
        {
            angDis -= angryinterval-Random.Range(1,20);  //다음 분노모드에서 다시 분노
            
                
                StartCoroutine(AngryMode());
            
            
        }

        


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(GameOver());
        }
    }

    IEnumerator Fadeout()
    {
        while (lit.intensity > 0)
        {
            lit.intensity -= Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator AngryAlpha() //분노모드 이미지 알파값 왔다갔다
    {
        color.a = Mathf.Lerp(1, 0.7f, 2);
        angImage.GetComponent<Image>().color = color;
        yield return new WaitForSeconds(2f);
        color.a = Mathf.Lerp(0.7f, 1, 2);
        angImage.GetComponent<Image>().color = color;
        yield return new WaitForSeconds(2f);

        angry = false;
    }

    IEnumerator AngryMode()
    {
        //미니언 팩토리 활성화
        minionFactory[0].SetActive(true);
        minionFactory[1].SetActive(true);
        minionFactory[2].SetActive(true);
        //게이즈 포이터도 활성화
        gazePointer.SetActive(true);
        //처커덕 소리 재생
        gunCocking.Play();

        color.a = 1;
        angImage.GetComponent<Image>().color = color;
        
        //sound.Play(); //포효소리 재생
        SoundMng.Instance.Enemy_s();
        
        ani.SetBool("Angry", true); //계속 포효한다
        
        enumSpeed = enumSpeed *1.2f; //적의 속도도 높인다.
        StartCoroutine(AngryAlpha());

        yield return new WaitForSeconds(angDuration);
        

        color.a = 0;
        angImage.GetComponent<Image>().color = color;
        ani.SetBool("Angry", false); //포효 애니 중지
        enumSpeed = enumSpeed/1.2f; //적의 속도 다시 원상복구

        //미니언 팩토리 비활성화
        minionFactory[0].SetActive(false);
        minionFactory[1].SetActive(false);
        minionFactory[2].SetActive(false);

        yield return new WaitForSeconds(5f);
        //게이즈 포이터도 비활성화
        gazePointer.SetActive(false);


    }

    IEnumerator GameOver()
    {

        GameMng.Instance.CalcKcal();
        GameMng.Instance.playerState = state.die;
        enemyState = e_state.waiting;
        //gameoversound 재생
        SoundMng.Instance.GameOver_s();
        ani.SetBool("Byte", true); //게임이 끝나면 적이 입을 앙앙거린다.
        StartCoroutine(Fadeout());

        yield return new WaitForSeconds(3);

        UIMng.Instance.update_gameOverUI();
        // 게이즈 포인터 활성화 
        UIMng.Instance.update_gazePointer();
        
    }
    
}
