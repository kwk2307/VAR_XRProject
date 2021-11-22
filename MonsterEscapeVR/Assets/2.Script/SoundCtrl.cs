using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCtrl : MonoBehaviour
{
    AudioSource bm;
    float count;
    bool isPlay;
    Animator ani; //�� ���� �ִϸ� ���� ����
    AudioSource GameOverSound;
    [SerializeField] private AudioSource CountDownSound;

    public int gameMode = 1;

    bool gameOver = false;
    void Start()
    {
        if (gameMode == 1) //�� ��忡 �´� ��� ��������
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
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Bite")) //���ӿ����� ���� ����
        {
            if (gameOver == false)
            {
                GameOverSound.Play();
                gameOver = true;
            }

            StartCoroutine(FadeOut());
        }

    }
    IEnumerator FadeOut()
    {
        bm.volume -= 0.001f;
        yield return 1;
    }
    IEnumerator GameStart()
    {
        CountDownSound.Play();
        yield return new WaitForSeconds(3);
        bm.Play();
    }

}
