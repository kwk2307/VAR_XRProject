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
                if (timeElapsed >= 0.1f)//0.5�ʰ� �Ǹ�
                {
                    if(shotEf != null) Instantiate(shotEf, hit.transform.position,Quaternion.identity); //����Ʈ �����
                    hit.transform.tag = "UI";

                    //�ڷ�ƾ �߻�
                    StartCoroutine(hit.transform.GetComponent<MinionMove>().DeadMinion());
                    
                    shotSound.Play(); //�ѼҸ��� ����

                    timeElapsed = 0;
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
