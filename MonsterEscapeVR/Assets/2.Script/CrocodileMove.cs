using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocodileMove : MonoBehaviour
{
    public float speed = 5f;
    public float attackPower = 1f;
    public float delayCount;

    private GameObject player; //�÷��̾ ���� ����
    public GameObject GameOverUI; // ���ӿ���(����)UI
     GameObject GameOverUI_player; // �÷��̾� ĵ������ �ִ� ���ӿ��� UI
    Animator ani; //�ִ�
    private float delayTime;

    Light lit;

    void Start()
    {
        //�÷��̾ ã�Ƽ� ��´�
        player = GameObject.Find("Player");

        Destroy(GameObject.Find("BGM")); //����� �����. ��忡 �´� ����̶� ��ġ�� �ȵǴϱ�

        GameOverUI_player = GameObject.Find("PlayerCanvas").transform.Find("GameOverUI_Fail").gameObject;
        ani = GetComponent<Animator>();

        lit = GameObject.Find("Directional Light").GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        delayCount += Time.deltaTime;
        if (delayCount >= 6.5)
        {
            //ũ�ƾƾ�
            ani.SetBool("Angry", true);

            //�÷��̾ �Ѿư���.
            transform.position -= Vector3.forward * speed;


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
            SpectatorViewUI1 sv = GameObject.Find("Spectator_Canvas").GetComponent<SpectatorViewUI1>();
            sv.count = 0;

            // ���ӿ��� UI�� Ȱ��ȭ�ȴ�.
            GameOverUI.SetActive(true);
            

            ani.SetBool("GoByte", true); //������ ������ �Ǿ ���� �ӾӰŸ���.
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
