using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPointTrig : MonoBehaviour
{
    // ���ӿ���(����) �κ� 

    public GameObject gameWinUI;
    public Text time;

    // �ְ��� Ȯ�� �κ�
    public string bestRecord;
    // �ְ���(��,��,�и���) 
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            

            // ���� ���� ���

            // ���� ����Ʈ ����

            // �� �߰��� �����.(�ִϸ��̼ǵ� ���߿� �־���� 9/7)
            EnemyMove em = GameObject.Find("Enermy").GetComponent<EnemyMove>();
            em.speed = 0;


            // ���� ����(�¸�)UI Ȱ��ȭ(���⿡ �ð�,�ӵ� ���� �ؽ�Ʈ�� ��Ÿ��)
            gameWinUI.SetActive(true);

            // �ð� ����(���� �� ����)
            SpectatorViewUI1 sv = GameObject.Find("Spectator_Canvas").GetComponent<SpectatorViewUI1>();
            sv.count = 0;
            // ������ ����� �ؽ�Ʈ�� ǥ��
            time.text = "Time: " + sv.MinuteBox.GetComponent<Text>().text + sv.SecondBox.GetComponent<Text>().text + sv.MilliBox.GetComponent<Text>().text;
            // �ְ������� �ƴ��� Ȯ��

            // ���� �������� �ְ����̶�� �ű�� ����Ʈ+���� ����





            


        }

    }

}
