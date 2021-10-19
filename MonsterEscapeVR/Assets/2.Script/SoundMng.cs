using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMng : Singleton<SoundMng>
{
    private AudioSource bm;
    private AudioSource GameOverSound;
    private AudioSource CountDownSound;
    private AudioSource EnemySound;
    public AudioSource toggleSound;

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
        GameOverSound = GameObject.Find("GameOverSound").GetComponent<AudioSource>();
        CountDownSound = GameObject.Find("CountDownSound").GetComponent<AudioSource>();
        EnemySound = GameObject.Find("EnemySound").GetComponent<AudioSource>();

    }

    public void GameStartSound()
    {
        
        StartCoroutine(GameStart_C());
    }
    public void GameOver_s()
    {
        bm.Stop();
        GameOverSound.Play();
    }
    public void Enemy_s()
    {
        EnemySound.Play();
    }

    IEnumerator GameStart_C()
    {
        CountDownSound.Play();
        yield return new WaitForSeconds(3);
        bm.Play();
    }




}
