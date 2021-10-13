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
    public GameObject rowing; //���׿���
    public VideoPlayer rowingPlayer;

    [SerializeField] private Animator anim_boat;
    float waitTime;

    bool startRowing = false;
    bool cancelRowing = false;
    GameObject sideCam;

    AudioSource clear;
    public GameObject[] announce;




    void Start()
    {
        text= GameObject.Find("Text").GetComponent<Text>();
        WarmUpVideo.Stop();
        rowingPlayer.Stop();
       

        StartCoroutine("Greet");

        sideCam = GameObject.Find("SideView");
        sideCam.SetActive(false);

        clear = GameObject.Find("ClearSound").GetComponent<AudioSource>();

        

    }

    // Update is called once per frame
    void Update()
    {

        if (startRowing == true)
        {
            if (anim_boat.GetFloat("Position") >= 0.8f)
            {
                clear.Play();
                text.text = "�� �ϼ̽��ϴ�.  �ٽ� ������ �����ڽ��ϴ�.";
                announce[3].SetActive(true);
                cancelRowing = true;
                startRowing = false;
                
            }
            
        }
        if(cancelRowing == true)
        {
            //������ ������
            if (anim_boat.GetFloat("Position") <= 0.2f)
            {
                clear.Play();
                text.text = "�� �ϼ̽��ϴ�.";
                announce[4].SetActive(true);
                cancelRowing = false;
            }


        }


    }
    IEnumerator Greet()
    {
        text.text = "Monster Eescape�� ���� ���� ȯ���մϴ�";
        yield return new WaitForSeconds(3);
        text.text = "�������� ������ �غ��� �����ϰڽ��ϴ�";
        yield return new WaitForSeconds(4.5f);
        text.text = "������ ���� ���׸ӽſ� ����ä�� �������ּ���";
        yield return new WaitForSeconds(6.5f);
        WarnUp.SetActive(true);
        WarmUpVideo.Play();
        yield return new WaitForSeconds((float)(WarmUpVideo.length)); //������ ���̸�ŭ ��ٸ���.
        
            WarnUp.SetActive(false);
            StartCoroutine(GuideRowing());
        

    }
    IEnumerator GuideRowing()
    {

        text.text = "���������� ���׸ӽ��� ������ ������ڽ��ϴ�";
        announce[0].SetActive(true);
        yield return new WaitForSeconds(3);
        //���׸ӽ� ������ ���
        rowing.SetActive(true);
        rowingPlayer.Play();
        yield return new WaitForSeconds((float)(rowingPlayer.length)); //������ ���̸�ŭ ��ٸ���.
        rowing.SetActive(false);

        text.text = "���� ���� �غ��ڽ��ϴ�";
        announce[1].SetActive(true);
        sideCam.SetActive(true);
        yield return new WaitForSeconds(3);
        text.text = "��ܺ�����";
        announce[2].SetActive(true);
        startRowing = true;

    }
}
