using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    private float delayTimer = 0;
    
    void Update()
    {
        if (GameMng.Instance.playerState == state.playing)
        {
            delayTimer += Time.deltaTime;
            GameMng.Instance.time = Time.deltaTime;
            UIMng.Instance.update_time();
        }
    }
}

    

        