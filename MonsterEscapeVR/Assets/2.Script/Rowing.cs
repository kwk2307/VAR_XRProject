using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rowing : MonoBehaviour
{
    [SerializeField] private GameObject tracker01;
    [SerializeField] private GameObject tracker02;
    [SerializeField] private Animator anim_boat;
    [SerializeField] private Animator anim_men;
    private float distance; //트래커들 사이의 거리를 담을 변수
    [SerializeField] private float speed = 1;



    private float isRowing;
    //현재 거리값
    private float isRowingPre;
    //이전 거리값
    private float rowRate = -0.1f;
    //Rowrate = 애니메이션을 위해 만든 수치 rowrate에 따라 당겨지는 모션인지 미는 모션인지를 결정한다.

    //pouringSound
    public AudioSource pour;

    private void FixedUpdate()
    {
        


        distance = Vector3.Distance(tracker01.transform.position, tracker02.transform.position);  //현 프레임의 트래거간의 위치

        if (distance <= 1)
        {
            //트래거 간의 거리가 1이하일때
            //현재거리값에 넣어주고 보트의 애니메이션을 수정한다.
            isRowing = distance;
            anim_boat.SetFloat("Position", isRowing);
            anim_men.SetFloat("Position", isRowing);
        }

        if (isRowing - isRowingPre > 0.7)
        {
            return; // 위치값이 튀는 것에 대한 예외처리
        }

        if (rowRate - (isRowing - isRowingPre) < 0.1 && rowRate - (isRowing - isRowingPre) > -0.1)

        {
            //Rowrate를 조절해준다.-> 애니메이션을 위함
            rowRate -= (isRowing - isRowingPre);
        }

        anim_boat.SetFloat("isRow", rowRate);
        anim_men.SetFloat("isRow", rowRate);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetComponent<Rigidbody>().velocity.z < 0)
        {
            transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) * 50 * GameMng.Instance.currentspeed * Time.deltaTime);
        }
        else
        {
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (GameMng.Instance.playerState == state.playing)
        {
            //로잉기를 당기는지 확인

            if ((isRowing - isRowingPre) > 0 && transform.GetComponent<Rigidbody>().velocity.magnitude < 15)
            {
                // 이전 거리값보다 현재 거리값이 더 크다 == 로윙머신을 당기고있다.
                transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1) * (isRowing - isRowingPre) * speed);
                // 당기고 있을 때 pouringSound도 재생
                if(0.2f< isRowing && isRowing < 0.3f)
                {
                    pour.Play();
                    
                }
                

            }
            isRowingPre = isRowing; // 과거 프레임(다음 프레임 입장에서)
        }
        else
        {
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        
    }
}
