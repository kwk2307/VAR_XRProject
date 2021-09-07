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

    // �ְ���

    public Text BestRecordTime;
    public string best;
    int bestMinute;
    int bestSecond;
    float bestMilli;
    // �������(��,��,�и���)
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
        // ����ؼ� ��� ����
        if (startCount >= 3)
        {
            record();
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
        else  MilliCount +=Time.deltaTime*0;
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

        best = "Time: " + MinuteBox.GetComponent<Text>().text + SecondBox.GetComponent<Text>().text + MilliBox.GetComponent<Text>().text;
        PlayerPrefs.SetString("Best Record", best); // ��� ��ü �ؽ�Ʈ�� ���� ex) 01:01:01
        PlayerPrefs.SetInt("Best Minute", MinuteCount); // �а� ����
        PlayerPrefs.SetInt("Best Second", SecondCount); // �ʰ� ����
        PlayerPrefs.SetFloat("Best MilliSecond", MilliCount); // �и��ʰ� ����


        // ���������� �Ҵ��Ͽ� ������ ���ο� ����� ���� �� �񱳿뵵
        PlayerPrefs.SetInt("Before Minute", MinuteCount); // ���� �а� ����
        PlayerPrefs.SetInt("Before Second", SecondCount); // ���� �ʰ� ����
        PlayerPrefs.SetFloat("Before MilliSecond", MilliCount); // ���� �и��ʰ� ����

        if (PlayerPrefs.HasKey("Best Record")) // ���� �ְ� ��ϰ��� �����Ѵٸ�
        {


            if (beforeMinute > bestMinute)
            {
                // ��,��,�и����� �ְ������� ����
                bestMinute = PlayerPrefs.GetInt("Best Minute");
                bestSecond = PlayerPrefs.GetInt("Best Second");
                bestMilli = PlayerPrefs.GetFloat("Best MilliSecond");

                // ��,�� �и����� ���� ��ϵ����ε� ����(���� �÷��̽� �� �뵵) --> �����ؾ��Ѵ�(���� ���� �����ϱ� ����)
                beforeMinute = PlayerPrefs.GetInt("Best Minute");
                beforeSecond = PlayerPrefs.GetInt("Best Second");
                beforeMilli = PlayerPrefs.GetFloat("Best MilliSecond");
            }
            else if (beforeMinute == bestMinute)
            {
                if (beforeSecond > bestSecond)
                {
                    // ��,��,�и����� �ְ��� �ҷ�����
                    bestMinute = PlayerPrefs.GetInt("Best Minute");
                    bestSecond = PlayerPrefs.GetInt("Best Second");
                    bestMilli = PlayerPrefs.GetFloat("Best MilliSecond");

                    // ��,�� �и����� ���� ��ϵ����ε� ����(���� �÷��̽� �� �뵵) --> �����ؾ��Ѵ�(���� ���� �����ϱ� ����)
                    beforeMinute = PlayerPrefs.GetInt("Best Minute");
                    beforeSecond = PlayerPrefs.GetInt("Best Second");
                    beforeMilli = PlayerPrefs.GetFloat("Best MilliSecond");
                }
                else if (beforeSecond == bestSecond)
                {
                    if (beforeMilli > bestMilli)
                    {
                        // ��,��,�и����� �ְ��� �ҷ�����
                        bestMinute = PlayerPrefs.GetInt("Best Minute");
                        bestSecond = PlayerPrefs.GetInt("Best Second");
                        bestMilli = PlayerPrefs.GetFloat("Best MilliSecond");

                        // ��,�� �и����� ���� ��ϵ����ε� ����(���� �÷��̽� �� �뵵) --> �����ؾ��Ѵ�(���� ���� �����ϱ� ����)
                        beforeMinute = PlayerPrefs.GetInt("Best Minute");
                        beforeSecond = PlayerPrefs.GetInt("Best Second");
                        beforeMilli = PlayerPrefs.GetFloat("Best MilliSecond");
                    }
                }
            }
            
            
        }
        else // �ְ� ��� ���� �������� �ʴ� ���
        {
            // ��,��,�и����� �ְ��� �ҷ�����
            bestMinute = PlayerPrefs.GetInt("Best Minute");
            bestSecond = PlayerPrefs.GetInt("Best Second");
            bestMilli = PlayerPrefs.GetFloat("Best MilliSecond");

            // ��,�� �и����� ���� ��ϵ����ε� ����(���� �÷��̽� �� �뵵) --> �����ؾ��Ѵ�(���� ���� �����ϱ� ����)
            beforeMinute = PlayerPrefs.GetInt("Best Minute");
            beforeSecond = PlayerPrefs.GetInt("Best Second");
            beforeMilli = PlayerPrefs.GetFloat("Best MilliSecond");
        }

    }
}


