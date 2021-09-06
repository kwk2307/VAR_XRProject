using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoBehaviour
{

    private int velocity;
    private int current_pos;
    private int enemy_pos;
    private int goal;

    [SerializeField] private int warning_velocity;
    [SerializeField] private int[] warning_distancetoGoal;
    private int distancetoGoalCnt = 0;
    [SerializeField] private int warning_distancetoEnemy;
    [SerializeField] private int[] enemyAngryPos;
    private int enemyAngryPosCnt = 0;

    private void Start()
    {
        //시작할때 랜덤한 위치에 enemyAngryPos를 넣어준다.
        //한 두곳 정도..?
        //랜덤 함수를 구현해야함

    }

    // Update is called once per frame
    void Update()
    {
        if(velocity < warning_velocity)
        {
            //속도가 느릴때
            //속도 경고 UI를 표시한다.
        }

        if (current_pos > warning_distancetoGoal[distancetoGoalCnt])
        {
            //특정 지점에 도착했을 때
            distancetoGoalCnt++;
            //남은 거리 알리미 UI를 표시한다.
        }

        if (current_pos - enemy_pos < warning_distancetoEnemy)
        {
            //적과의 거리가 얼마 안남았을 때
            //경고 UI를 표시한다.
        }
        
        if(enemy_pos < enemyAngryPos[enemyAngryPosCnt])
        {
            //적이 특정위치에 도달하면
            //적의 속도를 빨리하고 애니메이션을 바꾸고 등등
            enemyAngryPosCnt++;
        }

        if (current_pos >= enemy_pos)
        {

            //적이 플레이어를 잡았을 때
            //게임 실패
        }

        if (current_pos <= goal)
        {

            //플레이어가 골에 도달했을때
            //게임 성공
        }

    }
}
