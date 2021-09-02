using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bingo : MonoBehaviour
{

    int randNum1;
    int randNum2;
    int randNum3;
    int randNum4;
    int temp;
    [SerializeField] GameObject[] dd;

    void Start()
    {
        int[,] bingo = new int[4, 4]; // 4x4 배열 생성

        // 1부터 16로 초기화
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                bingo[i, j] = i * 4 + j + 1;
            }
        }

        //순서대로 되어있는 빙고판을 섞어준다.
        for (int i = 0; i < 10; i++) // 빙고판 섞기 10번 반복
        {
            // 랜덤한 좌표를 구한다.
            randNum1 = Random.Range(0, 4);
            randNum2 = Random.Range(0, 4);
            randNum3 = Random.Range(0, 4);
            randNum4 = Random.Range(0, 4);

            //서로 바꿔치기 한다
            temp = bingo[randNum1, randNum2]; //바꾸기 전에 기존의 값이 날라가지 않도록 임시로 저장한다.
            bingo[randNum1, randNum2] = bingo[randNum3, randNum4]; // 값을 바꾼다.
            bingo[randNum3, randNum4] = temp; // 나머지 한 쪽에도 값을 바꿔준다.

        }

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4 ; j++)
            {
                dd[(i * 4)+j].GetComponent<Text>().text = bingo[i, j].ToString();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

}
