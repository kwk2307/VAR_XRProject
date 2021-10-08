using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{

    public GameObject warningEffect;

    public float warnDis = 15; //�󸶳� ���� ��������� ����� ���ΰ�?

    float enemyDis;
    GameObject enemy;
    GameObject player;

    bool warn; //��� UI�� ����ġ�� �ݺ��Ǵ� �� ���� ���� ���� ����
    Animator ani;


    void Start()
    {
        enemy = GameObject.Find("Enemy");
        player = GameObject.Find("Player");
        ani = GameObject.Find("Enemy").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyDis = Vector3.Distance(player.transform.position, enemy.transform.position);
        if (warnDis > enemyDis && warn == false)
        {
            warn = true;
            StartCoroutine(PlayWarning());
        }
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Bite")) //���ӿ����� ���� ����
        {
            warningEffect.SetActive(false);
            Destroy(this);
            //��� UI�ȶߵ���

        }
    }

    IEnumerator PlayWarning()
    {
        warningEffect.SetActive(true);

        yield return new WaitForSeconds(3f);

        warningEffect.SetActive(false);
        //yield return new WaitForSeconds(2f);

        warn = false;
        yield return new WaitForSeconds(3f);
    }


    
}
