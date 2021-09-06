using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rowing : MonoBehaviour
{
    public GameObject tracker01;
    public GameObject tracker04;
    float distance; //Ʈ��Ŀ�� ������ �Ÿ��� ���� ����
    public float speed = 1;

    float isRowing;
    float isRowingPre;

    int a = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        isRowing = Vector3.Distance(tracker01.transform.position, tracker04.transform.position);  //�� ������
        //print("isRowing : " + isRowing);

        if (isRowing - isRowingPre > 1)
        {
            return; // ��ġ���� Ƣ�� �Ϳ� ���� ����ó��
        }



        //���ױ⸦ ������ Ȯ��
        //print("Ʈ��Ŀ�� ��ȭ ����" + (isRowing - isRowingPre));
        this.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * distance);

        if ((isRowing - isRowingPre) > 0.03)
        {
            {
                //print(isRowing - isRowingPre);
                //transform.position += new Vector3(1, 0, 0) * distance; // ��� �Ϳ� ����� z������ �̵�  
            }
        }
        
        distance = Vector3.Distance(tracker01.transform.position, tracker04.transform.position);
        
        isRowingPre = Vector3.Distance(tracker01.transform.position, tracker04.transform.position); // ���� ������(���� ������ ���忡��)
        //print("isRowingPre : " + isRowingPre);

    }
}
