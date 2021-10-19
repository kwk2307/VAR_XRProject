using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KiloSetting : MonoBehaviour
{
    public Text curweightText;
    public Text goalWeightText;
    public Text goalTermNumText;

    public Button curUp;
    public Button curDown;
    public Button goalUp;
    public Button goalDown;
    public Button goalTermUp;
    public Button goalTermDown;

    public Button Exit;
    public Button Apply;
    int curweight;
    int goalweight;
    int goalTerm;
    void Start()
    {
        curUp.onClick.AddListener(CurweightUp);
        curDown.onClick.AddListener(CurweightDown);

        goalUp.onClick.AddListener(GoalweightUp);
        goalUp.onClick.AddListener(GoalweightDown);

        goalTermUp.onClick.AddListener(GoalTermUp);
        goalTermDown.onClick.AddListener(GoalTermDown);

        Exit.onClick.AddListener(Exitscreen);
        Apply.onClick.AddListener(UpdateUser);
    }

    
    public void CurweightUp()
    {
        curweight += 5;
        curweightText.text = curweight + "kg";
    }
    public void CurweightDown()
    {
        curweight -= 5;
        curweightText.text = curweight + "kg";
    }
    public void GoalweightUp()
    {
        goalweight += 5;
        goalWeightText.text = goalweight + "kg";
    }
    public void GoalweightDown()
    {
        goalweight -= 5;
        goalWeightText.text = goalweight + "kg";
    }
    public void GoalTermUp()
    {
        goalTerm += 7;
       goalTermNumText.text = goalTerm + "kg";
    }
    public void GoalTermDown()
    {
        goalTerm -= 7;
        goalTermNumText.text = goalTerm + "kg";
    }
    public void Exitscreen()
    {
        this.gameObject.SetActive(false);
    }

    public void UpdateUser()
    {
        StartCoroutine(ServerConn.Instance.SendUpdateuser(curweightText.text, goalWeightText.text, goalTermNumText.text));
    }


}
