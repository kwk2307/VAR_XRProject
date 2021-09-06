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

    // Update is called once per frame
    void Update()
    {
        currentPosition = this.transform; // 해당 프레임에서의 위치
        


        if (prePosition == null) //첫 프레임에서는 이전 포지션이 없으니 예외처리 해준다.
        {
            
            prePosition = this.transform;
        }
        print(currentPosition.position.z);
        print(prePosition.position.z);

        //속도 구하기
        speed = (currentPosition.transform.position - prePosition.transform.position).magnitude / Time.deltaTime;
        
        speedText.text = speed.ToString(); //UI에 속도 표시

        delay += Time.deltaTime;

        
            prePosition = currentPosition;  // 다음프레임의 입장에서는 비교할 프레임이다.

        
        
    }
}
