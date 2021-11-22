using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIMng : MonoBehaviour
{
    [SerializeField] private Text ui_distance;
    [SerializeField] private Text ui_time;

    [SerializeField] private GameObject gameWinUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject gameEndUI;
    [SerializeField] private GameObject countdown;
    public GameObject VictoryEffectBox;
    [SerializeField] private GameObject gazePointer;

    //���� �˸���
    public GameObject[] disSound;
    bool fiveM = false;
    bool fourM = false;
    bool treeM = false;
    bool twoM = false;
    bool firstM = false;

    // �¸� �� ���� ����Ʈ
    public GameObject[] winExplosion;

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
        gameWinUI.SetActive(false);
        gameOverUI.SetActive(false);
        countdown.SetActive(false);
    }

    public void update_distance()
    {
        ui_distance.text = (-1 * (int)GameMng.Instance.currentdistance) + "M";
        
    }

    public void update_time()
    {
        ui_time.text = string.Format("{0:00} : {1:00} : {2:00}",
             GameMng.Instance.minutes, GameMng.Instance.seconds, GameMng.Instance.fraction);
    }

    public void UpdatetodayDo()
    {
        StartCoroutine(ServerConn.Instance.SendUpdatetodayDo(GameMng.Instance.time.ToString(),GameMng.Instance.Kcal.ToString()," "));
    }

    public void update_gameWinUI()
    {
        Button btn = gameWinUI.transform.Find("MainMenu").GetComponent<Button>();
        btn.onClick.AddListener(UpdatetodayDo);
       
        gameWinUI.SetActive(true);
        
        VictoryEffectBox.SetActive(true);
        
        gameWinUI.transform.Find("Time").GetComponent<Text>().text= string.Format("� �ð� : {0:00} : {1:00} : {2:00}",
             GameMng.Instance.minutes, GameMng.Instance.seconds, GameMng.Instance.fraction);

        gameWinUI.transform.Find("Kcal").GetComponent<Text>().text = string.Format("�ҿ� Į�θ� : {0} kcal", (int)GameMng.Instance.Kcal);
        
        for (int i = 0; i < 6; i++)
        {
            winExplosion[i].SetActive(true);
        }
    }
    public void update_gameOverUI()
    {

        Button btn = gameOverUI.transform.Find("MainMenu").GetComponent<Button>();
        btn.onClick.AddListener(UpdatetodayDo);

        gameOverUI.SetActive(true);

        gameOverUI.transform.Find("Kcal").GetComponent<Text>().text = string.Format("�ҿ� Į�θ� : {0} kcal", (int)GameMng.Instance.Kcal);

    }
    public void update_gameEnd()
    {
        
        Button btn = gameEndUI.transform.Find("MainMenu").GetComponent<Button>();

        btn.onClick.AddListener(UpdatetodayDo);

        gameEndUI.SetActive(true);

        gameEndUI.transform.Find("Time").GetComponent<Text>().text = string.Format("� �ð� : {0:00} : {1:00} : {2:00}",
             GameMng.Instance.minutes, GameMng.Instance.seconds, GameMng.Instance.fraction);

        gameEndUI.transform.Find("Kcal").GetComponent<Text>().text = string.Format("�ҿ� Į�θ� : {0} kcal", (int)GameMng.Instance.Kcal);

    }

    public void CountDown()
    {
        StartCoroutine(Count());
    }

    IEnumerator Count()
    {
        countdown.SetActive(true);
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
    public void off_gazePointer()
    {
        gazePointer.SetActive(false);
    }
    
    private void LateUpdate()
    {
        if (SceneManager.GetActiveScene().name != "Mode1" &&
            SceneManager.GetActiveScene().name != "Mode2" &&
            SceneManager.GetActiveScene().name != "Mode3")
            return;
       
        if (GameMng.Instance.goaldistance <= 200f && fiveM == false) //200���� ������ ��
        {
            disSound[0].SetActive(true);
            fiveM = true;
        }
        if (GameMng.Instance.goaldistance <= 150f && fourM == false)
        {
            disSound[1].SetActive(true);
            fourM = true;
        }
        if (GameMng.Instance.goaldistance <= 100f && treeM == false)
        {
            disSound[2].SetActive(true);
            treeM = true;
        }
        if (GameMng.Instance.goaldistance <= 50f && twoM == false)
        {
            disSound[3].SetActive(true);
            twoM = true;
        }
    }
}

