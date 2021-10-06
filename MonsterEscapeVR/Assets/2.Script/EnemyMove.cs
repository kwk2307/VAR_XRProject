using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] float enumSpeed; //���� �ӵ�

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
            enumSpeed = 2; //�Ǿ��� ����Ʈ
        }
        else if(GameMode == 2)
        {
            enumSpeed = 2.5f; //����� ���ǵ�
        }
        else
        {
            enumSpeed = 5; // ũ������ ���ǵ�
        }
    }

    // Update is called once per frame
    void Update()
    {
        delayCount += Time.deltaTime;
        if(delayCount >= 3)
        {
            if (GameMode == 1 && delayCount >= 6) //�Ǿ� 
            {
                    //�÷��̾ �Ѿư���.
                    transform.position -= Vector3.forward * (enumSpeed - GameMng.Instance.currentspeed) * Time.deltaTime; ; //�÷��̾��� �ӵ��� ���� ��,�ڷ� �̵��Ѵ�.
                

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
                    transform.position -= Vector3.forward * (enumSpeed - GameMng.Instance.currentspeed) * Time.deltaTime; ; //�÷��̾��� �ӵ��� ���� ��,�ڷ� �̵��Ѵ�.

                }

            }
            if (GameMode == 3) //ũ����
            {
                if (delayCount >= 4)
                {
                    //�÷��̾ �Ѿư���.
                    transform.position -= Vector3.forward * (enumSpeed - GameMng.Instance.currentspeed) * Time.deltaTime; ; //�÷��̾��� �ӵ��� ���� ��,�ڷ� �̵��Ѵ�.

                }
                    

            }

            

        }

       


    }
    // �浹�������
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            // ���ӿ���(����) ���尡 ���

            // ���ӿ���(����) ����Ʈ�� ����

            // �� ���ڸ��� �����
            speed = 0;
            // ����ð� ī��Ʈ�� �����
            //SpectatorViewUI1 sv = GameObject.Find("Spectator_Canvas").GetComponent<SpectatorViewUI1>();
            //sv.count = 0;

            // ���ӿ��� UI�� Ȱ��ȭ�ȴ�.
            GameOverUI.SetActive(true);

            //���� �̵� ����
            enumSpeed = GameMng.Instance.currentspeed;




            ani.SetBool("Byte", true); //������ ������ ���� ���� �ӾӰŸ���.
        }
    }
    private void OnCollisionStay(Collision collision)//�÷��̾� ĵ������ �ִ� ���ӿ��� UI�� Ȱ��ȭ
    {
        //�ٷ� ���ӿ��� UI�� �߸� ������ڳ�
        delayTime += Time.deltaTime;
        if (delayTime >= 3) //3�� ������ ���п��� ����
        {
            GameOverUI_player.SetActive(true);

        }

        //���� ��Ӱ� �غ��ô�
        StartCoroutine(FadeOut());

    }
    IEnumerator FadeOut()
    {
        lit.intensity -= Time.deltaTime;
        yield return 1;
    }


}
