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
        int[,] bingo = new int[4, 4]; // 4x4 �迭 ����

        // 1���� 16�� �ʱ�ȭ
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                bingo[i, j] = i * 4 + j + 1;
            }
        }

        //������� �Ǿ��ִ� �������� �����ش�.
        for (int i = 0; i < 10; i++) // ������ ���� 10�� �ݺ�
        {
            // ������ ��ǥ�� ���Ѵ�.
            randNum1 = Random.Range(0, 4);
            randNum2 = Random.Range(0, 4);
            randNum3 = Random.Range(0, 4);
            randNum4 = Random.Range(0, 4);

            //���� �ٲ�ġ�� �Ѵ�
            temp = bingo[randNum1, randNum2]; //�ٲٱ� ���� ������ ���� ������ �ʵ��� �ӽ÷� �����Ѵ�.
            bingo[randNum1, randNum2] = bingo[randNum3, randNum4]; // ���� �ٲ۴�.
            bingo[randNum3, randNum4] = temp; // ������ �� �ʿ��� ���� �ٲ��ش�.

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
