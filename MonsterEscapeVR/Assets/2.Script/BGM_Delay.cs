using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Delay : MonoBehaviour
{
    AudioSource bm;
    float count;
    bool isPlay;
    Animator ani; //각 적의 애니를 담을 것임
    AudioSource GameOverSound;

    bool gameOver = false;
    void Start()
    {
        bm = this.gameObject.GetComponent<AudioSource>();
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
