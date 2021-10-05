using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] float setTime = 3.0f;
    [SerializeField] Text countdownText;
    public GameObject timer;
    public float destroyCount;
    void Start()
    {
        countdownText.text = setTime.ToString();
    }
    void Update()
    {



        setTime -= Time.deltaTime;

        countdownText.text = Mathf.Round(setTime).ToString();
        if (countdownText.text == "0")
        {
            countdownText.text = "1";
        }

        if (setTime <= 0.1f)
        {
            countdownText.text = "����!";
            //Destroy(timer, 1.0f);
        }
        if (setTime <= -1)
        {
            Destroy(gameObject);
        }





    }
}