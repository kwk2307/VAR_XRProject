using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpectatorViewUI : MonoBehaviour
{
    public static int MinuteCount;
    public static int SecondCount;
    public static float MilliCount;
    public static string MilliDisplay;

    public GameObject MinuteBox;
    public GameObject SecondBox;
    public GameObject MilliBox;


    void Update()
    {
        // �и�ī��Ʈ�� 10����� ī��Ʈ
        MilliCount += Time.deltaTime*10;
        MilliDisplay = MilliCount.ToString("F0");
        // ����ؼ� ī��Ʈ�Ǵ� �ؽ�Ʈ�� ���
        MilliBox.GetComponent<Text>().text = "0" + MilliDisplay;

        // �и�ī��Ʈ�� 10�̻��� �Ǹ� 0���� �ʱ�ȭ�ϰ� +1��
        if (MilliCount >= 10)
        {
            MilliCount = 0;
            SecondCount += 1;
        }
        // 9�� �����϶� �տ� 0�� �ٿ��� ��� ex) 00:09:00
        if (SecondCount <= 9)
        {
            SecondBox.GetComponent<Text>().text = "0" + SecondCount + "::";
        }
        // 9�� �ʰ��϶� �տ� 0�� �������ʰ� ��� ex) 00:10:00
        else
        {
            SecondBox.GetComponent<Text>().text = "" + SecondCount + "::";
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
            MinuteBox.GetComponent<Text>().text = "0" + MinuteCount + "::";
        }
        // 9���ʰ��϶� �տ� 0�� ������ �ʰ� ��� ex) 10:00:00
        else
        {
            MinuteBox.GetComponent<Text>().text = "" + MinuteCount + "::";
        }

    }
}

