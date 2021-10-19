using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Raycast : MonoBehaviour
{
    public Image Gazepointer;

    private float timeElapsed = 0;

    public GameObject Toggle;
    AudioSource ToggleSound;

    //페이드인을 위한 변수들
    private float fadeTime = 2f;
    public Image fadeImg;
    private float alpha=0;
    private bool fadeBool = false;
    private bool enterFade = false;

    bool getEvent = false; //화면 로드가 여러번 되는 것을 막기위해
    void Start()
    {
        ToggleSound = Toggle.GetComponent<AudioSource>();
        ToggleSound.Stop();


    }


    void Update()
    {
        if(enterFade == true)
        {
            if (fadeBool == false)
            {
                StartCoroutine(StartFade());
            }

        }


        RaycastHit hit;//오브젝트 정보

        Vector3 forward = transform.TransformDirection(Vector3.forward * 1000);//방향
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(this.transform.position, forward, out hit))
        {
            if(hit.transform.tag == "UI") //부딪힌 대상이 UI라면
            {
                timeElapsed += Time.deltaTime;//시간 증가
                Gazepointer.fillAmount = timeElapsed / 2;//이미지 fill 채워줌

                if (timeElapsed >= 2 && getEvent == false)//2초가 되면
                {
                    //버튼 효과음 재생
                    ToggleSound.Play();

                    enterFade = true; //페이드 아웃 효과 발생

                    //버튼 onClick 이벤트 발생
                    hit.transform.GetComponent<Button>().onClick.Invoke();


                    DontDestroyOnLoad(Toggle); //씬 전환해도 소리가 계속 나도록.
                                               //timeElapsed = 0;
                    getEvent = true; //중복실행 방지

                }
            }

            
        }
        else
        {
            timeElapsed -= Time.deltaTime;
            Gazepointer.fillAmount = timeElapsed / 2;

            if (timeElapsed <= 0) timeElapsed = 0;
        }
    }
    
    IEnumerator StartFade()
    {
        fadeBool = true;
        alpha += 1.6f*Time.deltaTime;
        fadeImg.color = new Color(0, 0, 0, alpha);
        yield return new WaitForSeconds(0.008f);
        fadeBool = false;
    }
}
