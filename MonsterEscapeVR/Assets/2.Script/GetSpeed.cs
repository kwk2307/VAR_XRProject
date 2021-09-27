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
    float count = 0;
   

    private Vector3 m_LastPosition;
    public float m_Speed;
    
    public Text m_MeterPerSecond, m_KilometersPerHour;


    private void Awake()
    {
        m_Speed = 0;
    }

    void FixedUpdate()
    {
        count += Time.deltaTime;
        delay += Time.deltaTime;
        if(count >= 3) //ó�� ī��Ʈ�ٿ��� �����ϱ�
        {
            
            if (delay >= 0.5f)
            {
                m_Speed = this.GetComponentInParent<Rigidbody>().velocity.magnitude;
                //m_Speed = m_Speed * 10; //���ǵ� ��ġ�� �ʹ� ���� ���ͼ�

                speedText.text = string.Format("{0:00} k/s", (int)m_Speed);


                //m_KilometersPerHour.text = string.Format("{0:00.00} km/h", m_Speed * 3.6f);


                delay = 0;

            }

        }
        
       
    }

    // Update is called once per frame
    private void Update()
    {
        //delay += Time.deltaTime;
        //if(delay >= 1)
        //{
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
        //}

        

        

    }
    
}
