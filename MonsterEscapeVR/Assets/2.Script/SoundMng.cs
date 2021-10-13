using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMng : Singleton<SoundMng>
{
    AudioSource bm;
    AudioSource GameOverSound;
    AudioSource CountDownSound;
    float count;
    bool isPlay;
    Animator ani; //각 적의 애니를 담을 것임
    
    public int gameMode = 1;
    void Start()
    {
        if (gameMode == 1) //각 모드에 맞는 브금 가져오기
        {
            bm = GameObject.Find("BGM_1").GetComponent<AudioSource>();
        }
        if (gameMode == 2)
        {
            bm = GameObject.Find("BGM_2").GetComponent<AudioSource>();
        }
        if (gameMode == 3)
        {
            bm = GameObject.Find("BGM_3").GetComponent<AudioSource>();
        }

        bm.Stop();
        isPlay = false;

        GameOverSound = GameObject.Find("GameOverSound").GetComponent<AudioSource>();
        CountDownSound = GameObject.Find("CountDownSound").GetComponent<AudioSource>();
    }

    public void GameStart()
    {
        StartCoroutine(GameStart_C());
    }

    IEnumerator GameStart_C()
    {
        CountDownSound.Play();
        yield return new WaitForSeconds(3);
        bm.Play();
    }

}
