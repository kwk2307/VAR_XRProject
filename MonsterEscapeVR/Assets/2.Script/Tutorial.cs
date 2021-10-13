using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Tutorial : MonoBehaviour
{
    Text text;
    float time;
    public GameObject WarnUp;//���־� ����
    public VideoPlayer WarmUpVideo;
    [SerializeField] private Animator anim_boat;
    float waitTime;

    bool startRowing = false;
    bool cancelRowing = false;
    GameObject sideCam;



    void Start()
    {
        text= GameObject.Find("Text").GetComponent<Text>();
        WarmUpVideo.Stop();
        StartCoroutine("Greet");

        sideCam = GameObject.Find("SideView");
        sideCam.SetActive(false);
        


    }

    // Update is called once per frame
    void Update()
    {
        print(anim_boat.GetFloat("Position"));

        if (startRowing == true)
        {
            if (anim_boat.GetFloat("Position") >= 0.8f)
            {
                text.text = "�� �ϼ̽��ϴ�. �ٽ� ������ ���ڽ��ϴ�";
                cancelRowing = true;
                startRowing = false;
                
            }
            
        }
        if(cancelRowing == true)
        {
            //������ ������
            if (anim_boat.GetFloat("Position") <= 0.2f)
            {
                text.text = "�� �ϼ̽��ϴ�.";
                cancelRowing = false;
            }


        }


    }
    IEnumerator Greet()
    {
        text.text = "Monster Eescape�� ���� ���� ȯ���մϴ�";
        yield return new WaitForSeconds(2);
        text.text = "�������� ������ �غ��� �����ϰڽ��ϴ�";
        yield return new WaitForSeconds(2);
        text.text = "������ ���� ���׸ӽſ� ����ä�� �������ּ���";
        yield return new WaitForSeconds(2);
        WarnUp.SetActive(true);
        WarmUpVideo.Play();
        yield return new WaitForSeconds((float)(WarmUpVideo.length)); //������ ���̸�ŭ ��ٸ���.
        
            WarnUp.SetActive(false);
            StartCoroutine(GuideRowing());
        

    }
    IEnumerator GuideRowing()
    {

        text.text = "���������� ���׸ӽ��� ������ ������ڽ��ϴ�";
        yield return new WaitForSeconds(5);
        //���׸ӽ� ������ ���

        text.text = "���� �� �� �غ��ڽ��ϴ�";
        sideCam.SetActive(true);
        yield return new WaitForSeconds(5);
        text.text = "��ܺ�����";
        startRowing = true;

    }
}
