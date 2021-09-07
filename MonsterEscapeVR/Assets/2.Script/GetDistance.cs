using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDistance : MonoBehaviour
{
    public GameObject ship;  // ��
    public GameObject endPoint; // ������
    public Text distanceText;
    float distance;

    public float angryDistance; //�г���� �� �Ÿ�
    private GameObject enemy;

    void Start()
    {
        enemy = GameObject.Find("Shark_Charactor");
        
    }

    // Update is called once per frame
    void Update()
    {
        //�������� ���� �� ������ �Ÿ��� ���Ѵ�.
        distance = Vector3.Distance(endPoint.transform.position, ship.transform.position);
        distance = (int)(distance); //�Ҽ��� ���� ����

        
        //���ѰŸ��� UI�� ǥ���Ѵ�
        distanceText.text =  distance + "M / 50M";




        angryDistance = Vector3.Distance(ship.transform.position, enemy.transform.position);
        if(distance <= angryDistance) // �� ���� ������ ������ �г���� ��ȯ�� ���ΰ�?
        {
            print("�г��� ����!");
        }
        
    }
}
