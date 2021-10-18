using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ServerConn : MonoBehaviour
{

    [SerializeField] private string userCode;
    [SerializeField] private string useTime;
    [SerializeField] private string useCal;
    [SerializeField] private string useDis;

    [SerializeField] private string curWeight;
    [SerializeField] private string goalWeight;
    [SerializeField] private string term;

    private void Start()
    {
        StartCoroutine(SendLogin());
    }
    private void OnGUI()
    {
        if (GUI.Button( new Rect(10, 10, 100, 130), "아이디검색"))
        {
            StartCoroutine(SendSearchUser());
        }
    }
    IEnumerator SendLogin()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("userCode", userCode);

        UnityWebRequest www = UnityWebRequest.Post("http://192.168.1.40/login_ME.php", dic);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            print(www.error);
        }
       
    }

    IEnumerator SendSearchUser()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("userCode", userCode);

        UnityWebRequest www = UnityWebRequest.Post("http://192.168.1.40/search_ME_user.php", dic);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            print(www.error);
        }
        else
        {
            print(www.downloadHandler.text);
        }
    }

    IEnumerator SendSearchTodayDo()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("userCode", userCode);

        UnityWebRequest www = UnityWebRequest.Post("http://192.168.1.40/search_ME_todayDo.php", dic);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            print(www.error);
        }
        else
        {
            print(www.downloadHandler.text);
        }
    }

    IEnumerator SendSearchAllDo()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("userCode", userCode);

        UnityWebRequest www = UnityWebRequest.Post("http://192.168.1.40/search_ME_allDo.php", dic);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            print(www.error);
        }
        else
        {
            print(www.downloadHandler.text);
        }
    }

    IEnumerator SendUpdateallDo()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("userCode", userCode);
        dic.Add("useTime", useTime);
        dic.Add("useCal", useCal);
        dic.Add("useDis", useDis);

        UnityWebRequest www = UnityWebRequest.Post("http://192.168.1.40/update_ME_allDo.php", dic);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            print(www.error);
        }
        else
        {
            print(www.downloadHandler.text);
        }
    }

    IEnumerator SendUpdatetodayDo()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("userCode", userCode);
        dic.Add("useTime", useTime);
        dic.Add("useCal", useCal);
        dic.Add("useDis", useDis);

        UnityWebRequest www = UnityWebRequest.Post("http://192.168.1.40/update_ME_todayDo.php", dic);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            print(www.error);
        }
        else
        {
            print(www.downloadHandler.text);
        }
    }
    IEnumerator SendUpdateuser()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("userCode", userCode);
        dic.Add("curWeight", curWeight);
        dic.Add("goalWeight", goalWeight);
        dic.Add("term", term);

        UnityWebRequest www = UnityWebRequest.Post("http://192.168.1.40/update_ME_todayDo.php", dic);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            print(www.error);
        }
        else
        {
            print(www.downloadHandler.text);
        }
    }

}

