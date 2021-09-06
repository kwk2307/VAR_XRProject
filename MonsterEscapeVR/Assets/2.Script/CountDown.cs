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
        
        if (setTime >= 1)
        {

            setTime -= Time.deltaTime;

            countdownText.text = Mathf.Round(setTime).ToString();
            if (setTime < 1)
            {
                countdownText.text = "½ÃÀÛ!";
                Destroy(timer, 1.0f);
            }
            
        }
       






    }
}