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

        if (delayTimer >= 3)  //카운트다운 3초가 끝나고 타이머가 작동되도록.
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

    

        