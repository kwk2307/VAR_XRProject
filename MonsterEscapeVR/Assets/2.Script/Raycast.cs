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
            print(hit.transform.name);
            if(hit.transform.tag == "MiniEnemy") //������ �����ͷ� �̴� ���� �ôٸ�
            {
                print("�̴Ͼ��� �ٶ�");
                timeElapsed += Time.deltaTime;//�ð� ����
                if (timeElapsed >= 0.5f)//0.5�ʰ� �Ǹ�
                {
                    print("���� �ٶ���0.5�ʰ� ����");
                    Instantiate(shotEf, hit.transform.position,Quaternion.identity); //����Ʈ �����

                    //�ڷ�ƾ �߻�
                    StartCoroutine(hit.transform.GetComponent<MinionMove>().DeadMinion());
                    hit.transform.tag = "UI";
                    shotSound.Play(); //�ѼҸ��� ����
                }
                
            }

        }
        else
        {

            timeElapsed -= Time.deltaTime;
            if(timeElapsed < 0)
            {
                timeElapsed = 0;
            }
        }
    }
    
}
