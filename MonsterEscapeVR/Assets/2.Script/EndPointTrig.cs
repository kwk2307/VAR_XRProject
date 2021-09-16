using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPointTrig : MonoBehaviour
{
    // 게임오버(성공) 부분 

    public GameObject gameWinUI;
    public Text time;

    // 최고기록 확인 부분
    public string bestRecord;
    // 최고기록(분,초,밀리초) 
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            

            // 성공 사운드 재생

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





            


        }

    }

}
