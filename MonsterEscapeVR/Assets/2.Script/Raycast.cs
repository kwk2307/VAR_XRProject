using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Raycast : MonoBehaviour
{
    public Image Gazepointer;

    private float timeElapsed = 0;
    public AudioSource shotSound;

    //���̵����� ���� ������

    private bool enterFade = false;

    

    void Update()
    {
       
        RaycastHit hit;//������Ʈ ����

        Vector3 forward = transform.TransformDirection(Vector3.forward);//����
        //UI���̾ �ɸ�
        LayerMask layerMask = 1 << LayerMask.NameToLayer("UI");

        if (Physics.Raycast(this.transform.position, forward, out hit, Mathf.Infinity, layerMask)) 
        {
            if(hit.transform.tag != "MiniEnemy")
            {
                timeElapsed += Time.deltaTime;//�ð� ����
                Gazepointer.fillAmount = timeElapsed / 2;//�̹��� fill ä����

                if (timeElapsed >= 2)//2�ʰ� �Ǹ�
                {

                    //��ư ȿ���� ���
                    SoundMng.Instance.ToggleSoundStart();
                    print(hit.transform.name);
                    if (hit.transform.GetComponent<Button>() != null)
                    {
                        //��ư onClick �̺�Ʈ �߻�
                        hit.transform.GetComponent<Button>().onClick.Invoke();

                    }
                    else if (hit.transform.GetComponent<Toggle>() != null)
                    {
                        hit.transform.GetComponent<Toggle>().isOn = true;
                    }

                    timeElapsed = 0;
                }
            
            }
            else if(hit.transform.tag == "MiniEnemy") //������ �����ͷ� �̴� ���� �ôٸ�
            {
                timeElapsed += Time.deltaTime;//�ð� ����
                Gazepointer.fillAmount = timeElapsed / 2;//�̹��� fill ä����
                if (timeElapsed >= 2)//2�ʰ� �Ǹ�
                {
                    Destroy(hit.transform.gameObject);// �ٶ� �̴� �� ����
                    shotSound.Play(); //�ѼҸ��� ����
                }
            }

        }
        else
        {
            timeElapsed -= Time.deltaTime;
            Gazepointer.fillAmount = timeElapsed / 2;
            
            if (timeElapsed <= 0) timeElapsed = 0;
        }
    }
    
}
