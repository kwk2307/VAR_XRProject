using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMng : Singleton<UIMng>
{

    private GameObject VictoryEffectBox;
    
    private void Start()
    {
        DontDestroyOnLoad(this);
        VictoryEffectBox = transform.Find("Victory Particle").gameObject;
    }

    public void update_distance()
    {

        Text ui_distance = GameObject.Find("Distance").GetComponent<Text>();
        ui_distance.text = (-1 * (int)GameMng.Instance.currentdistance) + "M";
       
    }

    public void update_time()
    {
        Text ui_time = GameObject.Find("Current").GetComponent<Text>();
        ui_time.text = string.Format("{0:00} : {1:00} : {2:00}",
             GameMng.Instance.minutes, GameMng.Instance.seconds, GameMng.Instance.fraction);
    }

    public void update_gameWinUI()
    {
        Transform gameWinUI = GameObject.Find("PlayerCanvas").transform.Find("GameOverUI_Win");
        gameWinUI.gameObject.SetActive(true);
        VictoryEffectBox.SetActive(true);
        gameWinUI.transform.Find("Time").GetComponent<Text>().text= string.Format("{0:00} : {1:00} : {2:00}",
             GameMng.Instance.minutes, GameMng.Instance.seconds, GameMng.Instance.fraction);
    }
    public void update_gameOverUI()
    {
        Transform gameOverUI = GameObject.Find("PlayerCanvas").transform.Find("GameOverUI_Fail");
        gameOverUI.gameObject.SetActive(true);
        //gameWinUI.transform.Find("Time").GetComponent<Text>().text = string.Format("{0:00} : {1:00} : {2:00}",
        //     GameMng.Instance.minutes, GameMng.Instance.seconds, GameMng.Instance.fraction);
    }

    public void CountDown()
    {
        StartCoroutine(Count());
    }

    IEnumerator Count()
    {
        Transform countdown = GameObject.Find("PlayerCanvas").transform.Find("CountDown");
        countdown.gameObject.SetActive(true);
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

        countdown.gameObject.SetActive(false);
    }
}

