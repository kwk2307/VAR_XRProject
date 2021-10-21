using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Valve.VR;
public class SceneMng : MonoBehaviour
{

    private void Start()
    {
        
        //GoToMain();
    }
    
    public void GotoMode1()
    {
        //StartCoroutine(LoadScene("Mode1"));
        SteamVR_LoadLevel.Begin("Mode1");
    }

    public void GotoMode2()
    {
        //StartCoroutine(LoadScene("Mode2"));
        SteamVR_LoadLevel.Begin("Mode2");
    }
    public void GotoMode3()
    {
        //StartCoroutine(LoadScene("Mode3"));
        SteamVR_LoadLevel.Begin("Mode3");
    }
    public void GotoMode4()
    {
        StartCoroutine(LoadScene("Mode4"));
    }
    public void Gamerule()
    {
        //StartCoroutine(LoadScene("Mode1"));
    }
    public void GoToMain()
    {
        //StartCoroutine(LoadScene("MainMenu"));
        SteamVR_LoadLevel.Begin("MainMenu");
    }

    public void GotoTutorial()
    {
        //StartCoroutine(LoadScene("Tutorial"));
        SteamVR_LoadLevel.Begin("Tutorial");
    }
    public void GotoSouthPole()
    {
        //StartCoroutine(LoadScene("SouthPole"));
        SteamVR_LoadLevel.Begin("SouthPole");
    }
    public void GotoLake()
    {
        //StartCoroutine(LoadScene("Lake"));
        SteamVR_LoadLevel.Begin("Lake");
    }
    public void GotoVenice()
    {
        //StartCoroutine(LoadScene("Venice"));
        SteamVR_LoadLevel.Begin("Venice");
    }

    IEnumerator LoadScene(string sceneName)
    {
        yield return null;

        yield return new WaitForSeconds(2f); //화면 페이드 아웃될 여유시간

        AsyncOperation asyncOper = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncOper.isDone)
        {
            yield return null;
            Debug.Log(asyncOper.progress);
            //프로그레스 바 구현 할 수 있음
        }

    }

}
