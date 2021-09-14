using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDistance : MonoBehaviour
{
    public GameObject ship;  // 배
    public GameObject endPoint; // 목적지
    public Text distanceText;
    public float distance;

    private GameObject enemy;

    // 프로그래스바 부분
    public Slider progress;
    public float moveDistance;

    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        //목적지와 현재 배 사이의 거리를 구한다.
        distance = Vector3.Distance(endPoint.transform.position, ship.transform.position);
        distance = (int)(distance); //소수점 이하 버림

        
        //구한거리를 UI에 표시한다
        distanceText.text =  distance + "M / 50M";

        // 프로그래스바 부분
        moveDistance = 50 - distance;
        progress.value = moveDistance / 50;
        
    }
}
