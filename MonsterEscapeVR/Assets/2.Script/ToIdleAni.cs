using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToIdleAni : MonoBehaviour
{
    // 애니메이션이 끝나면 Idle로 변경한다.
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
