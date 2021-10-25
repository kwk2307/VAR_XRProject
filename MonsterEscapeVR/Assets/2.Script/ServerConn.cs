using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ServerConn : Singleton<ServerConn>
{

    private string userCode = "test";

    public string curWeight = "1";
    public string goalWeight = "1";
    public string term = "1";

    public string[] str;


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

    public IEnumerator SendSearchUser()
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
            //print(www.downloadHandler.text);
            str = www.downloadHandler.text.Split(',');
        }  
    }
    public IEnumerator SendSearchtodayDo()
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
            str = www.downloadHandler.text.Split(',');
        }
    }

    public IEnumerator SendSearchallDo()
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
            str = www.downloadHandler.text.Split(',');
        }
    }

    public IEnumerator SendUpdateuser(string curWeight, string goalWeight, string term)
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("userCode", userCode);
        dic.Add("curWeight", curWeight);
        dic.Add("goalWeight", goalWeight);
        dic.Add("term", term);

        UnityWebRequest www = UnityWebRequest.Post("http://192.168.1.40/update_ME_user.php", dic);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            print(www.error);
        }

    }


    public IEnumerator SendUpdatetodayDo(string useTime, string useCal, string useDis)
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

    }

    public IEnumerator SendUpdateallDo(string useTime, string useCal, string useDis)
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

    }
}

