using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    private float delayTimer = 0;

    private void Start()
    {
        GameMng.Instance.isPlaying = true;
    }
    void Update()
    {
        delayTimer += Time.deltaTime;

        if (delayTimer >= 3) //ī��Ʈ�ٿ� 3�ʰ� ������ Ÿ�̸Ӱ� �۵��ǵ���.
        {
            GameMng.Instance.time = Time.deltaTime;
            UIMng.Instance.update_time();
        }
        
    }
}

    

        