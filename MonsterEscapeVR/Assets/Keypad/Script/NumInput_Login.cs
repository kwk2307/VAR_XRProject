using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumInput_Login : MonoBehaviour
{
    [SerializeField] GameObject userCode;
    public void Click()
    {
        userCode.transform.Find("num").GetComponent<Text>().text += this.transform.Find("Text").GetComponent<Text>().text;
    }
}
