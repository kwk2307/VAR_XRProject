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

    // �ְ���

    public Text BestRecordMinute;
    public Text BestRecordSecond;
    public Text BestRecordMilli;


    int bestMinute;
    int bestSecond;
    float bestMilli;
    string bestMilliDisplay;

    EndPointTrig ept;
    // üũ��
    int num;
    void Awake()
    {
        if (PlayerPrefs.HasKey("Best Minute"))
        {
            // �ְ����� �� �ҷ�����
            bestMinute = PlayerPrefs.GetInt("Best Minute");
            bestSecond = PlayerPrefs.GetInt("Best Second");
            bestMilli = PlayerPrefs.GetFloat("Best MilliSecond");

            print("awake����� " + bestMinute + " : " + bestSecond + " : " + bestMilli);


            // �и��������� �Ҽ��� ǥ�þʱ�����
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
            PlayerPrefs.SetInt("Best Minute", 99); // �а� ����
            PlayerPrefs.SetInt("Best Second", 99); // �ʰ� ����
            PlayerPrefs.SetFloat("Best MilliSecond", 99); // �и��ʰ� ����

            print("����Ϸ�");
          
        }
    }

    private void Start()
    {
        ept = GameObject.Find("EndPoint").GetComponent<EndPointTrig>();
    }

    void Update()
    {
        startCount += Time.deltaTime;
        // ����ؼ� ��� ����
        if (startCount >= 3)
        {
            record();

            
            if (ept.gameWinUI.activeSelf == true)
            {
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

        // 09/09 ���� ��Ϻ񱳴� ����� �۵��ϳ� ������ �߰��� ó�� 00:00:00�϶� ��Ͽ����ϴ°ŵ� �߰��ؾ��Ѵ�.

        PlayerPrefs.SetInt("New Minute", MinuteCount); // �а� ����
        PlayerPrefs.SetInt("New Second", SecondCount); // �ʰ� ����
        PlayerPrefs.SetFloat("New MilliSecond", MilliCount); // �и��ʰ� ����


        //PlayerPrefs.GetInt("Best Minute");
        //PlayerPrefs.GetInt("Best Second");
        //PlayerPrefs.GetFloat("Best MilliSecond");
        print("������ �ְ�����: " + PlayerPrefs.GetInt("Best Minute") + ":" + "��" +
        PlayerPrefs.GetInt("Best Second") + ":" + "��" +
        PlayerPrefs.GetFloat("Best MilliSecond") + "�и�");

        print("���� New �����" + PlayerPrefs.GetInt("New Minute") + "��" +
        PlayerPrefs.GetInt("New Second") + "��" +
        PlayerPrefs.GetFloat("New MilliSecond") + "�и��Դϴ�.");


        //if(!PlayerPrefs.HasKey("Best Minute")) {
        //    // �ְ������� �־��ش�.
        //    bestMinute = PlayerPrefs.GetInt("New Minute"); // �а� ����
        //    bestSecond = PlayerPrefs.GetInt("New Second"); // �ʰ� ����
        //    bestMilli = PlayerPrefs.GetFloat("New MilliSecond"); // �и��ʰ� ����

        //    // �񱳸� ���� �־��ش�.
        //    PlayerPrefs.SetInt("Best Minute", bestMinute); // �а� ����
        //    PlayerPrefs.SetInt("Best Second", bestSecond); // �ʰ� ����
        //    PlayerPrefs.SetFloat("Best MilliSecond", bestMilli); // �и��ʰ� ����

        //}
        if (PlayerPrefs.GetInt("Best Minute") > PlayerPrefs.GetInt("New Minute"))
        {

            // �ְ������� �־��ش�.
            bestMinute = PlayerPrefs.GetInt("New Minute"); // �а� ����
            bestSecond = PlayerPrefs.GetInt("New Second"); // �ʰ� ����
            bestMilli = PlayerPrefs.GetFloat("New MilliSecond"); // �и��ʰ� ����

            // �񱳸� ���� �־��ش�.
            PlayerPrefs.SetInt("Best Minute", bestMinute); // �а� ����
            PlayerPrefs.SetInt("Best Second", bestSecond); // �ʰ� ����
            PlayerPrefs.SetFloat("Best MilliSecond", bestMilli); // �и��ʰ� ����

            print("�ٲ�");

        }
        else if (PlayerPrefs.GetInt("Best Minute") == PlayerPrefs.GetInt("New Minute"))
        {

            if (PlayerPrefs.GetInt("Best Second") > PlayerPrefs.GetInt("New Second"))
            {

                // �ְ������� �־��ش�.
                bestMinute = PlayerPrefs.GetInt("New Minute"); // �а� ����
                bestSecond = PlayerPrefs.GetInt("New Second"); // �ʰ� ����
                bestMilli = PlayerPrefs.GetFloat("New MilliSecond"); // �и��ʰ� ����

                // �񱳸� ���� �־��ش�.
                PlayerPrefs.SetInt("Best Minute", bestMinute); // �а� ����
                PlayerPrefs.SetInt("Best Second", bestSecond); // �ʰ� ����
                PlayerPrefs.SetFloat("Best MilliSecond", bestMilli); // �и��ʰ� ����
            }
            else if (PlayerPrefs.GetInt("Best Second") == PlayerPrefs.GetInt("New Second"))
            {

                if (PlayerPrefs.GetFloat("Best Milli") > PlayerPrefs.GetFloat("New MilliSecond"))
                {
                    // �ְ������� �־��ش�.
                    bestMinute = PlayerPrefs.GetInt("New Minute"); // �а� ����
                    bestSecond = PlayerPrefs.GetInt("New Second"); // �ʰ� ����
                    bestMilli = PlayerPrefs.GetFloat("New MilliSecond"); // �и��ʰ� ����

                    // �񱳸� ���� �־��ش�.
                    PlayerPrefs.SetInt("Best Minute", bestMinute); // �а� ����
                    PlayerPrefs.SetInt("Best Second", bestSecond); // �ʰ� ����
                    PlayerPrefs.SetFloat("Best MilliSecond", bestMilli); // �и��ʰ� ����
                }
            }
        }
        print(bestMinute + "��" + bestSecond + "��" + bestMilli + "�и�");
        
    }




    //void InitialRecord()
    //{

    //    PlayerPrefs.SetInt("New Minute", MinuteCount); // �а� ����
    //    PlayerPrefs.SetInt("New Second", SecondCount); // �ʰ� ����
    //    PlayerPrefs.SetFloat("New MilliSecond", MilliCount); // �и��ʰ� ����

    //    bestMinute = PlayerPrefs.GetInt("New Minute");
    //    bestSecond = PlayerPrefs.GetInt("New Second");
    //    bestMilli = PlayerPrefs.GetFloat("New MilliSecond");

    //    PlayerPrefs.SetInt("Best Minute", bestMinute); // �а� ����
    //    PlayerPrefs.SetInt("Best Second", bestSecond); // �ʰ� ����
    //    PlayerPrefs.SetFloat("Best MilliSecond", bestMilli); // �и��ʰ� ����

    //    print("InitialRecord�� �����" + bestMinute + " : " + bestSecond + " : " + bestMilli);
    //}
}








