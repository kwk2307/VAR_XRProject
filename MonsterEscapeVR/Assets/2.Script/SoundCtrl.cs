using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCtrl : MonoBehaviour
{
    AudioSource bm;
    float count;
    bool isPlay;
    Animator ani; //각 적의 애니를 담을 것임
    AudioSource GameOverSound;

    public int gameMode = 1;

    bool gameOver = false;
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

        ani = GameObject.Find("Enemy").GetComponent<Animator>();
        GameOverSound = GameObject.Find("GameOverSound").GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if(count >= 3 && isPlay == false )
        {
            bm.Play();
            isPlay = true;
        }


        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Bite"))
        {
            if(gameOver == false)
            {
                GameOverSound.Play();
                gameOver = true;

            }
            
            StartCoroutine(FadeOut());

        }

        IEnumerator FadeOut()
        {
            bm.volume -= 0.001f;
            yield return 1;
        }
        
    }
}
