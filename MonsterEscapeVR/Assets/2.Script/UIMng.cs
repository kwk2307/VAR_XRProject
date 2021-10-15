using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMng : Singleton<UIMng>
{
    [SerializeField] private Text ui_distance;
    [SerializeField] private Text ui_time;
    [SerializeField] private Slider progress;
    [SerializeField] private GameObject gameWinUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject countdown;

    public void update_distance()
    {
        ui_distance.text = (-1 * (int)GameMng.Instance.currentdistance) + "M";
        if(progress != null)
        {
            progress.value = (50 - GameMng.Instance.currentdistance) / 50;
        }
    }

    public void update_time()
    {
        ui_time.text = string.Format("{0:00} : {1:00} : {2:00}",
             GameMng.Instance.minutes, GameMng.Instance.seconds, GameMng.Instance.fraction);
    }

    public void update_gameWinUI()
    {
        gameWinUI.SetActive(true);
        gameWinUI.transform.Find("Time").GetComponent<Text>().text= string.Format("{0:00} : {1:00} : {2:00}",
             GameMng.Instance.minutes, GameMng.Instance.seconds, GameMng.Instance.fraction);
    }
    public void update_gameOverUI()
    {
        gameOverUI.SetActive(true);
        //gameWinUI.transform.Find("Time").GetComponent<Text>().text = string.Format("{0:00} : {1:00} : {2:00}",
        //     GameMng.Instance.minutes, GameMng.Instance.seconds, GameMng.Instance.fraction);
    }

    public void CountDown()
    {

        StartCoroutine(Count());
    }

    IEnumerator Count()
    {
        countdown.SetActive(true);
        print("countdown setActive true");
        Text countdownText = countdown.GetComponent<Text>();

        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        countdownText.text = "Ω√¿€!";
        yield return new WaitForSeconds(1f);

        countdown.SetActive(false);
    }

}

