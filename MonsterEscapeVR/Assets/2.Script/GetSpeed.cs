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

    private Vector3 m_LastPosition;
    public float m_Speed;
    public Text m_MeterPerSecond, m_KilometersPerHour;

    void FixedUpdate()
    {
        m_Speed = GetSpeed2();

        speedText.text = string.Format("{0:00.00} m/s", m_Speed);
        //m_KilometersPerHour.text = string.Format("{0:00.00} km/h", m_Speed * 3.6f);
    }

    float GetSpeed2()
    {
        float speed = (((transform.position - m_LastPosition).magnitude) / Time.deltaTime);
        m_LastPosition = transform.position;

        return speed;
    }

    // Update is called once per frame
    private void Update()
    {
        delay += Time.deltaTime;
        if(delay >= 1)
        {
            /*
            currentPosition = this.transform; // �ش� �����ӿ����� ��ġ

            print(currentPosition);

            if (prePosition == null) //ù �����ӿ����� ���� �������� ������ ����ó�� ���ش�.
            {
                print("111111111111");
                prePosition = currentPosition;
                return;
            }
            print("cur " + currentPosition.position);
            print("pre " + prePosition.position);

            //�ӵ� ���ϱ�
            speed = (currentPosition.position - prePosition.position).magnitude;
            print(speed);
            speedText.text = speed.ToString(); //UI�� �ӵ� ǥ��

            delay = 0;

            prePosition = currentPosition;  // ������������ ���忡���� ���� �������̴�.
            */
        }

    }
}
