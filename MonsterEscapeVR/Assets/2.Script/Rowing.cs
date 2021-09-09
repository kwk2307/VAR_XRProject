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
    private float isRowingPre = 0;

    private int a = 1;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
        float tmp = Vector3.Distance(tracker01.transform.position, tracker04.transform.position);  //현 프레임

        if (tmp <= 1)
        {
            isRowing = tmp;
            anim_boat.SetFloat("Position", isRowing);
            anim_men.SetFloat("Position", isRowing);
        }

        print(Math.Round(isRowing - isRowingPre,2));
        anim_boat.SetFloat("isRow", (float)Math.Round(isRowing - isRowingPre, 2));
        anim_men.SetFloat("isRow", (float)Math.Round(isRowing - isRowingPre, 2));
        if (isRowingPre == 0)
        {
            //isRowingPre 일때를 처리해 준다.
            isRowingPre = isRowing;
            return;
        }

        
        if (isRowing - isRowingPre > 0.7)
        {
            return; // 위치값이 튀는 것에 대한 예외처리
        }

        //로잉기를 당기는지 확인
        
        if ((isRowing - isRowingPre) > 0)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1) * (isRowing - isRowingPre) * speed);
        }

        isRowingPre = isRowing; // 과거 프레임(다음 프레임 입장에서)
        //print("isRowingPre : " + isRowingPre);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.GetComponent<Rigidbody>().velocity.z < 0)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        }
        else
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        //isRowing = tracker01.transform.position.x  - tracker04.transform.position.x;
        
        
        //print("isRowing : " + isRowing);

    }

    //private void OnGUI()
    //{
    //    if (GUI.Button(new Rect(0, 0, 300, 150), "버튼"))
    //    {
    //        this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1) * 300);
    //    }
    //}
}
