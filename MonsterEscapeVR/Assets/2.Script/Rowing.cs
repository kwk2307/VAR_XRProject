using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rowing : MonoBehaviour
{
    public GameObject tracker01;
    public GameObject tracker04;
    float distance; //트래커들 사이의 거리를 담을 변수
    public float speed;

    GameObject curPos;
    GameObject prePos;
    float isRowing;
    float isRowingPre;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curPos = this.gameObject;

        if (prePos == null) return;  // 첫 프레임 예외처리

        
        isRowing = Vector3.Distance(curPos.transform.position, prePos.transform.position);  //현 프레임
        print("isRowing :" + isRowing);

        //로잉기를 당기는지 확인
        if((isRowing - isRowingPre) > 0)
        {
            {
                transform.position += new Vector3(1, 0, 0) * distance; // 당긴 것에 비례해 z축으로 이동

            }
        }



        distance = Vector3.Distance(tracker01.transform.position, tracker04.transform.position);
        print(distance);
        


        prePos = this.gameObject;
        isRowingPre = Vector3.Distance(curPos.transform.position, prePos.transform.position); // 과거 프레임(다음 프레임 입장에서)
        print("isRowingPre : " + isRowingPre);

    }
}
