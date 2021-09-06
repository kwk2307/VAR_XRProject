using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rowing : MonoBehaviour
{
    public GameObject tracker01;
    public GameObject tracker04;
    float distance; //Ʈ��Ŀ�� ������ �Ÿ��� ���� ����
    public float speed;

    GameObject curPos;
    GameObject prePos;
    float isRowing;
    float isRowingPre;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curPos = this.gameObject;

        if (prePos == null) return;  // ù ������ ����ó��

        
        isRowing = Vector3.Distance(curPos.transform.position, prePos.transform.position);  //�� ������
        print("isRowing :" + isRowing);

        //���ױ⸦ ������ Ȯ��
        if((isRowing - isRowingPre) > 0)
        {
            {
                transform.position += new Vector3(1, 0, 0) * distance; // ��� �Ϳ� ����� z������ �̵�

            }
        }



        distance = Vector3.Distance(tracker01.transform.position, tracker04.transform.position);
        print(distance);
        


        prePos = this.gameObject;
        isRowingPre = Vector3.Distance(curPos.transform.position, prePos.transform.position); // ���� ������(���� ������ ���忡��)
        print("isRowingPre : " + isRowingPre);

    }
}
