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
    [SerializeField] private GameObject gazePointer_target;
    [SerializeField] private GameObject gazePointer_pointer;
    [SerializeField] private GameObject hittedUI;
    [SerializeField] private GameObject EndPoint;
    //미터 알림기
    public GameObject[] disSound;

    [SerializeField] private Scrollbar movement;
    [SerializeField] private Slider gaze;
    [SerializeField] private GameObject movechk_0;
    [SerializeField] private GameObject movechk_1;

    bool fiveM = false;
    bool fourM = false;
    bool treeM = false;
    bool twoM = false;
    bool firstM = false;

    public bool survival = true;
    // 승리 시 폭발 이팩트
    public GameObject[] winExplosion;

    public static UIMng Instance = null;

    //자세교정 슬라이더바에 만들 이펙트
    public GameObject ef0;
    public GameObject ef1;

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
        if (survival == true) ui_distance.text = (-1 * (EndPoint.transform.position.z)) + ((int)GameMng.Instance.currentdistance) + "M";
        else ui_distance.text = -1 * ((int)GameMng.Instance.currentdistance) + "M";
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
        
        gameWinUI.transform.Find("Time").GetComponent<Text>().text= string.Format("운동 시간 : {0:00} : {1:00} : {2:00}",
             GameMng.Instance.minutes, GameMng.Instance.seconds, GameMng.Instance.fraction);

        gameWinUI.transform.Find("Kcal").GetComponent<Text>().text = string.Format("소요 칼로리 : {0} kcal", (int)GameMng.Instance.Kcal);
        
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

        gameOverUI.transform.Find("Kcal").GetComponent<Text>().text = string.Format("소요 칼로리 : {0} kcal", (int)GameMng.Instance.Kcal);

    }
    public void update_gameEnd()
    {
        
        Button btn = gameEndUI.transform.Find("MainMenu").GetComponent<Button>();

        btn.onClick.AddListener(UpdatetodayDo);

        gameEndUI.SetActive(true);

        gameEndUI.transform.Find("Time").GetComponent<Text>().text = string.Format("운동 시간 : {0:00} : {1:00} : {2:00}",
             GameMng.Instance.minutes, GameMng.Instance.seconds, GameMng.Instance.fraction);

        gameEndUI.transform.Find("Kcal").GetComponent<Text>().text = string.Format("소요 칼로리 : {0} kcal", (int)GameMng.Instance.Kcal);

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

        countdownText.text = "시작!";
        yield return new WaitForSeconds(1f);

        countdown.SetActive(false);
    }

    public void on_gazePointer_target()
    {
        gazePointer_target.SetActive(true);
    }
    public void off_gazePointer_target()
    {
        gazePointer_target.SetActive(false);
    }

    public void on_gazePointer_pointer()
    {
        gazePointer_pointer.SetActive(true);
    }
    public void off_gazePointer_pointer()
    {
        gazePointer_pointer.SetActive(false);
    }

    private void LateUpdate()
    {
        if (SceneManager.GetActiveScene().name != "Mode1" &&
            SceneManager.GetActiveScene().name != "Mode2" &&
            SceneManager.GetActiveScene().name != "Mode3")
            return;
       
        if (GameMng.Instance.goaldistance <= 200f && fiveM == false) //200미터 남았을 때
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

    public IEnumerator HittedUI()
    {
        hittedUI.SetActive(true);
        yield return new WaitForSeconds(3f);
        hittedUI.SetActive(false);
    }

    public float gazevalue = 0;
    public void gazefill()
    {
        gazevalue += 0.1f;
        if (gazevalue > 1.0)
        {
            gazevalue = 1;
        }
    }

    private bool move_chk = true;

    public void Movement(float value)
    {
        movechk_1.SetActive(move_chk);
        movechk_0.SetActive(!move_chk);

        value = Mathf.InverseLerp(ServerConn.Instance.min, ServerConn.Instance.max, value);
        movement.value = value;

        int boolInt = move_chk ? 1 : 0;

        if (movement.value == boolInt)
        {
            gazefill();
            move_chk = !move_chk;
            SoundMng.Instance.Dding_s();

            if (boolInt == 1)
            {
                ef1.SetActive(true);
                ef0.SetActive(false);
            }
            else
            {
                ef1.SetActive(false);
                ef0.SetActive(true);
            }

        }
    }
}

