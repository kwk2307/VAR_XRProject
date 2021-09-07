using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 5f;
    public float attackPower = 1f;
    public float delayCount;

    float distance;
    public float angryDistance; //�г���� �� �Ÿ�

     Animator anim;

    private GameObject player; //�÷��̾ ���� ����

    GetDistance getDistance;
    public GameObject distanceUI;

    float delay;
    bool getAngry = false;


    void Start()
    {
        //�÷��̾ ã�Ƽ� ��´�
        player = GameObject.Find("Player");

        //�Ÿ� ǥ��UI�� ��ũ��Ʈ�� �����´�.
        getDistance = GameObject.Find("Distance").GetComponent<GetDistance>();


        //�Ÿ� ǥ�� UI���� ������ �г� ��� �Ÿ��� �����´�.
        

        anim = transform.GetComponent<Animator>();

        print(distanceUI.GetComponent<GetDistance>().distance);

    }

    // Update is called once per frame
    void Update()
    {
        //�Ÿ�ǥ�� UI���� ������ �Ÿ��� �����´�.
        distance = getDistance.distance;
        

        delayCount += Time.deltaTime;
        if (delayCount >= 3)
        {

            //�÷��̾ �Ѿư���.
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);

        }
        
        if (distance <= angryDistance && !getAngry) // �� ���� ������ ������ �г���� ��ȯ�� ���ΰ�?
        {
            
            getAngry = true;
            StartCoroutine( SetAni() );
            
            
            
        }

    }

    IEnumerator SetAni()
    {
        anim.SetBool("Angry", true); //�г� �ִϸ��̼� ���.
        yield return new WaitForSeconds(0.77f);
        anim.SetBool("Angry", false);

    }

    
    


}
