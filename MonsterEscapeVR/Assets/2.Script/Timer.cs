using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Text timerLabel;
    public float delayTimer = 0;

    private float time;

    void Update()
    {
        delayTimer += Time.deltaTime;
        if(delayTimer >= 3) //카운트다운 3초가 끝나고 타이머가 작동되도록.
        {
            time += Time.deltaTime;

            var minutes = (int)Mathf.Floor(time / 60); //Divide the guiTime by sixty to get the minutes.
            var seconds = time % 60;//Use the euclidean division for the seconds.
            var fraction = (time * 100) % 100;
            print(fraction);


            timerLabel.text = string.Format("{0:00} : {1:00} : {2:00}", minutes, seconds, fraction);

        }
        
    }
}

    

        