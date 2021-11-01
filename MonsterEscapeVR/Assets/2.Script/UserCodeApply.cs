using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UserCodeApply : MonoBehaviour
{
    [SerializeField] private GameObject settingBar;
    [SerializeField] private Text userCode;

    
    public void Click()
    {
        StartCoroutine(Login());
    }

    IEnumerator Login()
    {
        yield return StartCoroutine(ServerConn.Instance.SendLogin(userCode.text));
        yield return StartCoroutine(ServerConn.Instance.SendSearchUser());
        
        ServerConn.Instance.isLogin = true;
        //여기에 함수를 넣어줘야지 제대로 실행
        settingBar.GetComponent<SettingBar>().Update_SettingBar();    

        this.transform.parent.gameObject.SetActive(false);
         
    }


    
}
