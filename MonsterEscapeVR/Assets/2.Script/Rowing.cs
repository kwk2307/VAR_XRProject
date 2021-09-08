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
    private float isRowingPre = 0;

    private int a = 1;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {

        if(isRowingPre == 0)
        {
            //isRowingPre �϶��� ó���� �ش�.
            isRowingPre = isRowing;
            return;
        }

        if(isRowing - isRowingPre > 0.05)
        {
            anim_boat.SetBool("isRow", true);
        }
        else if(isRowing - isRowingPre < -0.05)
        {
            anim_boat.SetBool("isRow", false);
        }

        if (isRowing - isRowingPre > 0.7)
        {
            return; // ��ġ���� Ƣ�� �Ϳ� ���� ����ó��
        }

        //���ױ⸦ ������ Ȯ��
        //print("Ʈ��Ŀ�� ��ȭ ����" + (isRowing - isRowingPre));
        if ((isRowing - isRowingPre) > 0)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1) * (isRowing - isRowingPre) * speed);
        }

        isRowingPre = isRowing; // ���� ������(���� ������ ���忡��)
        //print("isRowingPre : " + isRowingPre);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<Rigidbody>().velocity.z < 0)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        }
        else
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        //isRowing = tracker01.transform.position.x  - tracker04.transform.position.x;
        
        float tmp = Vector3.Distance(tracker01.transform.position, tracker04.transform.position);  //�� ������

        if (tmp <= 1)
        {
            isRowing = tmp;
            if (anim_boat.GetBool("isRow"))
            {
                anim_boat.SetFloat("Move", isRowing);
            }
            else
            {
                anim_boat.SetFloat("Move", 1-isRowing);
            }
            
            anim_men.SetFloat("Move", isRowing);

        }
        //print("isRowing : " + isRowing);

    }

    //private void OnGUI()
    //{
    //    if (GUI.Button(new Rect(0, 0, 300, 150), "��ư"))
    //    {
    //        this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1) * 300);
    //    }
    //}
}
