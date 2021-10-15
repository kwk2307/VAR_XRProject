using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    public Image Gazepointer;

    private float timeElapsed = 0;

    public GameObject Toggle;
    AudioSource ToggleSound;

    void Start()
    {
        ToggleSound = Toggle.GetComponent<AudioSource>();
        ToggleSound.Stop();

    }


    void Update()
    {
        RaycastHit hit;//오브젝트 정보

        Vector3 forward = transform.TransformDirection(Vector3.forward * 1000);//방향
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(this.transform.position, forward, out hit))
        {

            timeElapsed += Time.deltaTime;//시간 증가
            Gazepointer.fillAmount = timeElapsed / 2;//이미지 fill 채워줌

            if (timeElapsed >= 2)//2초가 되면
            {
                //버튼 효과음 재생
                ToggleSound.Play();
                
                //버튼 onClick 이벤트 발생
                hit.transform.GetComponent<Button>().onClick.Invoke();
                print("클릭이벤트발생");

                DontDestroyOnLoad(Toggle); //씬 전환해도 소리가 계속 나도록.
                timeElapsed = 0;
            }
        }
        else
        {
            timeElapsed -= Time.deltaTime;
            Gazepointer.fillAmount = timeElapsed / 2;

            if (timeElapsed <= 0) timeElapsed = 0;
        }
    }
}
