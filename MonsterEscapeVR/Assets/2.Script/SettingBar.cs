using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingBar : MonoBehaviour
{
    [SerializeField] private Text useTime;
    [SerializeField] private Text useCal;
    [SerializeField] private GameObject loginAfter;
    [SerializeField] private GameObject loginBefroe;

    // Start is called before the first frame update
    void Start()
    {

        if (ServerConn.Instance.isLogin == true)
        {
            loginBefroe.SetActive(false);
            loginAfter.SetActive(true);
            StartCoroutine(searchtodayDo());
        }
        
    }
    IEnumerator searchtodayDo()
    {
        yield return StartCoroutine(ServerConn.Instance.SendSearchtodayDo());
        int time = int.Parse(ServerConn.Instance.str[0]);

        useTime.text += string.Format("   {0:00} : {1:00} : {2:00}", (int)Mathf.Floor(time / 60), (int)time % 60, (int)(time * 100) % 100);
        useCal.text += "   " + ServerConn.Instance.str[1] +"  kcal";
    }

    public void Update_SettingBar()
    {
        loginBefroe.SetActive(false);
        loginAfter.SetActive(true);
        StartCoroutine(searchtodayDo());
    }

}
