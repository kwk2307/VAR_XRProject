using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpectatorViewUI : MonoBehaviour
{
    public float startCount;

    public  int MinuteCount;
    public  int SecondCount;
    public  float MilliCount;
    public  string MilliDisplay;

    public GameObject MinuteBox;
    public GameObject SecondBox;
    public GameObject MilliBox;

   

    public int count = 1;

    // 최고기록

    public Text BestRecordTime;
    public string best;
    int bestMinute;
    int bestSecond;
    float bestMilli;
    // 이전기록(분,초,밀리초)
    int beforeMinute;
    int beforeSecond;
    float beforeMilli;
    void start()
    {

        BestRecordTime.text = bestMinute + ":" + bestSecond + ":" + bestMilli;
    }


        void Update()
        {
        startCount += Time.deltaTime;
        // 계속해서 기록 누적
        if (startCount >= 3)
        {
            record();
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
        else  MilliCount +=Time.deltaTime*0;
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

        best = "Time: " + MinuteBox.GetComponent<Text>().text + SecondBox.GetComponent<Text>().text + MilliBox.GetComponent<Text>().text;
        PlayerPrefs.SetString("Best Record", best); // 기록 전체 텍스트로 저장 ex) 01:01:01
        PlayerPrefs.SetInt("Best Minute", MinuteCount); // 분값 저장
        PlayerPrefs.SetInt("Best Second", SecondCount); // 초값 저장
        PlayerPrefs.SetFloat("Best MilliSecond", MilliCount); // 밀리초값 저장


        // 이전값으로 할당하여 다음에 새로운 기록이 나올 시 비교용도
        PlayerPrefs.SetInt("Before Minute", MinuteCount); // 이전 분값 저장
        PlayerPrefs.SetInt("Before Second", SecondCount); // 이전 초값 저장
        PlayerPrefs.SetFloat("Before MilliSecond", MilliCount); // 이전 밀리초값 저장

        if (PlayerPrefs.HasKey("Best Record")) // 만약 최고 기록값이 존재한다면
        {


            if (beforeMinute > bestMinute)
            {
                // 분,초,밀리값을 최고기록으로 저장
                bestMinute = PlayerPrefs.GetInt("Best Minute");
                bestSecond = PlayerPrefs.GetInt("Best Second");
                bestMilli = PlayerPrefs.GetFloat("Best MilliSecond");

                // 분,초 밀리값을 이전 기록도으로도 저장(다음 플레이시 비교 용도) --> 수정해야한다(이전 값을 저장하기 위해)
                beforeMinute = PlayerPrefs.GetInt("Best Minute");
                beforeSecond = PlayerPrefs.GetInt("Best Second");
                beforeMilli = PlayerPrefs.GetFloat("Best MilliSecond");
            }
            else if (beforeMinute == bestMinute)
            {
                if (beforeSecond > bestSecond)
                {
                    // 분,초,밀리값을 최고기록 불러오기
                    bestMinute = PlayerPrefs.GetInt("Best Minute");
                    bestSecond = PlayerPrefs.GetInt("Best Second");
                    bestMilli = PlayerPrefs.GetFloat("Best MilliSecond");

                    // 분,초 밀리값을 이전 기록도으로도 저장(다음 플레이시 비교 용도) --> 수정해야한다(이전 값을 저장하기 위해)
                    beforeMinute = PlayerPrefs.GetInt("Best Minute");
                    beforeSecond = PlayerPrefs.GetInt("Best Second");
                    beforeMilli = PlayerPrefs.GetFloat("Best MilliSecond");
                }
                else if (beforeSecond == bestSecond)
                {
                    if (beforeMilli > bestMilli)
                    {
                        // 분,초,밀리값을 최고기록 불러오기
                        bestMinute = PlayerPrefs.GetInt("Best Minute");
                        bestSecond = PlayerPrefs.GetInt("Best Second");
                        bestMilli = PlayerPrefs.GetFloat("Best MilliSecond");

                        // 분,초 밀리값을 이전 기록도으로도 저장(다음 플레이시 비교 용도) --> 수정해야한다(이전 값을 저장하기 위해)
                        beforeMinute = PlayerPrefs.GetInt("Best Minute");
                        beforeSecond = PlayerPrefs.GetInt("Best Second");
                        beforeMilli = PlayerPrefs.GetFloat("Best MilliSecond");
                    }
                }
            }
            
            
        }
        else // 최고 기록 값이 존재하지 않는 경우
        {
            // 분,초,밀리값을 최고기록 불러오기
            bestMinute = PlayerPrefs.GetInt("Best Minute");
            bestSecond = PlayerPrefs.GetInt("Best Second");
            bestMilli = PlayerPrefs.GetFloat("Best MilliSecond");

            // 분,초 밀리값을 이전 기록도으로도 저장(다음 플레이시 비교 용도) --> 수정해야한다(이전 값을 저장하기 위해)
            beforeMinute = PlayerPrefs.GetInt("Best Minute");
            beforeSecond = PlayerPrefs.GetInt("Best Second");
            beforeMilli = PlayerPrefs.GetFloat("Best MilliSecond");
        }

    }
}


