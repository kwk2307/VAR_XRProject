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
        
        isRowing = Vector3.Distance(tracker01.transform.position, tracker04.transform.position);  //현 프레임
        //print("isRowing : " + isRowing);

        if (isRowing - isRowingPre > 1)
        {
            return; // 위치값이 튀는 것에 대한 예외처리
        }



        //로잉기를 당기는지 확인
        //print("트래커의 변화 정도" + (isRowing - isRowingPre));
        this.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * distance);

        if ((isRowing - isRowingPre) > 0.03)
        {
            {
                //print(isRowing - isRowingPre);
                //transform.position += new Vector3(1, 0, 0) * distance; // 당긴 것에 비례해 z축으로 이동  
            }
        }
        
        distance = Vector3.Distance(tracker01.transform.position, tracker04.transform.position);
        
        isRowingPre = Vector3.Distance(tracker01.transform.position, tracker04.transform.position); // 과거 프레임(다음 프레임 입장에서)
        //print("isRowingPre : " + isRowingPre);

    }
}
