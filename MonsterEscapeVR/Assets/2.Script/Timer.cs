using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    private float delayTimer = 0;
    private bool chk = false;
    
    void Update()
    {

        delayTimer += Time.deltaTime;

        if (delayTimer >= 3)  //ī��Ʈ�ٿ� 3�ʰ� ������ Ÿ�̸Ӱ� �۵��ǵ���.
        {   
            if(chk == false)
            {
                GameMng.Instance.isPlaying = true;
                chk = true;
                print(GameMng.Instance.isPlaying);
            }
            if(GameMng.Instance.isPlaying == true)
            {
                GameMng.Instance.time = Time.deltaTime;
                UIMng.Instance.update_time();
            }
        }
    }
}

    

        