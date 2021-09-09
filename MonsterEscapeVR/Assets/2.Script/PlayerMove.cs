using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{
    public GameObject tracker01;
    public GameObject tracker04;
    float distance; //트래커들 사이의 거리를 담을 변수
    public float speed = 1;
    GameObject curPos;
    GameObject prePos;
    float isRowing;
    float isRowingPre;
    
    // 게임오버(성공) 부분 
    
    public GameObject gameWinUI;
    public Text time;

    // 최고기록 확인 부분
    public string bestRecord;
    // 최고기록(분,초,밀리초) 


   
   
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       

        curPos = this.gameObject;
        Debug.Log("test");

        if (prePos == null) return;  // 첫 프레임 예외처리


        isRowing = Vector3.Distance(curPos.transform.position, prePos.transform.position);  //현 프레임
        print(1);

        //로잉기를 당기는지 확인
        if ((isRowing - isRowingPre) > 0)
        {
            {
                transform.position += new Vector3(1, 0, 0) * distance; // 당긴 것에 비례해 z축으로 이동

            }
        }



        distance = Vector3.Distance(tracker01.transform.position, tracker04.transform.position);
        print(distance);



        prePos = this.gameObject;
        isRowingPre = Vector3.Distance(curPos.transform.position, prePos.transform.position); // 과거 프레임(다음 프레임 입장에서)


    }
    // 플레이어가 목표지점까지 도달한경우
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("EndPoint"))
        {
            // 테스트용 (삭제가능)
            
            // 성공사운드 재생

            // 성공 이팩트 실행

            // 상어가 추격을 멈춘다.(애니메이션도 나중에 넣어야함 9/7)
            EnemyMove em = GameObject.Find("Shark_Charactor").GetComponent<EnemyMove>();
            em.speed = 0;

            
            // 게임 종료(승리)UI 활성화(여기에 시간,속도 정보 텍스트로 나타냄)
            gameWinUI.SetActive(true);
            
            // 시간 정지(정지 및 저장)
            SpectatorViewUI sv = GameObject.Find("Spectator_Canvas").GetComponent<SpectatorViewUI>();
            sv.count = 0;
            // 정지된 기록이 텍스트로 표시
            time.text = "Time: " + sv.MinuteBox.GetComponent<Text>().text  + sv.SecondBox.GetComponent<Text>().text  + sv.MilliBox.GetComponent<Text>().text;
            // 최고기록인지 아닌지 확인
            
            // 만약 현재기록이 최고기록이라면 신기록 이팩트+사운드 생성

           
                
            

            // 속도 정보(평균 속도,최고 속도)값 가져오기


        }

    }
    private void OnGUI()
    {
        if (GUI.Button(new Rect(300, 0, 300, 150), "다시하기"))
        {
            // 다시하기(실험용)
            GameMng gm = GameObject.Find("Click").GetComponent<GameMng>();


            gm.SceneChange();
        }
    }
}
