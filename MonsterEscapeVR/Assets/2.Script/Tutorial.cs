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




    void Start()
    {
        text= GameObject.Find("Text").GetComponent<Text>();
        WarmUpVideo.Stop();
        StartCoroutine("Greet");
       
    }

    // Update is called once per frame
    void Update()
    {
       //print(anim_boat.GetFloat("isRow"));
        //print(WarmUpVideo.isPlaying);
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
        yield return new WaitForSeconds(2);
        
        if(WarmUpVideo.isPlaying == true)
        {
            WarnUp.SetActive(false);
            StartCoroutine(GuideRowing());
        }

    }
    IEnumerator GuideRowing()
    {

        text.text = "본격적으로 로잉머신의 사용법을 배워보겠습니다";
        yield return new WaitForSeconds(5);
        //로잉머신 동영상 재생

        text.text = "이제 한 번 해보겠습니다";
        yield return new WaitForSeconds(5);
        text.text = "당겨보세요";

        //끝까지 당기면
        if(anim_boat.GetFloat("isRow") >= 0.8f)
        {
            text.text = "잘 하셨습니다. 다시 앞으로 놓겠습니다";
        }

        //앞으로 놓으면
        if (anim_boat.GetFloat("isRow") <= 0.2f)
        {
            text.text = "잘 하셨습니다.";
        }
        
        yield return new WaitForSeconds(5);
        text.text = "완전한 동작으로 해보겠습니다";

        //다 하면
        text.text = "잘 하셨습니다.";


    }
}
