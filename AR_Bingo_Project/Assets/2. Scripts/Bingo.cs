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
        int[,] bingo = new int[5, 5]; // 5x5 배열 생성 //[4,4]가 빙고의 마지막 칸임

        // 1부터 25로 초기화
        for (int i =0; i<5; i++)
        {
            for(int j = 0; j<5; j++)
            {
                bingo[i,j]= i * 5 + j + 1;
            }
        }

        //순서대로 되어있는 빙고판을 섞어준다.
        for(int i =0; i < 10; i++) // 빙고판 섞기 10번 반복
        {
            // 랜덤한 좌표를 구한다.
            randNum1 = Random.Range(0, 5);
            randNum2 = Random.Range(0, 5);
            randNum3 = Random.Range(0, 5);
            randNum4 = Random.Range(0, 5);

            //서로 바꿔치기 한다
            temp = bingo[randNum1, randNum2]; //바꾸기 전에 기존의 값이 날라가지 않도록 임시로 저장한다.
            bingo[randNum1, randNum2] = bingo[randNum3, randNum4]; // 값을 바꾼다.
            bingo[randNum3, randNum4] = temp; // 나머지 한 쪽에도 값을 바꿔준다.

        }
        




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

}
