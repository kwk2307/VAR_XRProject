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
        SteamVR_LoadLevel.Begin("Mode4");

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



}
