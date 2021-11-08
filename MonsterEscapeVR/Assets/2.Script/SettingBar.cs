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
        useTime.text += string.Format("{0:00} ", ServerConn.Instance.str[0]);
        useCal.text += "   " + ServerConn.Instance.str[1];
    }

    public void Update_SettingBar()
    {
        loginBefroe.SetActive(false);
        loginAfter.SetActive(true);
        StartCoroutine(searchtodayDo());
    }

}
