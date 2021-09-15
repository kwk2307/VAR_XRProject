using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    public Image Gazepointer;

    private float timeElapsed;

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

        if (Physics.Raycast(this.transform.position, forward, out hit))
        {
            timeElapsed += Time.deltaTime;//�ð� ����
            Gazepointer.fillAmount = timeElapsed / 3;//�̹��� fill ä����

            if (timeElapsed >= 3)//3�ʰ� �Ǹ�
            {
                //��ư ȿ���� ���
                ToggleSound.Play();

                //��ư onClick �̺�Ʈ �߻�
                hit.transform.GetComponent<Button>().onClick.Invoke();

                DontDestroyOnLoad(Toggle); //�� ��ȯ�ص� �Ҹ��� ��� ������.
            }
        }
        else
        {
            timeElapsed -= Time.deltaTime;
            Gazepointer.fillAmount = timeElapsed / 3;

            if (timeElapsed <= 0) timeElapsed = 0;
        }
    }
}
