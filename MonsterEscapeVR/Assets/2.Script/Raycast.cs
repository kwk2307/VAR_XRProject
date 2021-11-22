using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Raycast : MonoBehaviour
{
    public Image Gazepointer;

    private float timeElapsed = 0;
    public AudioSource shotSound;

    //페이드인을 위한 변수들

    private bool enterFade = false;
    public GameObject shotEf;
    

    void Update()
    {
       
        RaycastHit hit;//오브젝트 정보

        Vector3 forward = transform.TransformDirection(Vector3.forward);//방향
        //UI레이어만 걸림
        LayerMask layerMask = 1 << LayerMask.NameToLayer("UI");

        if (Physics.Raycast(this.transform.position, forward, out hit, Mathf.Infinity, layerMask)) 
        {
            if(hit.transform.tag != "MiniEnemy")
            {
                timeElapsed += Time.deltaTime;//시간 증가
                Gazepointer.fillAmount = timeElapsed / 2;//이미지 fill 채워줌

                if (timeElapsed >= 2)//2초가 되면
                {

                    //버튼 효과음 재생
                    SoundMng.Instance.ToggleSoundStart();
                    print(hit.transform.name);
                    if (hit.transform.GetComponent<Button>() != null)
                    {
                        //버튼 onClick 이벤트 발생
                        hit.transform.GetComponent<Button>().onClick.Invoke();

                    }
                    else if (hit.transform.GetComponent<Toggle>() != null)
                    {
                        hit.transform.GetComponent<Toggle>().isOn = true;
                    }

                    timeElapsed = 0;
                }
            
            }
            else if(hit.transform.tag == "MiniEnemy") //게이즈 포인터로 미니 적을 봤다면
            {
                Gazepointer.fillAmount = 0; //게이지 차는 경우 있어서
                timeElapsed += Time.deltaTime;//시간 증가
                if (timeElapsed >= 0.5f)//0.5초가 되면
                {
                    Instantiate(shotEf);
                    shotEf.transform.position = hit.transform.position; //그 자리에 이펙트 생성
                    Destroy(hit.transform.gameObject);// 바라본 미니 적 삭제
                    shotSound.Play(); //총소리도 실행
                    timeElapsed = 0f;
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
    
}
