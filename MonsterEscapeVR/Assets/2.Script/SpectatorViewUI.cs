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

    // �ְ���

    public Text BestRecordMinute;
    public Text BestRecordSecond;
    public Text BestRecordMilli;
     string best;
     int bestMinute;
     int bestSecond;
    
    float bestMilli;
    string bestMilliDisplay;
    // �������(��,��,�и���)
     int beforeMinute;
    int beforeSecond;
    float beforeMilli;
    void Awake()
    {
        // �ְ����� �� �ҷ�����
        PlayerPrefs.GetInt("Best Minute");
        PlayerPrefs.GetInt("Best Second");
        PlayerPrefs.GetFloat("Best MilliSecond");

        // ���� ����� �����;��ϴµ�..
        PlayerPrefs.GetInt("Before Minute");
        PlayerPrefs.GetInt("Before Second");
        PlayerPrefs.GetFloat("Before Milli");

        // �и��������� �Ҽ��� ǥ�þʱ�����
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
        // ����ؼ� ��� ����
        if (startCount >= 3)
        {
            record();
            PlayerMove pm = GameObject.Find("Player").GetComponent<PlayerMove>();
            if (pm.gameWinUI==true)
            {
                print("gameWinUI�� ���� �۵�");
                Recordcompare();
            }
        }
        // ���� ���ӿ����� �Ǿ����� ��� ����
        // ����� �����ص�
        //if(���ӿ���){
        //  currentRecordTime.text = MinuteBox.GetComponent<Text>().text + "::" + SecondBox.GetComponent<Text>().text + "::"
        //    + MilliBox.GetComponent<Text>().text;
        // // ���� ����� �ű�� ����ߴٸ� �������� �ְ�������
        // bestRecordTime.text=currentRecordTime.text;
        // }
    }
    void record()
    {
        // �и�ī��Ʈ�� 100��� ī��Ʈ
        if (count == 1)
            MilliCount += Time.deltaTime * 100;
        else MilliCount += Time.deltaTime * 0;
        MilliDisplay = MilliCount.ToString("F0");
        // ����ؼ� ī��Ʈ�Ǵ� �ؽ�Ʈ�� ���
        MilliBox.GetComponent<Text>().text = "" + MilliDisplay;

        // �и�ī��Ʈ�� 100�̻��� �Ǹ� 0���� �ʱ�ȭ�ϰ� +1��
        if (MilliCount >= 100)
        {
            MilliCount = 0;
            SecondCount += 1;
        }
        // 9�� �����϶� �տ� 0�� �ٿ��� ��� ex) 00:09:00
        if (SecondCount <= 9)
        {
            SecondBox.GetComponent<Text>().text = "0" + SecondCount + ":";
        }
        // 9�� �ʰ��϶� �տ� 0�� �������ʰ� ��� ex) 00:10:00
        else
        {
            SecondBox.GetComponent<Text>().text = "" + SecondCount + ":";
        }
        // 60�ʰ� �Ǹ� 0���� �ʱ�ȭ�ϰ� MinuteCount�� +1�ȴ�.
        if (SecondCount >= 60)
        {
            SecondCount = 0;
            MinuteCount += 1;
        }
        // 9�������϶� �տ� 0�� �ٿ��� ��� ex) 09:00:00
        if (MinuteCount <= 9)
        {
            MinuteBox.GetComponent<Text>().text = "0" + MinuteCount + ":";
        }
        // 9���ʰ��϶� �տ� 0�� ������ �ʰ� ��� ex) 10:00:00
        else
        {
            MinuteBox.GetComponent<Text>().text = "" + MinuteCount + ":";
        }
    }
    public void Recordcompare()
    {

        // �ְ������� �ƴ��� ��
        // 1. ������ �ְ� ���(A)�� ������ ���(B)��. ���� A�� �а��� B�� �а����� ũ�� B�� �ְ���.
        // 2. ���� ���� �а��� ���ٸ� �ʰ����� �� �ٽ� ��. �ʰ��� ������ milli�ʰ����� ��
       
       
            
            PlayerPrefs.SetInt("Best Minute", MinuteCount); // �а� ����
            PlayerPrefs.SetInt("Best Second", SecondCount); // �ʰ� ����
            PlayerPrefs.SetFloat("Best MilliSecond", MilliCount); // �и��ʰ� ����

        PlayerPrefs.GetInt("Before Minute"); // before�� �ҷ�����
        PlayerPrefs.GetInt("Before Second"); // before�� �ҷ�����
        PlayerPrefs.GetFloat("Before Milli"); // before�� �ҷ�����

        print("����" + PlayerPrefs.GetInt("Before Second") + "��" + "����" + PlayerPrefs.GetInt("Best Second") + "��");




        // ��ó�� �����Ҷ� 00:00:00�ΰ��
        //if (bestMinute == 0 && bestSecond == 0 && bestMilli == 0)
        //{
        //   // �ٷ� �ְ������� �־��ش�. 
        //   bestMinute= PlayerPrefs.GetInt("Best Minute"); // �а� ����
        //    bestSecond=PlayerPrefs.GetInt("Best Second"); // �ʰ� ����
        //    bestMilli=PlayerPrefs.GetFloat("Best MilliSecond"); // �и��ʰ� ����

        //    // �񱳸� ���� �־��ش�.
        //    beforeMinute = PlayerPrefs.GetInt("Best Minute"); // �а� ����
        //    beforeSecond = PlayerPrefs.GetInt("Best Second"); // �ʰ� ����
        //    beforeMilli = PlayerPrefs.GetFloat("Best MilliSecond"); // �и��ʰ� ����

        //}
        // 00:00:00�� �ƴѰ��(������ ����� �ִ� ���)


        if (PlayerPrefs.GetInt("Before Minute") > PlayerPrefs.GetInt("Best Minute"))
            {
           
                // �ְ������� �־��ش�.
                bestMinute = PlayerPrefs.GetInt("Best Minute"); // �а� ����
                bestSecond = PlayerPrefs.GetInt("Best Second"); // �ʰ� ����
                bestMilli = PlayerPrefs.GetFloat("Best MilliSecond"); // �и��ʰ� ����

                // �񱳸� ���� �־��ش�.
                PlayerPrefs.SetInt("Before Minute",bestMinute); // �а� ����
                PlayerPrefs.SetInt("Before Second",bestSecond); // �ʰ� ����
                PlayerPrefs.SetFloat("Before MilliSecond",bestMilli); // �и��ʰ� ����


            }
            else if(PlayerPrefs.GetInt("Before Minute") == PlayerPrefs.GetInt("Best Minute"))
            {
            print("���� �Ȱ����� �ʴ�"+PlayerPrefs.GetInt("Before Second")+ ","+ PlayerPrefs.GetInt("Best Second"));
            if (PlayerPrefs.GetInt("Before Second") > PlayerPrefs.GetInt("Best Second"))
            {
                print(2);
                // �ְ������� �־��ش�.
                bestMinute = PlayerPrefs.GetInt("Best Minute"); // �а� ����
                bestSecond = PlayerPrefs.GetInt("Best Second"); // �ʰ� ����
                bestMilli = PlayerPrefs.GetFloat("Best MilliSecond"); // �и��ʰ� ����

                // �񱳸� ���� �־��ش�.
                PlayerPrefs.SetInt("Before Minute", bestMinute); // �а� ����
                PlayerPrefs.SetInt("Before Second", bestSecond); // �ʰ� ����
                PlayerPrefs.SetFloat("Before MilliSecond", bestMilli); // �и��ʰ� ����
            }
            else if (PlayerPrefs.GetInt("Best Second") == PlayerPrefs.GetInt("Best Second"))
            {
                if (PlayerPrefs.GetFloat("Before Milli") > PlayerPrefs.GetFloat("Best MilliSecond"))
                {
                    // �ְ������� �־��ش�.
                    bestMinute = PlayerPrefs.GetInt("Best Minute"); // �а� ����
                    bestSecond = PlayerPrefs.GetInt("Best Second"); // �ʰ� ����
                    bestMilli = PlayerPrefs.GetFloat("Best MilliSecond"); // �и��ʰ� ����

                    // �񱳸� ���� �־��ش�.
                    PlayerPrefs.SetInt("Before Minute", bestMinute); // �а� ����
                    PlayerPrefs.SetInt("Before Second", bestSecond); // �ʰ� ����
                    PlayerPrefs.SetFloat("Before MilliSecond", bestMilli); // �и��ʰ� ����
                }
            }
            }

        print(bestMinute + "��" + bestSecond + "��" + bestMilli+"�и�");
            
        }



    }
    



