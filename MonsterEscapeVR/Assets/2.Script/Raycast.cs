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
                if (timeElapsed >= 0.1f)//0.5초가 되면
                {
                    if(shotEf != null) Instantiate(shotEf, hit.transform.position,Quaternion.identity); //이펙트 만들고
                    hit.transform.tag = "UI";

                    //코루틴 발생
                    StartCoroutine(hit.transform.GetComponent<MinionMove>().DeadMinion());
                    
                    shotSound.Play(); //총소리도 실행

                    timeElapsed = 0;
                }
                
            }

        }
        else
        {

            timeElapsed -= Time.deltaTime;
            if(timeElapsed < 0)
            {
                timeElapsed = 0;
            }
        }
    }
    
}
