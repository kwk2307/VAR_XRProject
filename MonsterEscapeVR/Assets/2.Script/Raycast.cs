using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Raycast : MonoBehaviour
{
    public Image Gazepointer;

    private float timeElapsed = 0;

    public GameObject Toggle;
    AudioSource ToggleSound;

    //���̵����� ���� ������
    private float fadeTime = 2f;
    public Image fadeImg;
    private float alpha=0;
    private bool fadeBool = false;
    private bool enterFade = false;

    bool getEvent = false; //ȭ�� �ε尡 ������ �Ǵ� ���� ��������
    void Start()
    {
        ToggleSound = Toggle.GetComponent<AudioSource>();
        ToggleSound.Stop();


    }


    void Update()
    {
        if(enterFade == true)
        {
            if (fadeBool == false)
            {
                StartCoroutine(StartFade());
            }

        }


        RaycastHit hit;//������Ʈ ����

        Vector3 forward = transform.TransformDirection(Vector3.forward * 1000);//����
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(this.transform.position, forward, out hit))
        {
            if(hit.transform.tag == "UI") //�ε��� ����� UI���
            {
                timeElapsed += Time.deltaTime;//�ð� ����
                Gazepointer.fillAmount = timeElapsed / 2;//�̹��� fill ä����

                if (timeElapsed >= 2 && getEvent == false)//2�ʰ� �Ǹ�
                {
                    //��ư ȿ���� ���
                    ToggleSound.Play();

                    enterFade = true; //���̵� �ƿ� ȿ�� �߻�

                    //��ư onClick �̺�Ʈ �߻�
                    hit.transform.GetComponent<Button>().onClick.Invoke();


                    DontDestroyOnLoad(Toggle); //�� ��ȯ�ص� �Ҹ��� ��� ������.
                                               //timeElapsed = 0;
                    getEvent = true; //�ߺ����� ����

                }
            }

            
        }
        else
        {
            timeElapsed -= Time.deltaTime;
            Gazepointer.fillAmount = timeElapsed / 2;

            if (timeElapsed <= 0) timeElapsed = 0;
        }
    }
    
    IEnumerator StartFade()
    {
        fadeBool = true;
        alpha += 1.6f*Time.deltaTime;
        fadeImg.color = new Color(0, 0, 0, alpha);
        yield return new WaitForSeconds(0.008f);
        fadeBool = false;
    }
}
