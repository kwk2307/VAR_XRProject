using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSpeed : MonoBehaviour
{//�� ��ũ��Ʈ�� ���� ���ӿ�����Ʈ�� �ӵ��� ����

    Transform currentPosition;
    Transform prePosition;
    public Text speedText;
    float delay = 0;

    int a = 1;

    float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = this.transform; // �ش� �����ӿ����� ��ġ
        


        if (prePosition == null) //ù �����ӿ����� ���� �������� ������ ����ó�� ���ش�.
        {
            
            prePosition = this.transform;
        }
        print(currentPosition.position.z);
        print(prePosition.position.z);

        //�ӵ� ���ϱ�
        speed = (currentPosition.transform.position - prePosition.transform.position).magnitude / Time.deltaTime;
        
        speedText.text = speed.ToString(); //UI�� �ӵ� ǥ��

        delay += Time.deltaTime;

        
            prePosition = currentPosition;  // ������������ ���忡���� ���� �������̴�.

        
        
    }
}
