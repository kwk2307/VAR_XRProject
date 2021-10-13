using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MessagePanel : MonoBehaviour
{
    public Text Messagetext;
    public GameObject messagePanel;
    void Start()
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

    }


    IEnumerator say1()
    {
        Messagetext.text = "아마존에서 탈출하기 위해 드디어 배를 띄웠다...";
        yield return new WaitForSeconds(3);
        Messagetext.text = "하지만 주변엔 악어떼가 득실득실하여 탈출이 쉽지않아 보인다...";
        yield return new WaitForSeconds(3);
        Messagetext.text = "악어의 추격을 뿌리치고 아마존을 탈출하자!";
        yield return new WaitForSeconds(3);
        messagePanel.SetActive(false);
        SoundMng.Instance.GameStart();
        UIMng.Instance.CountDown();

    }
    IEnumerator say2()
    {
        Messagetext.text = "평화로운 리조트에 상어가 나타났다!";
        yield return new WaitForSeconds(3);
        Messagetext.text = "굶주린 상어는 자신의 영역에 외부인이 침입한걸 몹시 불쾌해 하는듯하다...";
        yield return new WaitForSeconds(3);
        Messagetext.text = "분노한 상어의 추격을 뿌리치고 육지로 도망쳐라!";
        yield return new WaitForSeconds(3);
        messagePanel.SetActive(false);

    }
    IEnumerator say3()
    {
        Messagetext.text = "전설의 바다괴물 크라켄이 등장했다!";
        yield return new WaitForSeconds(3);
        Messagetext.text = "이미 주변의 함선들은 모두 침몰했고 가까스로 구명보트를 꺼내 탈출에 성공";
        yield return new WaitForSeconds(3);
        Messagetext.text = "전설의 바다괴물 크라켄으로 부터 도망쳐라!";
        yield return new WaitForSeconds(3);
        messagePanel.SetActive(false);


    }

}
