using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Valve.VR;
public class SceneMng : MonoBehaviour
{

    private void Start()
    {
        
        //GoToMain();
    }


    public void GotoRanking()
    {
        StartCoroutine(LoadScene("Ranking"));
        
    }
    public void GotoMode1()
    {
        //StartCoroutine(LoadScene("Mode1"));
        SteamVR_LoadLevel.Begin("Mode1");
    }

    public void GotoMode2()
    {
        StartCoroutine(LoadScene("Mode2"));
    }
    public void GotoMode3()
    {
        StartCoroutine(LoadScene("Mode3"));
    }
    public void Gamerule()
    {
        //StartCoroutine(LoadScene("Mode1"));
    }
    public void GoToMain()
    {
        StartCoroutine(LoadScene("MainMenu"));
    }

    public void GotoTutorial()
    {
        StartCoroutine(LoadScene("Tutorial"));
    }
    public void GotoSouthPole()
    {
        StartCoroutine(LoadScene("SouthPole"));
    }
    public void GotoLake()
    {
        StartCoroutine(LoadScene("Lake"));
    }
    public void GotoVenice()
    {
        StartCoroutine(LoadScene("Venice"));
    }

    IEnumerator LoadScene(string sceneName)
    {
        yield return null;

        yield return new WaitForSeconds(2f); //ȭ�� ���̵� �ƿ��� �����ð�

        AsyncOperation asyncOper = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncOper.isDone)
        {
            yield return null;
            Debug.Log(asyncOper.progress);
            //���α׷��� �� ���� �� �� ����
        }

    }

}
