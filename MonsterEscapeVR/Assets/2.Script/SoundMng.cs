using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundMng : Singleton<SoundMng>
{
    private AudioSource bm;
    private AudioSource GameOverSound;
    private AudioSource CountDownSound;
    private AudioSource EnemySound;
    private AudioSource ToggleSound;
    
    private void Start()
    {
        bm = GameObject.Find("BGM").GetComponent<AudioSource>();

        GameOverSound = GameObject.Find("GameOverSound").GetComponent<AudioSource>();
        CountDownSound = GameObject.Find("CountDownSound").GetComponent<AudioSource>();
        EnemySound = GameObject.Find("EnemySound").GetComponent<AudioSource>();
        ToggleSound = GameObject.Find("ToggleSound").GetComponent<AudioSource>();
    }

    public void MainMenuSoundPlay()
    {
        bm = GameObject.Find("BGM").GetComponent<AudioSource>();
        bm.Play();
    }
    public void ToggleSoundPlay()
    {
        ToggleSound.Play();
    }

    public void GameStartSound()
    {
        StartCoroutine(GameStart_c());
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

    IEnumerator GameStart_c()
    {

        bm.Stop();
        CountDownSound.Play();
        yield return new WaitForSeconds(3);

        if (SceneManager.GetActiveScene().name == "Mode1") //각 모드에 맞는 브금 가져오기
        {
            bm = GameObject.Find("BGM_1").GetComponent<AudioSource>();
        }
        else if (SceneManager.GetActiveScene().name == "Mode2")
        {
            bm = GameObject.Find("BGM_2").GetComponent<AudioSource>();
        }
        else if (SceneManager.GetActiveScene().name == "Mode3")
        {
            bm = GameObject.Find("BGM_3").GetComponent<AudioSource>();
        }
        bm.Play();
    }

}
