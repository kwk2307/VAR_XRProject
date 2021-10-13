using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Tutorial : MonoBehaviour
{
    Text text;
    float time;
    public GameObject WarnUp;//워밍업 영상
    public VideoPlayer WarmUpVideo;
    public GameObject rowing; //로잉영상
    public VideoPlayer rowingPlayer;

    [SerializeField] private Animator anim_boat;
    float waitTime;

    bool startRowing = false;
    bool cancelRowing = false;
    GameObject sideCam;

    AudioSource clear;
    public GameObject[] announce;




    void Start()
    {
        text= GameObject.Find("Text").GetComponent<Text>();
        WarmUpVideo.Stop();
        rowingPlayer.Stop();
       

        StartCoroutine("Greet");

        sideCam = GameObject.Find("SideView");
        sideCam.SetActive(false);

        clear = GameObject.Find("ClearSound").GetComponent<AudioSource>();

        

    }

    // Update is called once per frame
    void Update()
    {

        if (startRowing == true)
        {
            if (anim_boat.GetFloat("Position") >= 0.8f)
            {
                clear.Play();
                text.text = "잘 하셨습니다.  다시 앞으로 가보겠습니다.";
                announce[3].SetActive(true);
                cancelRowing = true;
                startRowing = false;
                
            }
            
        }
        if(cancelRowing == true)
        {
            //앞으로 놓으면
            if (anim_boat.GetFloat("Position") <= 0.2f)
            {
                clear.Play();
                text.text = "잘 하셨습니다.";
                announce[4].SetActive(true);
                cancelRowing = false;
            }


        }


    }
    IEnumerator Greet()
    {
        text.text = "Monster Eescape에 오신 것을 환영합니다";
        yield return new WaitForSeconds(3);
        text.text = "이제부터 간단한 준비운동을 시작하겠습니다";
        yield return new WaitForSeconds(4.5f);
        text.text = "안전을 위해 로잉머신에 앉은채로 따라해주세요";
        yield return new WaitForSeconds(6.5f);
        WarnUp.SetActive(true);
        WarmUpVideo.Play();
        yield return new WaitForSeconds((float)(WarmUpVideo.length)); //동영상 길이만큼 기다린다.
        
            WarnUp.SetActive(false);
            StartCoroutine(GuideRowing());
        

    }
    IEnumerator GuideRowing()
    {

        text.text = "본격적으로 로잉머신의 사용법을 배워보겠습니다";
        announce[0].SetActive(true);
        yield return new WaitForSeconds(3);
        //로잉머신 동영상 재생
        rowing.SetActive(true);
        rowingPlayer.Play();
        yield return new WaitForSeconds((float)(rowingPlayer.length)); //동영상 길이만큼 기다린다.
        rowing.SetActive(false);

        text.text = "이제 직접 해보겠습니다";
        announce[1].SetActive(true);
        sideCam.SetActive(true);
        yield return new WaitForSeconds(3);
        text.text = "당겨보세요";
        announce[2].SetActive(true);
        startRowing = true;

    }
}
