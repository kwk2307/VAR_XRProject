using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    public int GameMode; //1�� - �Ǿ�, 2�� - ���, 3�� - ũ����

    public float speed = 5f;
    public float attackPower = 1f;
    public float delayCount;

    private GameObject player; //�÷��̾ ���� ����
    public GameObject GameOverUI; // ���ӿ���(����)UI
    GameObject GameOverUI_player; // �÷��̾� ĵ������ �ִ� ���ӿ��� UI
    Animator ani; //���� �ִ� ��Ʈ�ѷ�
    AudioSource sound; //��ȿ �Ҹ�

    Light lit;

    bool start = false;
    float delayTime;
    public static float enumSpeed; //���� �ӵ�

    GameObject angImage;
    float angDis; //�г��忡 �� ��ġ
    Color color;
    bool angEnter=false;
    bool angry = false;
    float angDuration; //�г� ���ӽð�
    float time;

    void Start()
    {
        //�÷��̾ ã�Ƽ� ��´�
        player = GameObject.Find("Player");

        Destroy(GameObject.Find("BGM")); //����� �����. ��忡 �´� ����̶� ��ġ�� �ȵǴϱ�

        GameOverUI_player = GameObject.Find("PlayerCanvas").transform.Find("GameOverUI_Fail").gameObject;
        ani = GetComponent<Animator>(); //�ִϸ����� ���

        //ũ�ƾƾ� �Ҹ� �Ҵ�
        sound = GetComponent<AudioSource>();

        lit = GameObject.Find("Directional Light").GetComponent<Light>(); //���� ã�� ��´�

        if (GameMode == 1)
        {
            enumSpeed = 3; //�Ǿ��� ����Ʈ
            angDis = -40; //angDis��ŭ ���� �г���!
            angDuration = 5; //�󸶵��� �г��� ���ΰ�?
        }
        else if(GameMode == 2)
        {
            enumSpeed = 2f; //����� ���ǵ�
            angDis = -30;
            angDuration = 10;
        }
        else
        {
            enumSpeed = 2; // ũ������ ���ǵ�
            angDis = -20;
            angDuration = 15;
        }
        angImage = GameObject.Find("Angry");
        color = angImage.GetComponent<Image>().color;
        color.a = 0f;
        angImage.GetComponent<Image>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
        delayCount += Time.deltaTime;
        if(delayCount >= 3)
        {
            if (GameMode == 1 && delayCount >= 5.5) //�Ǿ� 
            {
                if ( start == false)
                {
                    //��ȿ �Ҹ� ���
                    sound.Play();

                    //�ٽ� �� ���� �ȵ������� ���´�
                    start = true;
                }
                if(delayCount >= 6 && GameMng.Instance.isPlaying == true)
                {
                    //�÷��̾ �Ѿư���.
                    transform.position -= Vector3.forward * enumSpeed * Time.deltaTime;

                }
                
                

            }
            if (GameMode == 2) //��� 
            {
                if (delayCount >= 3 && start == false)
                {
                    //ũ�ƾƾ�
                    ani.SetBool("Angry", true);

                    //��ȿ �Ҹ� ���
                    sound.Play();

                    //�ٽ� �� ���� �ȵ������� ���´�
                    start = true;


                }
                if (delayCount >= 6)
                {
                    //ũ�ƾ��� ���߰�
                    ani.SetBool("Angry", false);

                    //�÷��̾ �Ѿư���.
                    transform.position -= Vector3.forward * enumSpeed * Time.deltaTime; ; //�÷��̾��� �ӵ��� ���� ��,�ڷ� �̵��Ѵ�.

                }

            }
            if (GameMode == 3) //ũ����
            {
                //ũ������ ��ȿ
                if(delayCount >= 3.5 && start ==false)
                {
                    sound.Play();
                    start = true;
                }
                if (delayCount >= 6)
                {
                    //�÷��̾ �Ѿư���.
                    transform.position -= Vector3.forward * enumSpeed * Time.deltaTime; ; //�÷��̾��� �ӵ��� ���� ��,�ڷ� �̵��Ѵ�.

                    

                }
                    

            }

            

        }

        //print("�÷��̾��� �Ÿ�" + GameMng.Instance.currentdistance);
       if(angDis >= GameMng.Instance.currentdistance && angry==false) //�г��忡 ���� ���� ����
        {
            print("�г��� ����");
            time += Time.deltaTime;
            angry = true;
            if (angEnter == false)
            {
                color.a = 1;
                angImage.GetComponent<Image>().color = color;

                sound.Play(); //��ȿ�Ҹ� ���
                ani.SetBool("Angry", true); //��� ��ȿ�Ѵ�
                angEnter = true;

            }
           

            StartCoroutine(AngryAlpha());

            if(angDuration <= time) //�г���� angDuration ���� ����
            {//�г�����
                angDis -= 20;
                color.a = 0;
                angImage.GetComponent<Image>().color = color;
                ani.SetBool("Angry", false); //��ȿ �ִ� ����

            }

        }
       


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            GameMng.Instance.isPlaying = false;

            //���� �̵� ����
            ani.SetBool("Byte", true); //������ ������ ���� ���� �ӾӰŸ���.
        }
    }
    private void OnTriggerStay(Collider other)
    {
        delayTime += Time.deltaTime;
        if (delayTime >= 3) //3�� ������ ���п��� ����
        {
            GameOverUI_player.SetActive(true);
            print("���� UIȰ��ȭ");
        }

        //���� ��Ӱ� �غ��ô�
        StartCoroutine(FadeOut());
    }
    // �浹�������
    private void OnCollisionEnter(Collision collision)
    {
    
    }
    private void OnCollisionStay(Collision collision)//�÷��̾� ĵ������ �ִ� ���ӿ��� UI�� Ȱ��ȭ
    {
        //�ٷ� ���ӿ��� UI�� �߸� ������ڳ�

    }

    IEnumerator FadeOut()
    {
        lit.intensity -= Time.deltaTime;
        yield return 1;
    }

    IEnumerator AngryAlpha() //�г��� �̹��� ���İ� �Դٰ���
    {
        print("�г��� �ڷ�ƾ ����");
        color.a = Mathf.Lerp(1, 0.7f, 2);
        angImage.GetComponent<Image>().color = color;
        yield return new WaitForSeconds(2f);
        color.a = Mathf.Lerp(0.7f, 1, 2);
        angImage.GetComponent<Image>().color = color;
        yield return new WaitForSeconds(2f);

        angry = false;

    }

}
