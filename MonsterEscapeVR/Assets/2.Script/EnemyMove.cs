using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 5f;
    public float attackPower = 1f;
    public float delayCount;

    private GameObject player; //�÷��̾ ���� ����
    public GameObject GameOverUI; // ���ӿ���(����)UI
    void Start()
    {
        //�÷��̾ ã�Ƽ� ��´�
        player = GameObject.Find("Player");

        Destroy(GameObject.Find("BGM")); //����� �����. ��忡 �´� ����̶� ��ġ�� �ȵǴϱ�
        
    }

    // Update is called once per frame
    void Update()
    {
        delayCount += Time.deltaTime;
        if (delayCount >= 3)
        {

            //�÷��̾ �Ѿư���.
            transform.position -= Vector3.forward * speed;


        }
    }
    // �浹�������
    private void OnCollisionEnter(Collision collision)
    {
        print("�浹");
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
        }
    }
    
}
