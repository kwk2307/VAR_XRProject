using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rowing : MonoBehaviour
{
    [SerializeField] private GameObject tracker01;
    [SerializeField] private GameObject tracker04;
    [SerializeField] private Animator anim_boat;
    [SerializeField] private Animator anim_men;
    private float distance; //Ʈ��Ŀ�� ������ �Ÿ��� ���� ����
    [SerializeField] private float speed = 1;

    private float isRowing;
    //���� �Ÿ���
    private float isRowingPre;
    //���� �Ÿ���
    private float Rowrate = -0.1f;
    //Rowrate = �ִϸ��̼��� ���� ���� ��ġ rowrate�� ���� ������� ������� �̴� ��������� �����Ѵ�.

    private int a = 1;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
        float tmp = Vector3.Distance(tracker01.transform.position, tracker04.transform.position);  //�� �������� Ʈ���Ű��� ��ġ

        if (tmp <= 1)
        {
            //Ʈ���� ���� �Ÿ��� 1�����϶�
            //����Ÿ����� �־��ְ� ��Ʈ�� �ִϸ��̼��� �����Ѵ�.
            isRowing = tmp;
            anim_boat.SetFloat("Position", isRowing);
            anim_men.SetFloat("Position", isRowing);
        }

        if (isRowing - isRowingPre > 0.7)
        {
            return; // ��ġ���� Ƣ�� �Ϳ� ���� ����ó��
        }

        if (Rowrate - (isRowing - isRowingPre) < 0.1 &&
            Rowrate - (isRowing - isRowingPre) > -0.1)
        {
            //Rowrate�� �������ش�.-> �ִϸ��̼��� ����
            Rowrate -= (isRowing - isRowingPre);
            
        }

        anim_boat.SetFloat("isRow", Rowrate);
        anim_men.SetFloat("isRow", Rowrate);

        //���ױ⸦ ������ Ȯ��
        
        if ((isRowing - isRowingPre) > 0 && this.GetComponent<Rigidbody>().velocity.magnitude <300)
        {
            // ���� �Ÿ������� ���� �Ÿ����� �� ũ�� == �����ӽ��� �����ִ�.
            // 
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1) * (isRowing - isRowingPre) * speed);
        }

        isRowingPre = isRowing; // ���� ������(���� ������ ���忡��)
    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.GetComponent<Rigidbody>().velocity.z < 0)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) *100 * Time.deltaTime);
        }
        else
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        //isRowing = tracker01.transform.position.x  - tracker04.transform.position.x;
        //print("isRowing : " + isRowing);

    }
   
    
    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 300, 150), "��ư"))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1) * 300);
        }
        if (GUI.Button(new Rect(300, 0, 300, 150), "�ٽ��ϱ�"))
        {
            // �ٽ��ϱ�(�����)
            GameMng gm = GameObject.Find("Click").GetComponent<GameMng>();


            gm.SceneChange();
        }
    }
    
}
