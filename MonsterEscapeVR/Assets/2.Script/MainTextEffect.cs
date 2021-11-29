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
            flashingText.text = "���ϴ� ����� �ؽ�Ʈ�� �ٶ󺸰� �븦 ��⼼��!";
            yield return new WaitForSeconds(5f);
            flashingText.text = "";
            yield return new WaitForSeconds(0.6f);
            flashingText.text = "�����⸦ ������ ������ ������ ������ �� �ֽ��ϴ�.";
            yield return new WaitForSeconds(5f);
            flashingText.text = "";
            yield return new WaitForSeconds(0.6f);
            flashingText.text = "���� �ð��� ������ ���� �г��Ͽ� �� ������ �Ѿ� �ɴϴ�.";
            yield return new WaitForSeconds(5f);
            flashingText.text = "";
            yield return new WaitForSeconds(0.6f);
            flashingText.text = "�г��尡 �Ǹ� ���� �̴Ͼ��� ���� �մϴ�.";
            yield return new WaitForSeconds(5f);
            flashingText.text = "";
            yield return new WaitForSeconds(0.6f);
            flashingText.text = "������ �̴Ͼ��� �Ĵٺ��� �̴Ͼ��� ���ŵ˴ϴ�.";
            yield return new WaitForSeconds(5f);
            flashingText.text = "";
            yield return new WaitForSeconds(0.6f);
            flashingText.text = "�̴Ͼ𿡰� ���ݹ����� �ӵ��� ���ϵ˴ϴ�.";
            yield return new WaitForSeconds(5f);
            flashingText.text = "";
            yield return new WaitForSeconds(0.6f);

        }
    }

}


