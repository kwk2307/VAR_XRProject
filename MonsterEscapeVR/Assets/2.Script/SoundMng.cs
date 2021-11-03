using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundMng : MonoBehaviour
{
    private AudioSource bm;
    private AudioSource GameOverSound;
    private AudioSource CountDownSound;
    private AudioSource EnemySound;
    private AudioSource ToggleSound;

    public int gameMode;

    public static SoundMng Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        if(gameMode == 0)
        {
            bm = GameObject.Find("BGM").GetComponent<AudioSource>();
            bm.Play();
        }
        else if (gameMode == 1) //각 모드에 맞는 브금 가져오기
        {
            bm = GameObject.Find("BGM_1").GetComponent<AudioSource>();
        }
        else if (gameMode == 2)
        {
            bm = GameObject.Find("BGM_2").GetComponent<AudioSource>();
        }
        else if (gameMode == 3)
        {
            bm = GameObject.Find("BGM_3").GetComponent<AudioSource>();
        }
        else if(gameMode == 4)
        {
            bm = GameObject.Find("BGM_4").GetComponent<AudioSource>();
            bm.Play();
        }
        else if (gameMode == 5)
        {
            bm = GameObject.Find("BGM_5").GetComponent<AudioSource>();
            bm.Play();
        }
        else if (gameMode == 6)
        {
            bm = GameObject.Find("BGM_6").GetComponent<AudioSource>();
            bm.Play();
        }
        
        GameOverSound = GameObject.Find("GameOverSound").GetComponent<AudioSource>();
        CountDownSound = GameObject.Find("CountDownSound").GetComponent<AudioSource>();
        EnemySound = GameObject.Find("EnemySound").GetComponent<AudioSource>();
        ToggleSound = GameObject.Find("ToggleSound").GetComponent<AudioSource>();
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

    public void ToggleSoundStart()
    {
        ToggleSound.Play();
    }
    
}
