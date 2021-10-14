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

    public GameObject[] Enemy;
    public GameObject[] angry;



    void Start()
    {
        text= GameObject.Find("Text").GetComponent<Text>();
        WarmUpVideo.Stop();
        rowingPlayer.Stop();
       

        //StartCoroutine("Greet");

        sideCam = GameObject.Find("SideView");
        sideCam.SetActive(false);

        clear = GameObject.Find("ClearSound").GetComponent<AudioSource>();

        StartCoroutine(EnemySay());

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
                sideCam.SetActive(false);
                StartCoroutine(EnemySay());
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
    IEnumerator EnemySay()
    {
        yield return new WaitForSeconds(1);
        text.text = "���� ���� ���� �˷��帮�ڽ��ϴ�.";
        announce[5].SetActive(true);
        yield return new WaitForSeconds(5);

        text.text = "���� ��忡 ���� �Ǿ�, ���, ũ������ �ֽ��ϴ�.";
        announce[6].SetActive(true);

        yield return new WaitForSeconds(1.2f);

        Instantiate(Enemy[0]);
        Enemy[0].transform.position = new Vector3(-10, -0.8f, 23);
        angry[0] = GameObject.Find("Angry");
        GameObject.Find("Angry").SetActive(false);

yield return new WaitForSeconds(1.1f);

        Instantiate(Enemy[1]);
        Enemy[1].transform.position = new Vector3(0, -2.36f, 30);
        angry[1] = GameObject.Find("Angry");
        GameObject.Find("Angry").SetActive(false);

        yield return new WaitForSeconds(1f);

        Instantiate(Enemy[2]).transform.position = new Vector3(20, -3f, 30);
        angry[2] = GameObject.Find("Angry");
        GameObject.Find("Angry").SetActive(false);


        yield return new WaitForSeconds(5);
        text.text = "����� �� �����鿡�Լ� �븦 ���� �����ľ� �մϴ�.";
        announce[7].SetActive(true);
        yield return new WaitForSeconds(5);
        StartCoroutine(GuideAngry());

    }

    IEnumerator GuideAngry()
    {
        text.text = "���� �����ϰ� �г���� ���ϴ�.";
        announce[8].SetActive(true);
        yield return new WaitForSeconds(5);
        text.text = "�г��忡 �� ���� �ӵ��� �������� �����ϼ���!";
        announce[9].SetActive(true);
        yield return new WaitForSeconds(5);
        text.text = "�� ���� ���� ������ ����ǥ�� ���� ���� �г������� �� �� �ֽ��ϴ�.";
        announce[10].SetActive(true);
        for (int i= 0; i< 3; i++)
        {
            angry[i].SetActive(true);
        }
        
    }
}
