using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Raycast : MonoBehaviour
{

    private float timeElapsed = 0;
    public AudioSource shotSound;

    public GameObject shotEf;
    
    void Update()
    {
        RaycastHit hit;//������Ʈ ����

        Vector3 forward = transform.TransformDirection(Vector3.forward);//����
        //UI���̾ �ɸ�
        LayerMask layerMask = 1 << LayerMask.NameToLayer("UI");

        if (Physics.Raycast(this.transform.position, forward, out hit, Mathf.Infinity, layerMask)) 
        {
            if(hit.transform.tag == "MiniEnemy") //������ �����ͷ� �̴� ���� �ôٸ�
            {
              
                timeElapsed += Time.deltaTime;//�ð� ����
                if (timeElapsed >= 0.5f)//0.5�ʰ� �Ǹ�
                {
                    Instantiate(shotEf, hit.transform.position,Quaternion.identity);
                    hit.transform.GetComponent<Animator>().SetBool("Hit", true); //�״� �ִϸ��̼� ���
                    if(hit.transform.Find("spear") != null) //�ۻ��� �ִٸ�
                    {
                        hit.transform.Find("spear").gameObject.SetActive(true);
                    }
                    
                    hit.transform.GetComponent<MinionMove>().gameObject.SetActive(false); //���� ������ ����
                    
                    shotSound.Play(); //�ѼҸ��� ����
                    if(timeElapsed >= 0.8) //0.3�� �ڿ� ����
                    {
                        Destroy(hit.transform.gameObject);// �ٶ� �̴� �� ����
                        timeElapsed = 0f;
                    }
                    
                }
            }

        }
        else
        {
            timeElapsed -= Time.deltaTime;
            
            if (timeElapsed <= 0) timeElapsed = 0;
        }
    }
    
}
