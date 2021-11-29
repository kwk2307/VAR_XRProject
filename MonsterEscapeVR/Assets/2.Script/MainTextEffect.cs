using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MainTextEffect : MonoBehaviour
{

    Text flashingText; // Use this for initialization

    void Start()
    {
        flashingText = GetComponent<Text>();

        StartCoroutine(BlinkText());

    }

    public IEnumerator BlinkText()
    {
        while (true)
        {

            flashingText.text = "";
            yield return new WaitForSeconds(0.6f);
            flashingText.text = "원하는 모드의 텍스트를 바라보고 노를 당기세요!";
            yield return new WaitForSeconds(5f);
            flashingText.text = "";
            yield return new WaitForSeconds(0.6f);
            flashingText.text = "조정기를 힘차게 당길수록 빠르게 움직일 수 있습니다.";
            yield return new WaitForSeconds(5f);
            flashingText.text = "";
            yield return new WaitForSeconds(0.6f);
            flashingText.text = "일정 시간이 지나면 적은 분노하여 더 빠르게 쫓아 옵니다.";
            yield return new WaitForSeconds(5f);
            flashingText.text = "";
            yield return new WaitForSeconds(0.6f);
            flashingText.text = "분노모드가 되면 적은 미니언을 생성 합니다.";
            yield return new WaitForSeconds(5f);
            flashingText.text = "";
            yield return new WaitForSeconds(0.6f);
            flashingText.text = "생성된 미니언을 쳐다보면 미니언이 제거됩니다.";
            yield return new WaitForSeconds(5f);
            flashingText.text = "";
            yield return new WaitForSeconds(0.6f);
            flashingText.text = "미니언에게 공격받으면 속도가 저하됩니다.";
            yield return new WaitForSeconds(5f);
            flashingText.text = "";
            yield return new WaitForSeconds(0.6f);

        }
    }

}


