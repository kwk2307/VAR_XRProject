using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMng : MonoBehaviour
{
    [SerializeField] private Text ui_distance;
    [SerializeField] private Text ui_time;
    [SerializeField] private Slider progress;
    [SerializeField] private GameObject gameWinUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject countdown;
    public GameObject VictoryEffectBox;
    [SerializeField] private GameObject gazePointer;

    public static UIMng Instance = null;

    private void Awake()
    {
         if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        gazePointer.SetActive(false);
        gameWinUI.SetActive(false);
        gameOverUI.SetActive(false);
        countdown.SetActive(false);
    }

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
        gazePointer.SetActive(true);
        VictoryEffectBox.SetActive(true);
        gameWinUI.transform.Find("Time").GetComponent<Text>().text= string.Format("{0:00} : {1:00} : {2:00}",
             GameMng.Instance.minutes, GameMng.Instance.seconds, GameMng.Instance.fraction);
    }
    public void update_gameOverUI()
    {
        gameOverUI.SetActive(true);
        gazePointer.SetActive(true);
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

        countdownText.text = "����!";
        yield return new WaitForSeconds(1f);

        countdown.SetActive(false);
    }

    public void update_gazePointer()
    {
        gazePointer.SetActive(true);
    }
}

