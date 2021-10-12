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




    void Start()
    {
        text= GameObject.Find("Text").GetComponent<Text>();
        WarmUpVideo.Stop();
        StartCoroutine("Greet");
       
    }

    // Update is called once per frame
    void Update()
    {
       //print(anim_boat.GetFloat("isRow"));
        //print(WarmUpVideo.isPlaying);
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
        yield return new WaitForSeconds(2);
        
        if(WarmUpVideo.isPlaying == true)
        {
            WarnUp.SetActive(false);
            StartCoroutine(GuideRowing());
        }

    }
    IEnumerator GuideRowing()
    {

        text.text = "���������� ���׸ӽ��� ������ ������ڽ��ϴ�";
        yield return new WaitForSeconds(5);
        //���׸ӽ� ������ ���

        text.text = "���� �� �� �غ��ڽ��ϴ�";
        yield return new WaitForSeconds(5);
        text.text = "��ܺ�����";

        //������ ����
        if(anim_boat.GetFloat("isRow") >= 0.8f)
        {
            text.text = "�� �ϼ̽��ϴ�. �ٽ� ������ ���ڽ��ϴ�";
        }

        //������ ������
        if (anim_boat.GetFloat("isRow") <= 0.2f)
        {
            text.text = "�� �ϼ̽��ϴ�.";
        }
        
        yield return new WaitForSeconds(5);
        text.text = "������ �������� �غ��ڽ��ϴ�";

        //�� �ϸ�
        text.text = "�� �ϼ̽��ϴ�.";


    }
}
