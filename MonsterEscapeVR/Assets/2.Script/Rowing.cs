using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rowing : MonoBehaviour
{
    public GameObject tracker01;
    public GameObject tracker04;
    float distance; //트래커들 사이의 거리를 담을 변수
    public float speed = 1;

    float isRowing;
    float isRowingPre;

    int a = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<Rigidbody>().velocity.x > 0)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0));
        }
        else
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        isRowing = Vector3.Distance(tracker01.transform.position, tracker04.transform.position);  //현 프레임
        //print("isRowing : " + isRowing);

        if (isRowing - isRowingPre > 1)
        {
            return; // 위치값이 튀는 것에 대한 예외처리
        }
        
        //로잉기를 당기는지 확인
        //print("트래커의 변화 정도" + (isRowing - isRowingPre));
       
        if ((isRowing - isRowingPre) > 0)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * isRowing * speed);
        }
  
        isRowingPre = Vector3.Distance(tracker01.transform.position, tracker04.transform.position); // 과거 프레임(다음 프레임 입장에서)
        //print("isRowingPre : " + isRowingPre);
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 60, 30), "버튼"))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * 300);
        }
    }
}
