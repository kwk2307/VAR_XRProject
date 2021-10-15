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
        RaycastHit hit;//������Ʈ ����

        Vector3 forward = transform.TransformDirection(Vector3.forward * 1000);//����
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(this.transform.position, forward, out hit))
        {

            timeElapsed += Time.deltaTime;//�ð� ����
            Gazepointer.fillAmount = timeElapsed / 2;//�̹��� fill ä����

            if (timeElapsed >= 2)//2�ʰ� �Ǹ�
            {
                //��ư ȿ���� ���
                ToggleSound.Play();
                
                //��ư onClick �̺�Ʈ �߻�
                hit.transform.GetComponent<Button>().onClick.Invoke();
                print("Ŭ���̺�Ʈ�߻�");

                DontDestroyOnLoad(Toggle); //�� ��ȯ�ص� �Ҹ��� ��� ������.
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
