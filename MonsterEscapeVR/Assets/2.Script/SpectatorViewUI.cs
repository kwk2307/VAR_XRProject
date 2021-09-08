using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpectatorViewUI : MonoBehaviour
{
    public float startCount;

    public int MinuteCount;
    public int SecondCount;
    public float MilliCount;
    public string MilliDisplay;

    public GameObject MinuteBox;
    public GameObject SecondBox;
    public GameObject MilliBox;



    public int count = 1;

    // 최고기록

    public Text BestRecordMinute;
    public Text BestRecordSecond;
    public Text BestRecordMilli;
     string best;
     int bestMinute;
     int bestSecond;
    
    float bestMilli;
    string bestMilliDisplay;
    // 이전기록(분,초,밀리초)
     int beforeMinute;
    int beforeSecond;
    float beforeMilli;
    void Awake()
    {
        // 최고점수 값 불러오기
        PlayerPrefs.GetInt("Best Minute");
        PlayerPrefs.GetInt("Best Second");
        PlayerPrefs.GetFloat("Best MilliSecond");

        // 과거 기록을 가져와야하는데..
        PlayerPrefs.GetInt("Before Minute");
        PlayerPrefs.GetInt("Before Second");
        PlayerPrefs.GetFloat("Before Milli");

        // 밀리세컨드의 소수점 표시않기위해
        bestMilliDisplay = PlayerPrefs.GetFloat("Best MilliSecond").ToString("F0");
        if (PlayerPrefs.GetInt("Best Minute")<= 9)
        {
            BestRecordMinute.text = "0" + PlayerPrefs.GetInt("Best Minute") + ":";
        }
        else
        {
            BestRecordMinute.text = "" + PlayerPrefs.GetInt("Best Minute")+":";
        }
        if (PlayerPrefs.GetInt("Best Second") <= 9)
        {
            BestRecordSecond.text = "0" + PlayerPrefs.GetInt("Best Second") +":";
        }
        else
        {
            BestRecordSecond.text = "" + PlayerPrefs.GetInt("Best Second") +":";
        }
        
        BestRecordMilli.text = "" + bestMilliDisplay;
        print(PlayerPrefs.GetInt("Best Minute") + ":" +
        PlayerPrefs.GetInt("Best Second") + ":" +
        PlayerPrefs.GetFloat("Best MilliSecond"));
    }


    void Update()
    {
        startCount += Time.deltaTime;
        // 계속해서 기록 누적
        if (startCount >= 3)
        {
            record();
            PlayerMove pm = GameObject.Find("Player").GetComponent<PlayerMove>();
            if (pm.gameWinUI==true)
            {
                print("gameWinUI는 정상 작동");
                Recordcompare();
            }
        }
        // 만약 게임오버가 되었을때 기록 멈춤
        // 기록을 저장해둠
        //if(게임오버){
        //  currentRecordTime.text = MinuteBox.GetComponent<Text>().text + "::" + SecondBox.GetComponent<Text>().text + "::"
        //    + MilliBox.GetComponent<Text>().text;
        // // 현재 기록이 신기록 경신했다면 현재기록을 최고기록으로
        // bestRecordTime.text=currentRecordTime.text;
        // }
    }
    void record()
    {
        // 밀리카운트에 100배로 카운트
        if (count == 1)
            MilliCount += Time.deltaTime * 100;
        else MilliCount += Time.deltaTime * 0;
        MilliDisplay = MilliCount.ToString("F0");
        // 계속해서 카운트되는 텍스트를 출력
        MilliBox.GetComponent<Text>().text = "" + MilliDisplay;

        // 밀리카운트가 100이상이 되면 0으로 초기화하고 +1초
        if (MilliCount >= 100)
        {
            MilliCount = 0;
            SecondCount += 1;
        }
        // 9초 이하일땐 앞에 0을 붙여서 출력 ex) 00:09:00
        if (SecondCount <= 9)
        {
            SecondBox.GetComponent<Text>().text = "0" + SecondCount + ":";
        }
        // 9초 초과일땐 앞에 0을 붙이지않고 출력 ex) 00:10:00
        else
        {
            SecondBox.GetComponent<Text>().text = "" + SecondCount + ":";
        }
        // 60초가 되면 0으로 초기화하고 MinuteCount가 +1된다.
        if (SecondCount >= 60)
        {
            SecondCount = 0;
            MinuteCount += 1;
        }
        // 9분이하일땐 앞에 0을 붙여서 출력 ex) 09:00:00
        if (MinuteCount <= 9)
        {
            MinuteBox.GetComponent<Text>().text = "0" + MinuteCount + ":";
        }
        // 9분초과일땐 앞에 0을 붙이지 않고 출력 ex) 10:00:00
        else
        {
            MinuteBox.GetComponent<Text>().text = "" + MinuteCount + ":";
        }
    }
    public void Recordcompare()
    {

        // 최고기록인지 아닌지 비교
        // 1. 이전의 최고 기록(A)과 현재의 기록(B)비교. 만약 A의 분값이 B의 분값보다 크면 B가 최고기록.
        // 2. 만약 서로 분값이 같다면 초값으로 또 다시 비교. 초값도 같으면 milli초값으로 비교
       
       
            
            PlayerPrefs.SetInt("Best Minute", MinuteCount); // 분값 저장
            PlayerPrefs.SetInt("Best Second", SecondCount); // 초값 저장
            PlayerPrefs.SetFloat("Best MilliSecond", MilliCount); // 밀리초값 저장

        PlayerPrefs.GetInt("Before Minute"); // before값 불러오기
        PlayerPrefs.GetInt("Before Second"); // before값 불러오기
        PlayerPrefs.GetFloat("Before Milli"); // before값 불러오기

        print("이전" + PlayerPrefs.GetInt("Before Second") + "초" + "현재" + PlayerPrefs.GetInt("Best Second") + "초");




        // 맨처음 시작할때 00:00:00인경우
        //if (bestMinute == 0 && bestSecond == 0 && bestMilli == 0)
        //{
        //   // 바로 최고기록으로 넣어준다. 
        //   bestMinute= PlayerPrefs.GetInt("Best Minute"); // 분값 저장
        //    bestSecond=PlayerPrefs.GetInt("Best Second"); // 초값 저장
        //    bestMilli=PlayerPrefs.GetFloat("Best MilliSecond"); // 밀리초값 저장

        //    // 비교를 위해 넣어준다.
        //    beforeMinute = PlayerPrefs.GetInt("Best Minute"); // 분값 저장
        //    beforeSecond = PlayerPrefs.GetInt("Best Second"); // 초값 저장
        //    beforeMilli = PlayerPrefs.GetFloat("Best MilliSecond"); // 밀리초값 저장

        //}
        // 00:00:00이 아닌경우(기존에 기록이 있는 경우)


        if (PlayerPrefs.GetInt("Before Minute") > PlayerPrefs.GetInt("Best Minute"))
            {
           
                // 최고기록으로 넣어준다.
                bestMinute = PlayerPrefs.GetInt("Best Minute"); // 분값 저장
                bestSecond = PlayerPrefs.GetInt("Best Second"); // 초값 저장
                bestMilli = PlayerPrefs.GetFloat("Best MilliSecond"); // 밀리초값 저장

                // 비교를 위해 넣어준다.
                PlayerPrefs.SetInt("Before Minute",bestMinute); // 분값 저장
                PlayerPrefs.SetInt("Before Second",bestSecond); // 초값 저장
                PlayerPrefs.SetFloat("Before MilliSecond",bestMilli); // 밀리초값 저장


            }
            else if(PlayerPrefs.GetInt("Before Minute") == PlayerPrefs.GetInt("Best Minute"))
            {
            print("분이 똑같을때 초는"+PlayerPrefs.GetInt("Before Second")+ ","+ PlayerPrefs.GetInt("Best Second"));
            if (PlayerPrefs.GetInt("Before Second") > PlayerPrefs.GetInt("Best Second"))
            {
                print(2);
                // 최고기록으로 넣어준다.
                bestMinute = PlayerPrefs.GetInt("Best Minute"); // 분값 저장
                bestSecond = PlayerPrefs.GetInt("Best Second"); // 초값 저장
                bestMilli = PlayerPrefs.GetFloat("Best MilliSecond"); // 밀리초값 저장

                // 비교를 위해 넣어준다.
                PlayerPrefs.SetInt("Before Minute", bestMinute); // 분값 저장
                PlayerPrefs.SetInt("Before Second", bestSecond); // 초값 저장
                PlayerPrefs.SetFloat("Before MilliSecond", bestMilli); // 밀리초값 저장
            }
            else if (PlayerPrefs.GetInt("Best Second") == PlayerPrefs.GetInt("Best Second"))
            {
                if (PlayerPrefs.GetFloat("Before Milli") > PlayerPrefs.GetFloat("Best MilliSecond"))
                {
                    // 최고기록으로 넣어준다.
                    bestMinute = PlayerPrefs.GetInt("Best Minute"); // 분값 저장
                    bestSecond = PlayerPrefs.GetInt("Best Second"); // 초값 저장
                    bestMilli = PlayerPrefs.GetFloat("Best MilliSecond"); // 밀리초값 저장

                    // 비교를 위해 넣어준다.
                    PlayerPrefs.SetInt("Before Minute", bestMinute); // 분값 저장
                    PlayerPrefs.SetInt("Before Second", bestSecond); // 초값 저장
                    PlayerPrefs.SetFloat("Before MilliSecond", bestMilli); // 밀리초값 저장
                }
            }
            }

        print(bestMinute + "분" + bestSecond + "초" + bestMilli+"밀리");
            
        }



    }
    



