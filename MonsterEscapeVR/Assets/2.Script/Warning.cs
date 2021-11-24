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

    void Start()
    {
        enemy = GameObject.Find("Enemy");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameMng.Instance.playerState == state.playing)
        {
            enemyDis = Vector3.Distance(player.transform.position, enemy.transform.position);
            if (warnDis > enemyDis && warn == false)
            {
                warn = true;
                StartCoroutine(PlayWarning());
            }
        }
       
    }

    IEnumerator PlayWarning()
    {
        warningEffect.SetActive(true);

        yield return new WaitForSeconds(3f);

        warningEffect.SetActive(false);

        warn = false;
    }


    
}
