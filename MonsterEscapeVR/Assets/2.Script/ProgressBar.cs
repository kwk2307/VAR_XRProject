using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Text ProgressIndicator;
    public Image LoadingBar;
    float currentValue;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentValue < 3)
        {
            currentValue += speed * Time.deltaTime;
        }
        else
        {
            ProgressIndicator.text = "";
        }

        LoadingBar.fillAmount = currentValue / 3;
    }
}