using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rowing : MonoBehaviour
{
    [SerializeField] private GameObject tracker01;
    [SerializeField] private GameObject tracker04;
    [SerializeField] private Animator anim_boat;
    [SerializeField] private Animator anim_men;
    private float distance; //트래커들 사이의 거리를 담을 변수
    [SerializeField] private float speed = 1;

    private float isRowing;
    private float isRowingPre;
    private float Rowrate = -0.1f;

    private int a = 1;

    // 게임오버(성공) 부분 

    public GameObject gameWinUI;
    public Text time;

    // 최고기록 확인 부분
    public string bestRecord;
    // 최고기록(분,초,밀리초) 

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
        float tmp = Vector3.Distance(tracker01.transform.position, tracker04.transform.position);  //현 프레임

        if (tmp <= 1)
        {
            isRowing = tmp;
            anim_boat.SetFloat("Position", isRowing);
            anim_men.SetFloat("Position", isRowing);
        }

        if (isRowing - isRowingPre > 0.7)
        {
            return; // 위치값이 튀는 것에 대한 예외처리
        }


        /*if(Rowrate - (float)Math.Round(isRowing - isRowingPre, 3) < 0.1 && 
            Rowrate - (float)Math.Round(isRowing - isRowingPre, 3) > -0.1)
        {
            Rowrate -= (float)Math.Round(isRowing - isRowingPre, 3);
        }*/

        if (Rowrate - (isRowing - isRowingPre) < 0.1 &&
            Rowrate - (isRowing - isRowingPre) > -0.1)
        {
            Rowrate -= (isRowing - isRowingPre);
        }

        //print(Rowrate);
        anim_boat.SetFloat("isRow", Rowrate);
        anim_men.SetFloat("isRow", Rowrate);

        //로잉기를 당기는지 확인
        
        if ((isRowing - isRowingPre) > 0)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1) * (isRowing - isRowingPre) * speed);
        }

        isRowingPre = isRowing; // 과거 프레임(다음 프레임 입장에서)
        //print("isRowingPre : " + isRowingPre);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.GetComponent<Rigidbody>().velocity.z < 0)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) * speed/2 * Time.deltaTime);
        }
        else
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        //isRowing = tracker01.transform.position.x  - tracker04.transform.position.x;
        //print("isRowing : " + isRowing);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("EndPoint"))
        {
            // 테스트용 (삭제가능)

            // 성공사운드 재생

            // 성공 이팩트 실행

            // 상어가 추격을 멈춘다.(애니메이션도 나중에 넣어야함 9/7)
            EnemyMove em = GameObject.Find("Enermy").GetComponent<EnemyMove>();
            em.speed = 0;


            // 게임 종료(승리)UI 활성화(여기에 시간,속도 정보 텍스트로 나타냄)
            gameWinUI.SetActive(true);

            // 시간 정지(정지 및 저장)
            SpectatorViewUI1 sv = GameObject.Find("Spectator_Canvas").GetComponent<SpectatorViewUI1>();
            sv.count = 0;
            // 정지된 기록이 텍스트로 표시
            time.text = "Time: " + sv.MinuteBox.GetComponent<Text>().text + sv.SecondBox.GetComponent<Text>().text + sv.MilliBox.GetComponent<Text>().text;
            // 최고기록인지 아닌지 확인

            // 만약 현재기록이 최고기록이라면 신기록 이팩트+사운드 생성





            // 속도 정보(평균 속도,최고 속도)값 가져오기


        }

    }
    
    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 300, 150), "버튼"))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1) * 300);
        }
        if (GUI.Button(new Rect(300, 0, 300, 150), "다시하기"))
        {
            // 다시하기(실험용)
            GameMng gm = GameObject.Find("Click").GetComponent<GameMng>();


            gm.SceneChange();
        }
    }
    
}
