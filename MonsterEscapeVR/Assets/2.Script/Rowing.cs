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
        if(this.GetComponent<Rigidbody>().velocity.x > 0)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0));
        }
        else
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        isRowing = Vector3.Distance(tracker01.transform.position, tracker04.transform.position);  //�� ������
        //print("isRowing : " + isRowing);

        if (isRowing - isRowingPre > 1)
        {
            return; // ��ġ���� Ƣ�� �Ϳ� ���� ����ó��
        }
        
        //���ױ⸦ ������ Ȯ��
        //print("Ʈ��Ŀ�� ��ȭ ����" + (isRowing - isRowingPre));
       
        if ((isRowing - isRowingPre) > 0)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * isRowing * speed);
        }
  
        isRowingPre = Vector3.Distance(tracker01.transform.position, tracker04.transform.position); // ���� ������(���� ������ ���忡��)
        //print("isRowingPre : " + isRowingPre);
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 60, 30), "��ư"))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * 300);
        }
    }
}
