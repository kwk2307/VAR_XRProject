using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Raycast : MonoBehaviour
{
    public Image Gazepointer;

    private float timeElapsed = 0;

    //���̵����� ���� ������

    private bool enterFade = false;

    bool getEvent = false; //ȭ�� �ε尡 ������ �Ǵ� ���� ��������

    void Update()
    {
       
        RaycastHit hit;//������Ʈ ����

        Vector3 forward = transform.TransformDirection(Vector3.forward);//����
        //UI���̾ �ɸ�
        LayerMask layerMask = 1 << LayerMask.NameToLayer("UI");

        if (Physics.Raycast(this.transform.position, forward, out hit, Mathf.Infinity, layerMask)) 
        {
            
            timeElapsed += Time.deltaTime;//�ð� ����
            Gazepointer.fillAmount = timeElapsed / 2;//�̹��� fill ä����

            if (timeElapsed >= 2 && getEvent == false)//2�ʰ� �Ǹ�
            {
                print("click");
                //��ư ȿ���� ���
                SoundMng.Instance.ToggleSoundStart();

                //��ư onClick �̺�Ʈ �߻�
                hit.transform.GetComponent<Button>().onClick.Invoke();

                getEvent = true; //�ߺ����� ����

            }

        }
        else
        {
            timeElapsed -= Time.deltaTime;
            Gazepointer.fillAmount = timeElapsed / 2;

            getEvent = false; //�ߺ����� ����

            if (timeElapsed <= 0) timeElapsed = 0;
        }
    }
    
}
