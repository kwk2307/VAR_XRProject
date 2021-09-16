using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rowing : MonoBehaviour
{
    [SerializeField] private GameObject tracker01;
    [SerializeField] private GameObject tracker04;
    [SerializeField] private Animator anim_boat;
    [SerializeField] private Animator anim_men;
    private float distance; //트래커들 사이의 거리를 담을 변수
    [SerializeField] private float speed = 1;

    private float isRowing;
    //현재 거리값
    private float isRowingPre;
    //이전 거리값
    private float Rowrate = -0.1f;
    //Rowrate = 애니메이션을 위해 만든 수치 rowrate에 따라 당겨지는 모션인지 미는 모션인지를 결정한다.

    private int a = 1;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
        float tmp = Vector3.Distance(tracker01.transform.position, tracker04.transform.position);  //현 프레임의 트래거간의 위치

        if (tmp <= 1)
        {
            //트래거 간의 거리가 1이하일때
            //현재거리값에 넣어주고 보트의 애니메이션을 수정한다.
            isRowing = tmp;
            anim_boat.SetFloat("Position", isRowing);
            anim_men.SetFloat("Position", isRowing);
        }

        if (isRowing - isRowingPre > 0.7)
        {
            return; // 위치값이 튀는 것에 대한 예외처리
        }

        if (Rowrate - (isRowing - isRowingPre) < 0.1 &&
            Rowrate - (isRowing - isRowingPre) > -0.1)
        {
            //Rowrate를 조절해준다.-> 애니메이션을 위함
            Rowrate -= (isRowing - isRowingPre);
            
        }

        anim_boat.SetFloat("isRow", Rowrate);
        anim_men.SetFloat("isRow", Rowrate);

        //로잉기를 당기는지 확인
        
        if ((isRowing - isRowingPre) > 0 && this.GetComponent<Rigidbody>().velocity.magnitude <300)
        {
            // 이전 거리값보다 현재 거리값이 더 크다 == 로윙머신을 당기고있다.
            // 
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1) * (isRowing - isRowingPre) * speed);
        }

        isRowingPre = isRowing; // 과거 프레임(다음 프레임 입장에서)
    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.GetComponent<Rigidbody>().velocity.z < 0)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) *100 * Time.deltaTime);
        }
        else
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        //isRowing = tracker01.transform.position.x  - tracker04.transform.position.x;
        //print("isRowing : " + isRowing);

    }
   
    
    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 300, 150), "버튼"))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1) * 300);
        }
        if (GUI.Button(new Rect(300, 0, 300, 150), "다시하기"))
        {
            // 다시하기(실험용)
            GameMng gm = GameObject.Find("Click").GetComponent<GameMng>();


            gm.SceneChange();
        }
    }
    
}
