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
    
    public float delayCount;

    private GameObject player; //�÷��̾ ���� ����

    Animator ani; //���� �ִ� ��Ʈ�ѷ�
    
    Light lit;
   
    private float enumSpeed; //���� �ӵ�
    private float waitSpeed; //���� �ӵ��� �ӽ÷� ������ �� �׸�

    private GameObject angImage;
    private Color color;
    
    float angTime; //�г��忡 �����ϴ� �ð� ����
    float ttime;
    float angDuration; //�г� ���ӽð�

    bool angEnter = false;
    float angryinterval;
    //float time;

    private e_state enemyState = e_state.waiting;

    public GameObject[] minionFactory;

    public AudioSource gunCocking;

    //�Ǿ� ������ ���� ����
    public GameObject sphere;
    public GameObject[] pos;
    GameObject ob;

    public GameObject star;

    void Start()
    {
        //�÷��̾ ã�Ƽ� ��´�
        player = GameObject.Find("Player");

        //GameOverUI_player = GameObject.Find("PlayerCanvas").transform.Find("GameOverUI_Fail").gameObject;
        ani = GetComponent<Animator>(); //�ִϸ����� ���

        lit = GameObject.Find("Directional Light").GetComponent<Light>(); //���� ã�� ��´�

        if (GameMode == 1)
        {
            enumSpeed = 4.8f; //�Ǿ��� ����Ʈ 2.8
            angTime = 30; //angTime��ŭ �ð��� �帣�� �г��� 30
            angDuration = 10; //�г� ���ӽð�
            angryinterval = 110; //�󸶵ڿ� �ٽ� �г��� ���ΰ�?
        }
        else if(GameMode == 2)
        {
            enumSpeed = 5.4f; //����� ����Ʈ
            angTime = 25; 
            angDuration = 20; //�󸶵��� �г��� ���ΰ�?
            angryinterval = 80; //�󸶵ڿ� �ٽ� �г��� ���ΰ�?
        }
        else
        {
            enumSpeed = 5.8f; // ũ������ ���ǵ�
            angTime = 20;
            angDuration = 15;
            angryinterval = 70; //�󸶵ڿ� �ٽ� �г��� ���ΰ�?
        }
        angImage = GameObject.Find("Angry");
        color = angImage.GetComponent<Image>().color;
        color.a = 0f;
        angImage.GetComponent<Image>().color = color;
        angImage.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
       
        if(GameMng.Instance.playerState == state.playing)
        {
            ttime += Time.deltaTime;
            if(enemyState == e_state.waiting)
            {
                enemyState = e_state.playing;
                //��ȿ �Ҹ� �ֱ� 
                SoundMng.Instance.Enemy_s();
                
            }

            if(enemyState == e_state.playing)
            {
                //�г� �ִ� 
                ani.SetBool("Start", true);

                if (GameMode == 1) //�Ǿ� 
                {
                    if (GameMng.Instance.time >= 6)
                    {
                        

                        //�÷��̾ �Ѿư���.
                        transform.position -= Vector3.forward * enumSpeed * Time.deltaTime;
                        
                    }

                }
                else if (GameMode == 2) //��� 
                {

                    if (GameMng.Instance.time >= 6)
                    {
                        //�÷��̾ �Ѿư���.
                        transform.position -= Vector3.forward * enumSpeed * Time.deltaTime; ; //�÷��̾��� �ӵ��� ���� ��,�ڷ� �̵��Ѵ�.
                        
                    }

                }
                if (GameMode == 3) //ũ����
                {
                    if (GameMng.Instance.time >= 6)
                    {
                        //�÷��̾ �Ѿư���.
                        transform.position -= Vector3.forward * enumSpeed * Time.deltaTime; ; //�÷��̾��� �ӵ��� ���� ��,�ڷ� �̵��Ѵ�.
                        

                    }
                }
            }
        }

       //print("�÷��̾��� �Ÿ�" + GameMng.Instance.currentdistance);
       if(angTime <= ttime) //�г��忡 ���� ���� ����
        {  StartCoroutine(AngryMode());
            angTime += angTime;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
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
        color.a = Mathf.Lerp(1, 0.7f, 2);
        angImage.GetComponent<Image>().color = color;
        yield return new WaitForSeconds(2f);
        color.a = Mathf.Lerp(0.7f, 1, 2);
        angImage.GetComponent<Image>().color = color;
        yield return new WaitForSeconds(2f);
        
    }

    IEnumerator AngryMode()
    {
        //�̴Ͼ� ���丮 Ȱ��ȭ
        minionFactory[0].SetActive(true);
        minionFactory[1].SetActive(true);
        minionFactory[2].SetActive(true);

        //�̴Ͼ� �ȳ� ���� ��� 
        SoundMng.Instance.MinionWarn();

        //�г� ����ǥ ǥ�� 
        angImage.SetActive(true);
        //������ �����͵� Ȱ��ȭ
        UIMng.Instance.on_gazePointer_target();
        //óĿ�� �Ҹ� ���
        gunCocking.Play();

        color.a = 1;
        angImage.GetComponent<Image>().color = color;
        
        SoundMng.Instance.Enemy_s();
        
        ani.SetBool("Angry", true); //��� ��ȿ�Ѵ�
        
        enumSpeed = enumSpeed *1.2f; //���� �ӵ��� ���δ�.
        //StartCoroutine(AngryAlpha()); //����ǥ ����Ÿ���

        yield return new WaitForSeconds(angDuration);
        

        color.a = 0; //����ǥ ����
        angImage.GetComponent<Image>().color = color;
        ani.SetBool("Angry", false); //��ȿ �ִ� ����
        enumSpeed = enumSpeed/1.2f; //���� �ӵ� �ٽ� ���󺹱�

        //�̴Ͼ� ���丮 ��Ȱ��ȭ
        minionFactory[0].SetActive(false);
        minionFactory[1].SetActive(false);
        minionFactory[2].SetActive(false);
        
        //��� ��ٷ�
        yield return new WaitForSeconds(3f);
        //������ �����͵� ��Ȱ��ȭ
        UIMng.Instance.off_gazePointer_target();
        angImage.SetActive(false);
    }

    IEnumerator GameOver()
    {

        GameMng.Instance.CalcKcal();
        GameMng.Instance.playerState = state.die;
        enemyState = e_state.waiting;
        //gameoversound ���
        SoundMng.Instance.GameOver_s();
        ani.SetBool("Byte", true); //������ ������ ���� ���� �ӾӰŸ���.
        StartCoroutine(Fadeout());

        yield return new WaitForSeconds(3);

        UIMng.Instance.update_gameOverUI();
        // ������ ������ Ȱ��ȭ 
        UIMng.Instance.off_gazePointer_target();
        UIMng.Instance.on_gazePointer_pointer();
        
    }
    
    //�Ǿ� ������
    public IEnumerator CrocoEvent()
    {
        waitSpeed = enumSpeed; //���ǵ� ����
        enumSpeed =  0; //���� ���ǵ� ����
        ani.SetBool("Stun", true); //���� �ִ�
        star.SetActive(true); //��������
        for (int i = 0; i < 3; i++) //���� ����Ʈ
        {
            ob = Instantiate(sphere, pos[i].transform.position, pos[i].transform.rotation) as GameObject;
            ob.transform.LookAt(this.transform);
            ob.transform.SetParent(GameObject.Find("Enemy").transform);
        }

        yield return new WaitForSeconds(3);

        enumSpeed = waitSpeed; //���� �ӵ� ���󺹱�
        
        ani.SetBool("Stun", false); //���� �ִ� ��
        star.SetActive(false); //�������� ��
    }

    public IEnumerator KrakenEvent()
    {
        waitSpeed = enumSpeed; //���ǵ� ����
        enumSpeed = 0; //���� ���ǵ� ����
        ani.SetBool("Stun", true); //���� �ִ�
        star.SetActive(true); //��������
        for (int i = 0; i < 6; i++)
        {
            UIMng.Instance.winExplosion[i].SetActive(true); //���� ����Ʈ
        }

        yield return new WaitForSeconds(3);

        enumSpeed = waitSpeed; //���� �ӵ� ���󺹱�
        for (int i = 0; i < 6; i++)
        {
            UIMng.Instance.winExplosion[i].SetActive(false); //���� ����Ʈ ��Ȱ��ȭ
        }
        ani.SetBool("Stun", false); //���� �ִ� ��
        star.SetActive(false); //�������� ��
    }

    public IEnumerator SharkEvent()
    {
        waitSpeed = enumSpeed; //���ǵ� ����
        enumSpeed = 0; //���� ���ǵ� ����
        star.SetActive(true); //��������

        yield return new WaitForSeconds(3);

        enumSpeed = waitSpeed; //���� �ӵ� ���󺹱�
        star.SetActive(false); //�������� ��
    }
}
