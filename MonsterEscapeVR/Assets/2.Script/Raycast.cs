using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Raycast : MonoBehaviour
{
    public Image Gazepointer;

    private float timeElapsed = 0;

    //페이드인을 위한 변수들

    private bool enterFade = false;

    bool getEvent = false; //화면 로드가 여러번 되는 것을 막기위해

    void Update()
    {
       
        RaycastHit hit;//오브젝트 정보

        Vector3 forward = transform.TransformDirection(Vector3.forward);//방향
        //UI레이어만 걸림
        LayerMask layerMask = 1 << LayerMask.NameToLayer("UI");

        if (Physics.Raycast(this.transform.position, forward, out hit, Mathf.Infinity, layerMask)) 
        {
            
            timeElapsed += Time.deltaTime;//시간 증가
            Gazepointer.fillAmount = timeElapsed / 2;//이미지 fill 채워줌

            if (timeElapsed >= 2 && getEvent == false)//2초가 되면
            {
                print("click");
                //버튼 효과음 재생
                SoundMng.Instance.ToggleSoundStart();

                //버튼 onClick 이벤트 발생
                hit.transform.GetComponent<Button>().onClick.Invoke();

                getEvent = true; //중복실행 방지

            }

        }
        else
        {
            timeElapsed -= Time.deltaTime;
            Gazepointer.fillAmount = timeElapsed / 2;

            getEvent = false; //중복실행 방지

            if (timeElapsed <= 0) timeElapsed = 0;
        }
    }
    
}
