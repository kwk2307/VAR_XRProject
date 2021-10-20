using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingBar : MonoBehaviour
{
    [SerializeField] private Text useTime;
    [SerializeField] private Text useCal;

    // Start is called before the first frame update
    void Start()
    {
        //Text useTime = transform.Find("useTime").GetComponent<Text>();
        //Text useCal = transform.Find("useCal").GetComponent<Text>();
        StartCoroutine(searchtodayDo());
    }
    IEnumerator searchtodayDo()
    {
        yield return StartCoroutine(ServerConn.Instance.SendSearchtodayDo());

        if(ServerConn.Instance.str.Length != 0)
        {
            useTime.text += "   " + ServerConn.Instance.str[0];
            useCal.text += "   " + ServerConn.Instance.str[1];
        }
    }
    
}
