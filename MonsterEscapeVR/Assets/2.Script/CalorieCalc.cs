using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Ȱ����? 

public class CalorieCalc : MonoBehaviour
{
    int weight;
    int target_weight;
    int date;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public float CalcCal()
    {
        //��ǥ����
        float cal = (target_weight - weight) * 5 / date / 1.512f;

        return cal;
    }
}
