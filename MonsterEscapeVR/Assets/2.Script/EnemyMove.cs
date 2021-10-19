using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum e_state
{
    playing,
    waiting,
}

public class EnemyMove : MonoBehaviour
{
    public int GameMode; //1�� - �Ǿ�, 2�� - ���, 3�� - ũ����

    public float speed = 5f;
    public float attackPower = 1f;
    public float delayCount;

    private GameObject player; //�÷��̾ ���� ����

    Animator ani; //���� �ִ� ��Ʈ�ѷ�
    
    Light lit;
   
    private float enumSpeed; //���� �ӵ�

    private GameObject angImage;
    private Color color;

    float angDis; //�г��忡 �� ��ġ
    float angDuration; //�г� ���ӽð�
    
    bool angEnter=false;
    bool angry = false;
    //float time;

    private e_state enemyState = e_state.waiting;

    void Start()
    {
        //�÷��̾ ã�Ƽ� ��´�
        player = GameObject.Find("Player");

        Destroy(GameObject.Find("BGM")); //����� �����. ��忡 �´� ����̶� ��ġ�� �ȵǴϱ�

        //GameOverUI_player = GameObject.Find("PlayerCanvas").transform.Find("GameOverUI_Fail").gameObject;
        ani = GetComponent<Animator>(); //�ִϸ����� ���

        //ũ�ƾƾ� �Ҹ� �Ҵ�
        //sound = GetComponent<AudioSource>();

        lit = GameObject.Find("Directional Light").GetComponent<Light>(); //���� ã�� ��´�

        if (GameMode == 1)
        {
            enumSpeed = 3; //�Ǿ��� ����Ʈ
            angDis = -40; //angDis��ŭ ���� �г���!
            angDuration = 5; //�󸶵��� �г��� ���ΰ�?
        }
        else if(GameMode == 2)
        {
            enumSpeed = 5; //����� ���ǵ�
            angDis = -30;
            angDuration = 10;
        }
        else
        {
            enumSpeed = 7; // ũ������ ���ǵ�
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
       
        if(GameMng.Instance.playerState == state.playing)
        {
            
            if(enemyState == e_state.waiting)
            {
                enemyState = e_state.playing;
                //��ȿ �Ҹ� �ֱ� 
                SoundMng.Instance.Enemy_s();

                //�г� �ִ� 
                ani.SetBool("Angry", true);
                print("angry");

            }

            if(enemyState == e_state.playing)
            {
                if (GameMode == 1) //�Ǿ� 
                {
                    if (GameMng.Instance.time >= 3)
                    {
                        //�÷��̾ �Ѿư���.
                        transform.position -= Vector3.forward * enumSpeed * Time.deltaTime;
                    }

                }
                else if (GameMode == 2) //��� 
                {

                    if (GameMng.Instance.time >= 3)
                    {
                        //�÷��̾ �Ѿư���.
                        transform.position -= Vector3.forward * enumSpeed * Time.deltaTime; ; //�÷��̾��� �ӵ��� ���� ��,�ڷ� �̵��Ѵ�.
                    }

                }
                if (GameMode == 3) //ũ����
                {
                    if (GameMng.Instance.time >= 3)
                    {
                        //�÷��̾ �Ѿư���.
                        transform.position -= Vector3.forward * enumSpeed * Time.deltaTime; ; //�÷��̾��� �ӵ��� ���� ��,�ڷ� �̵��Ѵ�.

                    }
                }
            }
        }

       //print("�÷��̾��� �Ÿ�" + GameMng.Instance.currentdistance);
       if(angDis >= GameMng.Instance.currentdistance) //�г��忡 ���� ���� ����
        {
        
            //print("�г��� ����");
            if(angEnter == false)
            {
                angDis -= 100;
                StartCoroutine(AngryMode());
            }
            
            
            //if (angEnter == false)
            //{
            //    color.a = 1;
            //    angImage.GetComponent<Image>().color = color;
            //    //sound.Play(); //��ȿ�Ҹ� ���
            //    //ani.SetBool("Angry", true); //��� ��ȿ�Ѵ�
            //    //angEnter = true;
            //    enumSpeed = enumSpeed + 5f; //���� �ӵ��� ���δ�.
            //}

            //StartCoroutine(AngryAlpha());

            //if(angDuration >= time) //�г���� angDuration ���� ����
            //{//�г�����
            //    angDis -= 20;
            //    color.a = 0;
            //    angImage.GetComponent<Image>().color = color;
            //    ani.SetBool("Angry", false); //��ȿ �ִ� ����
            //    enumSpeed = enumSpeed - 5f; //���� �ӵ� �ٽ� ���󺹱�
            //}

        }
       

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            StartCoroutine(GameOver());
        }
    }

    IEnumerator Fadeout()
    {
        while (lit.intensity > 0)
        {
            lit.intensity -= Time.deltaTime;
            yield return null;
        }
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

    IEnumerator AngryMode()
    {
        color.a = 1;
        angImage.GetComponent<Image>().color = color;
        
        //sound.Play(); //��ȿ�Ҹ� ���
        SoundMng.Instance.Enemy_s();
        
        ani.SetBool("Angry", true); //��� ��ȿ�Ѵ�
        
        enumSpeed = enumSpeed *1.2f; //���� �ӵ��� ���δ�.
        StartCoroutine(AngryAlpha());

        yield return new WaitForSeconds(angDuration);
        

        color.a = 0;
        angImage.GetComponent<Image>().color = color;
        ani.SetBool("Angry", false); //��ȿ �ִ� ����
        enumSpeed = enumSpeed/1.2f; //���� �ӵ� �ٽ� ���󺹱�

        angEnter = true;
    }

    IEnumerator GameOver()
    {
        GameMng.Instance.playerState = state.die;
        enemyState = e_state.waiting;
        //gameoversound ���
        SoundMng.Instance.GameOver_s();
        ani.SetBool("Byte", true); //������ ������ ���� ���� �ӾӰŸ���.
        StartCoroutine(Fadeout());

        yield return new WaitForSeconds(3);

        UIMng.Instance.update_gameOverUI();
        
    }

    
}
