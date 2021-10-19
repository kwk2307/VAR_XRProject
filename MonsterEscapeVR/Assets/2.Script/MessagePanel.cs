using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MessagePanel : MonoBehaviour
{
    public Text Messagetext;
    public GameObject messagePanel;
    public GameObject Exitpanel;
    private void Start()
    {
        messagePanel.SetActive(true);

        if (SceneManager.GetActiveScene().name == "Mode1")
        {
            StartCoroutine("say1");
        }
        else if (SceneManager.GetActiveScene().name == "Mode2")
        {
            StartCoroutine("say2");
        }
        else if (SceneManager.GetActiveScene().name == "Mode3")
        {
            StartCoroutine("say3");
        }
        else if (SceneManager.GetActiveScene().name == "Mode4")
        {
            StartCoroutine("say4");
        }
    }


    IEnumerator say1()
    {
        Messagetext.text = "�Ƹ������� Ż���ϱ� ���� ���� �踦 �����...";
        yield return new WaitForSeconds(3);
        Messagetext.text = "������ �ֺ��� �Ǿ�� ��ǵ���Ͽ� Ż���� �����ʾ� ���δ�...";
        yield return new WaitForSeconds(3);
        Messagetext.text = "�Ǿ��� �߰��� �Ѹ�ġ�� �Ƹ����� Ż������!";
        yield return new WaitForSeconds(3);
        messagePanel.SetActive(false);
        SoundMng.Instance.GameStartSound();
        UIMng.Instance.CountDown();
        yield return new WaitForSeconds(3);
        GameMng.Instance.playerState = state.playing;
        
    }
    IEnumerator say2()
    {
        Messagetext.text = "��ȭ�ο� ����Ʈ�� �� ��Ÿ����!";
        yield return new WaitForSeconds(3);
        Messagetext.text = "���ָ� ���� �ڽ��� ������ �ܺ����� ħ���Ѱ� ���� ������ �ϴµ��ϴ�...";
        yield return new WaitForSeconds(3);
        Messagetext.text = "�г��� ����� �߰��� �Ѹ�ġ�� ������ �����Ķ�!";
        yield return new WaitForSeconds(3);
        messagePanel.SetActive(false);
        SoundMng.Instance.GameStartSound();
        UIMng.Instance.CountDown();
        yield return new WaitForSeconds(3);
        GameMng.Instance.playerState = state.playing;

    }
    IEnumerator say3()
    {
        Messagetext.text = "������ �ٴٱ��� ũ������ �����ߴ�!";
        yield return new WaitForSeconds(3);
        Messagetext.text = "�̹� �ֺ��� �Լ����� ��� ħ���߰� ����� ����Ʈ�� ���� Ż�⿡ �����ߴ�!";
        yield return new WaitForSeconds(3);
        Messagetext.text = "������ �ٴٱ��� ũ�������� ���� �����Ķ�!";
        yield return new WaitForSeconds(3);
        messagePanel.SetActive(false);
        SoundMng.Instance.GameStartSound();
        UIMng.Instance.CountDown();
        yield return new WaitForSeconds(3);
        GameMng.Instance.playerState = state.playing;
        
    }
    IEnumerator say4()
    {
        Exitpanel.SetActive(false);
        Messagetext.text = "�̰��� ����ġ�� �Դϴ�.";
        yield return new WaitForSeconds(5);
        Messagetext.text = "������ ���ð� ���� �ð� ��������!";
        yield return new WaitForSeconds(5);
        messagePanel.SetActive(false);
        Exitpanel.SetActive(true);
        GameMng.Instance.playerState = state.playing;
    }
}
