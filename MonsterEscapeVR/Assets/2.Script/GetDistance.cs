using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDistance : MonoBehaviour
{
    public GameObject ship;  // 배
    public GameObject endPoint; // 목적지
    public Text distanceText;
    float distance;

    public float angryDistance; //분노모드로 들어갈 거리
    private GameObject enemy;

    void Start()
    {
        enemy = GameObject.Find("Shark_Charactor");
        
    }

    // Update is called once per frame
    void Update()
    {
        //목적지와 현재 배 사이의 거리를 구한다.
        distance = Vector3.Distance(endPoint.transform.position, ship.transform.position);
        distance = (int)(distance); //소수점 이하 버림

        
        //구한거리를 UI에 표시한다
        distanceText.text =  distance + "M / 50M";




        angryDistance = Vector3.Distance(ship.transform.position, enemy.transform.position);
        if(distance <= angryDistance) // 몇 미터 안으로 들어오면 분노모드로 전환할 것인가?
        {
            print("분노모드 돌입!");
        }
        
    }
}
