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
        //�����Ҷ� ������ ��ġ�� enemyAngryPos�� �־��ش�.
        //�� �ΰ� ����..?
        //���� �Լ��� �����ؾ���

    }

    // Update is called once per frame
    void Update()
    {
        if(velocity < warning_velocity)
        {
            //�ӵ��� ������
            //�ӵ� ��� UI�� ǥ���Ѵ�.
        }

        if (current_pos > warning_distancetoGoal[distancetoGoalCnt])
        {
            //Ư�� ������ �������� ��
            distancetoGoalCnt++;
            //���� �Ÿ� �˸��� UI�� ǥ���Ѵ�.
        }

        if (current_pos - enemy_pos < warning_distancetoEnemy)
        {
            //������ �Ÿ��� �� �ȳ����� ��
            //��� UI�� ǥ���Ѵ�.
        }
        
        if(enemy_pos < enemyAngryPos[enemyAngryPosCnt])
        {
            //���� Ư����ġ�� �����ϸ�
            //���� �ӵ��� �����ϰ� �ִϸ��̼��� �ٲٰ� ���
            enemyAngryPosCnt++;
        }

        if (current_pos >= enemy_pos)
        {

            //���� �÷��̾ ����� ��
            //���� ����
        }

        if (current_pos <= goal)
        {

            //�÷��̾ �� ����������
            //���� ����
        }

    }
}
