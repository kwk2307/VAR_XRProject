using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToIdleAni : MonoBehaviour
{
    // �ִϸ��̼��� ������ Idle�� �����Ѵ�.
    GameObject Enemy;
    Animator anim;
    void Start()
    {
        Enemy = GameObject.Find("Shark_Charactor");
        anim = Enemy.transform.GetComponent<Animator>();
        anim.SetBool("Angry", false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
