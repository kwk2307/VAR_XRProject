using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMng : Singleton<GameMng>
{
    //���� �Ÿ�
    public float currentdistance;
    public float goaldistance;
    public float currentspeed;
    //�÷��̾��� ���� �÷�
    public bool isPlaying = false;

    [SerializeField] private float currenttime;
    public int minutes;
    public int seconds;
    public int fraction;

    public float time
    {
        get
        {
            return currenttime;
        }
        set
        {
            currenttime += value;
            minutes = (int)Mathf.Floor(currenttime / 60); //Divide the guiTime by sixty to get the minutes.
            seconds = (int)currenttime % 60;//Use the euclidean division for the seconds.
            fraction = (int)(currenttime * 100) % 100;
        }
    }
    
}
