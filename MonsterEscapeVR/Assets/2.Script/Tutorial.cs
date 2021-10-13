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
    [SerializeField] private Animator anim_boat;
    float waitTime;

    bool startRowing = false;
    bool cancelRowing = false;
    GameObject sideCam;



    void Start()
    {
        text= GameObject.Find("Text").GetComponent<Text>();
        WarmUpVideo.Stop();
        StartCoroutine("Greet");

        sideCam = GameObject.Find("SideView");
        sideCam.SetActive(false);
        


    }

    // Update is called once per frame
    void Update()
    {
        print(anim_boat.GetFloat("Position"));

        if (startRowing == true)
        {
            if (anim_boat.GetFloat("Position") >= 0.8f)
            {
                text.text = "잘 하셨습니다. 다시 앞으로 놓겠습니다";
                cancelRowing = true;
                startRowing = false;
                
            }
            
        }
        if(cancelRowing == true)
        {
            //앞으로 놓으면
            if (anim_boat.GetFloat("Position") <= 0.2f)
            {
                text.text = "잘 하셨습니다.";
                cancelRowing = false;
            }


        }


    }
    IEnumerator Greet()
    {
        text.text = "Monster Eescape에 오신 것을 환영합니다";
        yield return new WaitForSeconds(2);
        text.text = "이제부터 간단한 준비운동을 시작하겠습니다";
        yield return new WaitForSeconds(2);
        text.text = "안전을 위해 로잉머신에 앉은채로 따라해주세요";
        yield return new WaitForSeconds(2);
        WarnUp.SetActive(true);
        WarmUpVideo.Play();
        yield return new WaitForSeconds((float)(WarmUpVideo.length)); //동영상 길이만큼 기다린다.
        
            WarnUp.SetActive(false);
            StartCoroutine(GuideRowing());
        

    }
    IEnumerator GuideRowing()
    {

        text.text = "본격적으로 로잉머신의 사용법을 배워보겠습니다";
        yield return new WaitForSeconds(5);
        //로잉머신 동영상 재생

        text.text = "이제 한 번 해보겠습니다";
        sideCam.SetActive(true);
        yield return new WaitForSeconds(5);
        text.text = "당겨보세요";
        startRowing = true;

    }
}
