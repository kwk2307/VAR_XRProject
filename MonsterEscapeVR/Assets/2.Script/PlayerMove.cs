using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    #region
/*public class PlayerMove : MonoBehaviour

{

public GameObject tracker01;
public GameObject tracker04;
float distance; //Ʈ��Ŀ�� ������ �Ÿ��� ���� ����
public float speed = 1;
GameObject curPos;
GameObject prePos;
float isRowing;
float isRowingPre;

// ���ӿ���(����) �κ� 

public GameObject gameWinUI;
public Text time;

// �ְ��� Ȯ�� �κ�
public string bestRecord;
// �ְ���(��,��,�и���) 

public GameObject warningEffect;
public float warnDis = 5; //�󸶳� ���� ��������� ����� ���ΰ�?


float enemyDis;
GameObject enemy;



void Start()
{
     enemy = GameObject.Find("Enemy");

}

// Update is called once per frame
void Update()
{


    curPos = this.gameObject;
    Debug.Log("test");

    if (prePos == null) return;  // ù ������ ����ó��


    isRowing = Vector3.Distance(curPos.transform.position, prePos.transform.position);  //�� ������
    print(1);

    //���ױ⸦ ������ Ȯ��
    if ((isRowing - isRowingPre) > 0)
    {
        {
            transform.position += new Vector3(1, 0, 0) * distance; // ��� �Ϳ� ����� z������ �̵�

        }
    }



    distance = Vector3.Distance(tracker01.transform.position, tracker04.transform.position);
    print(distance);



    prePos = this.gameObject;
    isRowingPre = Vector3.Distance(curPos.transform.position, prePos.transform.position); // ���� ������(���� ������ ���忡��)


}
// �÷��̾ ��ǥ�������� �����Ѱ��
private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.name.Contains("EndPoint"))
    {
        // �׽�Ʈ�� (��������)

        // �������� ���

        // ���� ����Ʈ ����

        // �� �߰��� �����.(�ִϸ��̼ǵ� ���߿� �־���� 9/7)
        EnemyMove em = GameObject.Find("Shark_Charactor").GetComponent<EnemyMove>();
        em.speed = 0;


        // ���� ����(�¸�)UI Ȱ��ȭ(���⿡ �ð�,�ӵ� ���� �ؽ�Ʈ�� ��Ÿ��)
        gameWinUI.SetActive(true);

        // �ð� ����(���� �� ����)
        SpectatorViewUI1 sv = GameObject.Find("Spectator_Canvas").GetComponent<SpectatorViewUI1>();
        sv.count = 0;
        // ������ ����� �ؽ�Ʈ�� ǥ��
        time.text = "Time: " + sv.MinuteBox.GetComponent<Text>().text  + sv.SecondBox.GetComponent<Text>().text  + sv.MilliBox.GetComponent<Text>().text;
        // �ְ������� �ƴ��� Ȯ��

        // ���� �������� �ְ����̶�� �ű�� ����Ʈ+���� ����





        // �ӵ� ����(��� �ӵ�,�ְ� �ӵ�)�� ��������



        // ���� �����Ÿ� �̻� ��������� ���!!
        enemyDis =  Vector3.Distance(this.transform.position, enemy.transform.position);
        if(warnDis > enemyDis)
        {
            StartCoroutine(PlayWarning());
        }

    }

}
private void OnGUI()
{
    if (GUI.Button(new Rect(300, 0, 300, 150), "�ٽ��ϱ�"))
    {
        // �ٽ��ϱ�(�����)
        GameMng gm = GameObject.Find("Click").GetComponent<GameMng>();


        gm.SceneChange();
    }
}

IEnumerator PlayWarning()
{
    warningEffect.SetActive(true);
    yield return new WaitForSeconds(3f);

    warningEffect.SetActive(false);
    //yield return new WaitForSeconds(2f);
}
}*/
#endregion  �̰� ����ϰ� �ִ� ��ũ��Ʈ�� �ƴ�! Rowing��ũ��Ʈ�� ������~