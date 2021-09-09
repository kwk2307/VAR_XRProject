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
        RaycastHit hit;//������Ʈ ����

        Vector3 forward = transform.TransformDirection(Vector3.forward * 1000);//����

        if (Physics.Raycast(this.transform.position, forward, out hit))
        {
            print("�������� ����");
            timeElapsed += Time.deltaTime;//�ð� ����
            Gazepointer.fillAmount = timeElapsed / 3;//�̹��� fill ä����

            if (timeElapsed >= 3)//3�ʰ� �Ǹ�
            {
                //��ư onClick �̺�Ʈ �߻�
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
