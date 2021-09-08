using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    public Image Gazepointer;

    private float timeElapsed;

    void Start()
    {

    }


    void Update()
    {
        RaycastHit hit;//오브젝트 정보

        Vector3 forward = transform.TransformDirection(Vector3.forward * 1000);//방향

        if (Physics.Raycast(this.transform.position, forward, out hit))
        {
            print("이프문에 들어옴");
            timeElapsed += Time.deltaTime;//시간 증가
            Gazepointer.fillAmount = timeElapsed / 3;//이미지 fill 채워줌

            if (timeElapsed >= 3)//3초가 되면
            {
                //버튼 onClick 이벤트 발생
                hit.transform.GetComponent<Button>().onClick.Invoke();
            }
        }
        else
        {
            timeElapsed -= Time.deltaTime;
            Gazepointer.fillAmount = timeElapsed / 3;

            if (timeElapsed <= 0) timeElapsed = 0;
        }
        Debug.DrawRay(transform.position, forward, Color.gray);
    }
}
