using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSpeed : MonoBehaviour
{//이 스크립트가 붙은 게임오브젝트의 속도를 구함

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
            currentPosition = this.transform; // 해당 프레임에서의 위치

            print(currentPosition);

            if (prePosition == null) //첫 프레임에서는 이전 포지션이 없으니 예외처리 해준다.
            {
                print("111111111111");
                prePosition = currentPosition;
                return;
            }
            print("cur " + currentPosition.position);
            print("pre " + prePosition.position);

            //속도 구하기
            speed = (currentPosition.position - prePosition.position).magnitude;
            print(speed);
            speedText.text = speed.ToString(); //UI에 속도 표시

            delay = 0;

            prePosition = currentPosition;  // 다음프레임의 입장에서는 비교할 프레임이다.
            */
        }

    }
}
