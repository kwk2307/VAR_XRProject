using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpeed : MonoBehaviour
{//�� ��ũ��Ʈ�� ���� ���ӿ�����Ʈ�� �ӵ��� ����

    Transform currentPosition;
    Transform prePosition;

    float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = this.transform; // �ش� �����ӿ����� ��ġ

        if(prePosition == null) //ù �����ӿ����� ���� �������� ������ ����ó�� ���ش�.
        {
            return;
        }
        //�ӵ� ���ϱ�
        speed = (currentPosition.position.x - prePosition.position.x) / Time.deltaTime;
        print(speed); //�ֿܼ� �ӵ� ǥ��




        prePosition = this.transform;  // ������������ ���忡���� ���� �������̴�.
        
    }
}
