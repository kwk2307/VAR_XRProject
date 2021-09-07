using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 5f;
    public float attackPower = 1f;
    public float delayCount;

    float distance;
    public float angryDistance; //분노모드로 들어갈 거리

     Animator anim;

    private GameObject player; //플레이어를 담을 변수

    GetDistance getDistance;
    public GameObject distanceUI;

    float delay;
    bool getAngry = false;


    void Start()
    {
        //플레이어를 찾아서 담는다
        player = GameObject.Find("Player");

        //거리 표시UI의 스크립트를 가져온다.
        getDistance = GameObject.Find("Distance").GetComponent<GetDistance>();


        //거리 표시 UI에서 설정한 분노 모드 거리를 가져온다.
        

        anim = transform.GetComponent<Animator>();

        print(distanceUI.GetComponent<GetDistance>().distance);

    }

    // Update is called once per frame
    void Update()
    {
        //거리표시 UI에서 측정한 거리를 가져온다.
        distance = getDistance.distance;
        

        delayCount += Time.deltaTime;
        if (delayCount >= 3)
        {

            //플레이어를 쫓아간다.
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);

        }
        
        if (distance <= angryDistance && !getAngry) // 몇 미터 안으로 들어오면 분노모드로 전환할 것인가?
        {
            
            getAngry = true;
            StartCoroutine( SetAni() );
            
            
            
        }

    }

    IEnumerator SetAni()
    {
        anim.SetBool("Angry", true); //분노 애니매이션 재생.
        yield return new WaitForSeconds(0.77f);
        anim.SetBool("Angry", false);

    }

    
    


}
