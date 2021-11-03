using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroManager : MonoBehaviour
{
    public float distance = 110;
    public float delayTime = 0f;
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Enemy")
        {
            //�ִϸ����Ͱ� �ִٸ�
            /*if (other.gameObject.GetComponent<Animator>() != null)
            {
                //�ִϸ����� ����� ���߰�
                other.gameObject.GetComponent<Animator>().Rebind();
                other.gameObject.GetComponent<Animator>().Update(0f);
                print("�ִϸ����� ��� ����");
            }*/

            other.transform.position -= Vector3.forward * distance;
            Instantiate(other);
            Destroy(other.gameObject);

        }
    }

}
