using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rowing : MonoBehaviour
{
    [SerializeField] private GameObject tracker01;
    [SerializeField] private GameObject tracker04;
    private float distance; //Ʈ��Ŀ�� ������ �Ÿ��� ���� ����
    [SerializeField] private float speed = 1;

    private float isRowing;
    private float isRowingPre = 0;

    private int a = 1;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        //isRowing = tracker01.transform.position.x  - tracker04.transform.position.x;
        isRowing = Vector3.Distance(tracker01.transform.position, tracker04.transform.position);  //�� ������
        //print("isRowing : " + isRowing);

        if(isRowingPre == 0)
        {
            //isRowingPre �϶��� ó���� �ش�.
            isRowingPre = isRowing;
            return;
        }

        if (isRowing - isRowingPre > 0.7)
        {
            return; // ��ġ���� Ƣ�� �Ϳ� ���� ����ó��
        }

        //���ױ⸦ ������ Ȯ��
        print("Ʈ��Ŀ�� ��ȭ ����" + (isRowing - isRowingPre));
        if ((isRowing - isRowingPre) > 0)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * (isRowing - isRowingPre) * speed);
        }

        isRowingPre = isRowing; // ���� ������(���� ������ ���忡��)
        //print("isRowingPre : " + isRowingPre);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<Rigidbody>().velocity.x > 0)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0) * 300 * Time.deltaTime);
        }
        else
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 300, 150), "��ư"))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * 300);
        }
    }
}
