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



    private float isRowing;
    //���� �Ÿ���
    private float isRowingPre;
    //���� �Ÿ���
    private float rowRate = -0.1f;
    //Rowrate = �ִϸ��̼��� ���� ���� ��ġ rowrate�� ���� ������� ������� �̴� ��������� �����Ѵ�.

    //pouringSound
    public AudioSource pour;

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

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetComponent<Rigidbody>().velocity.z < 0)
        {
            transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) * 50 * GameMng.Instance.currentspeed * Time.deltaTime);
        }
        else
        {
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (GameMng.Instance.playerState == state.playing)
        {
            //���ױ⸦ ������ Ȯ��

            if ((isRowing - isRowingPre) > 0 && transform.GetComponent<Rigidbody>().velocity.magnitude < 15)
            {
                // ���� �Ÿ������� ���� �Ÿ����� �� ũ�� == �����ӽ��� �����ִ�.
                transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1) * (isRowing - isRowingPre) * speed);
                // ���� ���� �� pouringSound�� ���
                if(0.2f< isRowing && isRowing < 0.3f)
                {
                    pour.Play();
                    
                }
                

            }
            isRowingPre = isRowing; // ���� ������(���� ������ ���忡��)
        }
        else
        {
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        
    }
}
