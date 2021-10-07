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

        if (delayTimer >= 3) //카운트다운 3초가 끝나고 타이머가 작동되도록.
        {
            GameMng.Instance.time = Time.deltaTime;
            UIMng.Instance.update_time();
        }
        
    }
}

    

        