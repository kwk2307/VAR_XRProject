using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{

    public GameObject warningEffect;

    public float warnDis = 15; //�󸶳� ���� ��������� ����� ���ΰ�?

    float enemyDis;
    GameObject enemy;

    bool warn; //��� UI�� ����ġ�� �ݺ��Ǵ� �� ���� ���� ���� ����

    void Start()
    {
        enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        enemyDis = Vector3.Distance(this.transform.position, enemy.transform.position);
        if (warnDis > enemyDis && warn == false)
        {
            warn = true;
            StartCoroutine(PlayWarning());
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

    private void OnCollisionEnter(Collision collision)
    {
        //��� UI�ȶߵ���
        Destroy(warningEffect);
    }

}
