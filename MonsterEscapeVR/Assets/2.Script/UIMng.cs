using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMng : Singleton<UIMng>
{
    [SerializeField] private Text ui_distance;
    [SerializeField] private Text ui_speed;
    [SerializeField] private Text ui_time;
    [SerializeField] private Slider progress;

    public void update_distance()
    {
        ui_distance.text = GameMng.Instance.currentdistance + "M / 50M";
        if(progress != null)
        {
            progress.value = (50 - GameMng.Instance.currentdistance) / 50;
        }
    }
    public void update_speed()
    {
        ui_speed.text = string.Format("{0:00} k/s", GameMng.Instance.currentspeed);
    }
    public void update_time()
    {
        ui_time.text = string.Format("{0:00} : {1:00} : {2:00}",
             GameMng.Instance.minutes, GameMng.Instance.seconds, GameMng.Instance.fraction);
    }
    

}

