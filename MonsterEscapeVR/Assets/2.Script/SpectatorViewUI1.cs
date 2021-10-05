using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpectatorViewUI1 : MonoBehaviour
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


    public int bestMinute;
    public int bestSecond;
    public float bestMilli;
    public string bestMilliDisplay;

    EndPointTrig ept;
    // 랭킹용
    public int tempMinute;
    public int tempSecond;
    public float tempMilli;

    public int[] rankMinute= { 99, 99, 99, 99, 99, 99, 99, 99, 99, 99 };
    public int[] rankSecond= { 99, 99, 99, 99, 99, 99, 99, 99, 99, 99 };
    public float[] rankMilli= { 99, 99, 99, 99, 99, 99, 99, 99, 99, 99 };
   
    

    void Awake()
    {
        if (PlayerPrefs.HasKey("Best Minute"))
        {
            // 최고점수 값 불러오기
            bestMinute = PlayerPrefs.GetInt("Best Minute");
            bestSecond = PlayerPrefs.GetInt("Best Second");
            bestMilli = PlayerPrefs.GetFloat("Best MilliSecond");




            // 밀리세컨드의 소수점 표시않기위해
            bestMilliDisplay = PlayerPrefs.GetFloat("Best MilliSecond").ToString("F0");
            if (PlayerPrefs.GetInt("Best Minute") <= 9)
            {
                BestRecordMinute.text = "0" + PlayerPrefs.GetInt("Best Minute") + ":";
            }
            else
            {
                BestRecordMinute.text = "" + PlayerPrefs.GetInt("Best Minute") + ":";
            }
            if (PlayerPrefs.GetInt("Best Second") <= 9)
            {
                BestRecordSecond.text = "0" + PlayerPrefs.GetInt("Best Second") + ":";
            }
            else
            {
                BestRecordSecond.text = "" + PlayerPrefs.GetInt("Best Second") + ":";
            }
            if (PlayerPrefs.GetFloat("Best MilliSecond") <= 10)
            {
                BestRecordMilli.text = "0" + bestMilliDisplay;
            }
            else
            {
                BestRecordMilli.text = "" + bestMilliDisplay;
            }
        }
        else
        {
            PlayerPrefs.SetInt("Best Minute", 99); // 분값 저장
            PlayerPrefs.SetInt("Best Second", 99); // 초값 저장
            PlayerPrefs.SetFloat("Best MilliSecond", 99); // 밀리초값 저장



        }
    }

    private void Start()
    {
        ept = GameObject.Find("EndPoint").GetComponent<EndPointTrig>();
    }

    void Update()
    {
        startCount += Time.deltaTime;
        // 계속해서 기록 누적
        if (startCount >= 3)
        {
            record();

            
            //if (ept.gameWinUI.activeSelf == true)
            {
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

        // 09/09 현재 기록비교는 제대로 작동하나 다음에 추가로 처음 00:00:00일때 기록연산하는거도 추가해야한다.

        PlayerPrefs.SetInt("New Minute", MinuteCount); // 분값 저장
        PlayerPrefs.SetInt("New Second", SecondCount); // 초값 저장
        PlayerPrefs.SetFloat("New MilliSecond", MilliCount); // 밀리초값 저장

        // 랭킹 저장하는 용도로 temp값에 저장해준다


       

        PlayerPrefs.SetInt("Temp Minute", tempMinute); // 분값 저장
        PlayerPrefs.SetInt("Temp Second", tempSecond); // 초값 저장
        PlayerPrefs.SetFloat("Temp Milli", tempMilli); // 밀리초값 저장

        for (int i = 0; i < 10; i++)
        {
            // if(tempMinute<rankMinute[i]){
            for (int j = i + 1; j <= 10; j++)
            {
                // temp=rank[i];
                //rank[i]=rank[j];
                //rank[j]=rank[i];
            }
            //}
            // else if(tempMinute==rankMinute[i]){
            // if(tempSecond<rankSecond[i]){
            for (int j = i + 1; j <= 10; j++)
            {
                // temp=rank[i];
                // rank[i]=rank[j];
                // rank[j]=rank[i];
            }
            //}
            // else if(tempSecond==rankSecond[i]){
            // if(tempMilli<rankMilli[i]){
            for (int j = i + 1; j <= 10; j++)
            {
                // temp=rank[i];
                //rank[i]=rank[j];
                //rank[j]=rank[i];
            }
        //}
        //}
        }

       
        print("기존의 최고기록은: " + PlayerPrefs.GetInt("Best Minute") + ":" + "분" +
        PlayerPrefs.GetInt("Best Second") + ":" + "초" +
        PlayerPrefs.GetFloat("Best MilliSecond") + "밀리");

        print("현재 New 기록은" + PlayerPrefs.GetInt("New Minute") + "분" +
        PlayerPrefs.GetInt("New Second") + "초" +
        PlayerPrefs.GetFloat("New MilliSecond") + "밀리입니다.");


        //if(!PlayerPrefs.HasKey("Best Minute")) {
        //    // 최고기록으로 넣어준다.
        //    bestMinute = PlayerPrefs.GetInt("New Minute"); // 분값 저장
        //    bestSecond = PlayerPrefs.GetInt("New Second"); // 초값 저장
        //    bestMilli = PlayerPrefs.GetFloat("New MilliSecond"); // 밀리초값 저장

        //    // 비교를 위해 넣어준다.
        //    PlayerPrefs.SetInt("Best Minute", bestMinute); // 분값 저장
        //    PlayerPrefs.SetInt("Best Second", bestSecond); // 초값 저장
        //    PlayerPrefs.SetFloat("Best MilliSecond", bestMilli); // 밀리초값 저장

        //}
        if (PlayerPrefs.GetInt("Best Minute") > PlayerPrefs.GetInt("New Minute"))
        {
            

            // 최고기록으로 넣어준다.
            bestMinute = PlayerPrefs.GetInt("New Minute"); // 분값 저장
            bestSecond = PlayerPrefs.GetInt("New Second"); // 초값 저장
            bestMilli = PlayerPrefs.GetFloat("New MilliSecond"); // 밀리초값 저장

            // 비교를 위해 넣어준다.
            PlayerPrefs.SetInt("Best Minute", bestMinute); // 분값 저장
            PlayerPrefs.SetInt("Best Second", bestSecond); // 초값 저장
            PlayerPrefs.SetFloat("Best MilliSecond", bestMilli); // 밀리초값 저장

            

        }
        else if (PlayerPrefs.GetInt("Best Minute") == PlayerPrefs.GetInt("New Minute"))
        {

            if (PlayerPrefs.GetInt("Best Second") > PlayerPrefs.GetInt("New Second"))
            {

                // 최고기록으로 넣어준다.
                bestMinute = PlayerPrefs.GetInt("New Minute"); // 분값 저장
                bestSecond = PlayerPrefs.GetInt("New Second"); // 초값 저장
                bestMilli = PlayerPrefs.GetFloat("New MilliSecond"); // 밀리초값 저장

                // 비교를 위해 넣어준다.
                PlayerPrefs.SetInt("Best Minute", bestMinute); // 분값 저장
                PlayerPrefs.SetInt("Best Second", bestSecond); // 초값 저장
                PlayerPrefs.SetFloat("Best MilliSecond", bestMilli); // 밀리초값 저장
            }
            else if (PlayerPrefs.GetInt("Best Second") == PlayerPrefs.GetInt("New Second"))
            {

                if (PlayerPrefs.GetFloat("Best Milli") > PlayerPrefs.GetFloat("New MilliSecond"))
                {
                    // 최고기록으로 넣어준다.
                    bestMinute = PlayerPrefs.GetInt("New Minute"); // 분값 저장
                    bestSecond = PlayerPrefs.GetInt("New Second"); // 초값 저장
                    bestMilli = PlayerPrefs.GetFloat("New MilliSecond"); // 밀리초값 저장

                    // 비교를 위해 넣어준다.
                    PlayerPrefs.SetInt("Best Minute", bestMinute); // 분값 저장
                    PlayerPrefs.SetInt("Best Second", bestSecond); // 초값 저장
                    PlayerPrefs.SetFloat("Best MilliSecond", bestMilli); // 밀리초값 저장
                }
            }
        }
        print(bestMinute + "분" + bestSecond + "초" + bestMilli + "밀리");
        
    }
    public void RankingCompare()
    {
        PlayerPrefs.GetInt("Temp Minute");
        PlayerPrefs.GetInt("Temp Second"); 
        PlayerPrefs.GetFloat("Temp Milli");

        tempMinute = PlayerPrefs.GetInt("Temp Minute");
        tempSecond=PlayerPrefs.GetInt("Temp Second");
        tempMilli = PlayerPrefs.GetFloat("Temp MilliSecond");
        for (int i = 0; i < 10; i++)
        {
            if (tempMinute < rankMinute[i])
            {
                for (int j = i + 1; j<=10; j++)
                {
                    tempMinute = rankMinute[i];
                    rankMinute[i] = rankMinute[j];
                    rankMinute[j] = rankMinute[i];

                    tempSecond = rankSecond[i];
                    rankMinute[i] = rankSecond[j];
                    rankMinute[j] = rankSecond[i];

                    tempMilli = rankMilli[i];
                    rankMilli[i] = rankMilli[j];
                    rankMilli[j] = rankMilli[i];

                    PlayerPrefs.SetInt("Ranking i Minute", rankMinute[i]);
                    PlayerPrefs.SetInt("Ranking i Second", rankSecond[i]);
                    PlayerPrefs.SetFloat("Ranking i Milli", rankMilli[i]);

                    PlayerPrefs.SetInt("Ranking j Minute", rankMinute[j]);
                    PlayerPrefs.SetInt("Ranking j Second", rankSecond[j]);
                    PlayerPrefs.SetFloat("Ranking j Milli", rankMilli[j]);

                }
            }
            else if (tempMinute == rankMinute[i])
            {
                if (tempSecond < rankSecond[i])
                {
                    for (int j = i + 1; j <= 10; j++)
                    {
                        tempMinute = rankMinute[i];
                        rankMinute[i] = rankMinute[j];
                        rankMinute[j] = rankMinute[i];

                        tempSecond = rankSecond[i];
                        rankMinute[i] = rankSecond[j];
                        rankMinute[j] = rankSecond[i];

                        tempMilli = rankMilli[i];
                        rankMilli[i] = rankMilli[j];
                        rankMilli[j] = rankMilli[i];

                        PlayerPrefs.SetInt("Ranking i Minute", rankMinute[i]);
                        PlayerPrefs.SetInt("Ranking i Second", rankSecond[i]);
                        PlayerPrefs.SetFloat("Ranking i Milli", rankMilli[i]);

                        PlayerPrefs.SetInt("Ranking j Minute", rankMinute[j]);
                        PlayerPrefs.SetInt("Ranking j Second", rankSecond[j]);
                        PlayerPrefs.SetFloat("Ranking j Milli", rankMilli[j]);

                    }
                }
                else if (tempSecond == rankSecond[i])
                {
                    if (tempMilli < rankMilli[i])
                    {
                        for (int j = i + 1; j <= 10; j++)
                        {
                            tempMinute = rankMinute[i];
                            rankMinute[i] = rankMinute[j];
                            rankMinute[j] = rankMinute[i];

                            tempSecond = rankSecond[i];
                            rankMinute[i] = rankSecond[j];
                            rankMinute[j] = rankSecond[i];

                            tempMilli = rankMilli[i];
                            rankMilli[i] = rankMilli[j];
                            rankMilli[j] = rankMilli[i];

                            PlayerPrefs.SetInt("Ranking i Minute", rankMinute[i]);
                            PlayerPrefs.SetInt("Ranking i Second", rankSecond[i]);
                            PlayerPrefs.SetFloat("Ranking i Milli", rankMilli[i]);

                            PlayerPrefs.SetInt("Ranking j Minute", rankMinute[j]);
                            PlayerPrefs.SetInt("Ranking j Second", rankSecond[j]);
                            PlayerPrefs.SetFloat("Ranking j Milli", rankMilli[j]);
                        }
                    }
                }
                else
                {
                    tempMinute = rankMinute[i + 1];
                    tempSecond = rankSecond[i + 1];
                    tempMilli = rankMilli[i + 1];

                    PlayerPrefs.SetInt("Ranking i Minute", rankMinute[i+1]);
                    PlayerPrefs.SetInt("Ranking i Second", rankSecond[i+1]);
                    PlayerPrefs.SetFloat("Ranking i Milli", rankMilli[i+1]);
                }
            }
            else
            {
                tempMinute = rankMinute[i + 1];
                tempSecond = rankSecond[i + 1];
                tempMilli = rankMilli[i + 1];

                PlayerPrefs.SetInt("Ranking i Minute", rankMinute[i + 1]);
                PlayerPrefs.SetInt("Ranking i Second", rankSecond[i + 1]);
                PlayerPrefs.SetFloat("Ranking i Milli", rankMilli[i + 1]);
            }
        }
    }




    //void InitialRecord()
    //{

    //    PlayerPrefs.SetInt("New Minute", MinuteCount); // 분값 저장
    //    PlayerPrefs.SetInt("New Second", SecondCount); // 초값 저장
    //    PlayerPrefs.SetFloat("New MilliSecond", MilliCount); // 밀리초값 저장

    //    bestMinute = PlayerPrefs.GetInt("New Minute");
    //    bestSecond = PlayerPrefs.GetInt("New Second");
    //    bestMilli = PlayerPrefs.GetFloat("New MilliSecond");

    //    PlayerPrefs.SetInt("Best Minute", bestMinute); // 분값 저장
    //    PlayerPrefs.SetInt("Best Second", bestSecond); // 초값 저장
    //    PlayerPrefs.SetFloat("Best MilliSecond", bestMilli); // 밀리초값 저장

    //    print("InitialRecord의 기록은" + bestMinute + " : " + bestSecond + " : " + bestMilli);
    //}
}








