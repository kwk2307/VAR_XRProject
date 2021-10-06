using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rowing : MonoBehaviour
{
    [SerializeField] private GameObject tracker01;
    [SerializeField] private GameObject tracker02;
    [SerializeField] private Animator anim_boat;
    [SerializeField] private Animator anim_men;
    private float distance; //Ʈ��Ŀ�� ������ �Ÿ��� ���� ����
    [SerializeField] private float speed = 1;

    [SerializeField] private GameObject water;

    private float isRowing;
    //���� �Ÿ���
    private float isRowingPre;
    //���� �Ÿ���
    private float rowRate = -0.1f;
    //Rowrate = �ִϸ��̼��� ���� ���� ��ġ rowrate�� ���� ������� ������� �̴� ��������� �����Ѵ�.

    private void FixedUpdate()
    {
        
        distance = Vector3.Distance(tracker01.transform.position, tracker02.transform.position);  //�� �������� Ʈ���Ű��� ��ġ

        if (distance <= 1)
        {
            //Ʈ���� ���� �Ÿ��� 1�����϶�
            //����Ÿ����� �־��ְ� ��Ʈ�� �ִϸ��̼��� �����Ѵ�.
            isRowing = distance;
            anim_boat.SetFloat("Position", isRowing);
            anim_men.SetFloat("Position", isRowing);
        }

        if (isRowing - isRowingPre > 0.7)
        {
            return; // ��ġ���� Ƣ�� �Ϳ� ���� ����ó��
        }

        if (rowRate - (isRowing - isRowingPre) < 0.1 && rowRate - (isRowing - isRowingPre) > -0.1)

        {
            //Rowrate�� �������ش�.-> �ִϸ��̼��� ����
            rowRate -= (isRowing - isRowingPre);
            
        }

        anim_boat.SetFloat("isRow", rowRate);
        anim_men.SetFloat("isRow", rowRate);

        //���ױ⸦ ������ Ȯ��

        if ((isRowing - isRowingPre) > 0 && water.GetComponent<Rigidbody>().velocity.magnitude < 15)
        {
            // ���� �Ÿ������� ���� �Ÿ����� �� ũ�� == �����ӽ��� �����ִ�.
            // 
            water.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) * (isRowing - isRowingPre) * speed);
        }

        isRowingPre = isRowing; // ���� ������(���� ������ ���忡��)
    }

    // Update is called once per frame
    void Update()
    {
        
        if (water.GetComponent<Rigidbody>().velocity.z > 0)
{
            water.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1) * 100 * Time.deltaTime);
        }
        else
        {
            water.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
   
    
    //private void OnGUI()
    //{
    //    if (GUI.Button(new Rect(0, 0, 300, 150), "��ư"))
    //    {
    //        water.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) * 300);
    //    }
    //    if (GUI.Button(new Rect(300, 0, 300, 150), "�ٽ��ϱ�"))
    //    {
    //        // �ٽ��ϱ�(�����)
    //        GameMng gm = GameObject.Find("Click").GetComponent<GameMng>();


    //        gm.SceneChange();
    //    }
    //}


    
}
