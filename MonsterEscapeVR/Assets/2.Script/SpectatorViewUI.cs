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
        // 밀리카운트에 10배수로 카운트
        MilliCount += Time.deltaTime*10;
        MilliDisplay = MilliCount.ToString("F0");
        // 계속해서 카운트되는 텍스트를 출력
        MilliBox.GetComponent<Text>().text = "0" + MilliDisplay;

        // 밀리카운트가 10이상이 되면 0으로 초기화하고 +1초
        if (MilliCount >= 10)
        {
            MilliCount = 0;
            SecondCount += 1;
        }
        // 9초 이하일땐 앞에 0을 붙여서 출력 ex) 00:09:00
        if (SecondCount <= 9)
        {
            SecondBox.GetComponent<Text>().text = "0" + SecondCount + "::";
        }
        // 9초 초과일땐 앞에 0을 붙이지않고 출력 ex) 00:10:00
        else
        {
            SecondBox.GetComponent<Text>().text = "" + SecondCount + "::";
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
            MinuteBox.GetComponent<Text>().text = "0" + MinuteCount + "::";
        }
        // 9분초과일땐 앞에 0을 붙이지 않고 출력 ex) 10:00:00
        else
        {
            MinuteBox.GetComponent<Text>().text = "" + MinuteCount + "::";
        }

    }
}

