using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bingo : MonoBehaviour
{

    int randNum1;
    int randNum2;
    int randNum3;
    int randNum4;
    int temp;


    void Start()
    {
        int[,] bingo = new int[5, 5]; // 5x5 �迭 ���� //[4,4]�� ������ ������ ĭ��

        // 1���� 25�� �ʱ�ȭ
        for (int i =0; i<5; i++)
        {
            for(int j = 0; j<5; j++)
            {
                bingo[i,j]= i * 5 + j + 1;
            }
        }

        //������� �Ǿ��ִ� �������� �����ش�.
        for(int i =0; i < 10; i++) // ������ ���� 10�� �ݺ�
        {
            // ������ ��ǥ�� ���Ѵ�.
            randNum1 = Random.Range(0, 5);
            randNum2 = Random.Range(0, 5);
            randNum3 = Random.Range(0, 5);
            randNum4 = Random.Range(0, 5);

            //���� �ٲ�ġ�� �Ѵ�
            temp = bingo[randNum1, randNum2]; //�ٲٱ� ���� ������ ���� ������ �ʵ��� �ӽ÷� �����Ѵ�.
            bingo[randNum1, randNum2] = bingo[randNum3, randNum4]; // ���� �ٲ۴�.
            bingo[randNum3, randNum4] = temp; // ������ �� �ʿ��� ���� �ٲ��ش�.

        }
        




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

}
