using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearNum : MonoBehaviour
{

    [SerializeField] GameObject curWeighit;
    [SerializeField] GameObject goalWeight;
    [SerializeField] GameObject goalTerm;

    public void Click()
    {
        if (curWeighit.GetComponent<Toggle>().isOn == true)
        {
            curWeighit.transform.Find("num").GetComponent<Text>().text = null;
        }
        else if (goalWeight.GetComponent<Toggle>().isOn == true)
        {
            goalWeight.transform.Find("num").GetComponent<Text>().text = null;
        }
        else if (goalTerm.GetComponent<Toggle>().isOn == true)
        {
            goalTerm.transform.Find("num").GetComponent<Text>().text = null;
        }
        else
        {

        }
    }
}
