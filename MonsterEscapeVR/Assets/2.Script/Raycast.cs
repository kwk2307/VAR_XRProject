using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Raycast : MonoBehaviour
{

    private float timeElapsed = 0;
    public AudioSource shotSound;

    public GameObject shotEf;
    
    void Update()
    {
        RaycastHit hit;//오브젝트 정보

        Vector3 forward = transform.TransformDirection(Vector3.forward);//방향
        //UI레이어만 걸림
        LayerMask layerMask = 1 << LayerMask.NameToLayer("UI");

        if (Physics.Raycast(this.transform.position, forward, out hit, Mathf.Infinity, layerMask)) 
        {
            if(hit.transform.tag == "MiniEnemy") //게이즈 포인터로 미니 적을 봤다면
            {
              
                timeElapsed += Time.deltaTime;//시간 증가
                if (timeElapsed >= 0.5f)//0.5초가 되면
                {
                    Instantiate(shotEf, hit.transform.position,Quaternion.identity);
                    hit.transform.GetComponent<Animator>().SetBool("Hit", true); //죽는 애니메이션 재생
                    if(hit.transform.Find("spear") != null) //작살이 있다면
                    {
                        hit.transform.Find("spear").gameObject.SetActive(true);
                    }
                    
                    hit.transform.GetComponent<MinionMove>().gameObject.SetActive(false); //적의 움직임 정지
                    
                    shotSound.Play(); //총소리도 실행
                    if(timeElapsed >= 0.8) //0.3초 뒤에 제거
                    {
                        Destroy(hit.transform.gameObject);// 바라본 미니 적 삭제
                        timeElapsed = 0f;
                    }
                    
                }
            }

        }
        else
        {
            timeElapsed -= Time.deltaTime;
            
            if (timeElapsed <= 0) timeElapsed = 0;
        }
    }
    
}
