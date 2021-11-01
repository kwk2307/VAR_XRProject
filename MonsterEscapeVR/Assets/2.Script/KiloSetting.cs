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
        curweightText.text = ServerConn.Instance.curWeight;
        goalWeightText.text = ServerConn.Instance.goalWeight;
        goalTermNumText.text = ServerConn.Instance.term;

        curweight = int.Parse(curweightText.text);
        goalweight = int.Parse(goalWeightText.text);
        goalTerm = int.Parse(goalTermNumText.text);

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

        curweight += 1;
        curweightText.text = curweight.ToString();
    }
    public void CurweightDown()
    {
        if(curweight>0) curweight -= 1;
        curweightText.text = curweight.ToString();
    }
    public void GoalweightUp()
    {
        goalweight += 1;
        goalWeightText.text = goalweight.ToString();
    }
    public void GoalweightDown()
    {
        if(goalweight>0) goalweight -= 1;
        goalWeightText.text = goalweight.ToString();
    }
    public void GoalTermUp()
    {
       goalTerm += 1;
       goalTermNumText.text = goalTerm.ToString();
    }
    public void GoalTermDown()
    {
        if(goalTerm>0) goalTerm -= 1;
        goalTermNumText.text = goalTerm.ToString();
    }
    public void Exitscreen()
    {
        this.gameObject.SetActive(false);
    }

    public void UpdateUser()
    {
        StartCoroutine(ServerConn.Instance.SendUpdateuser(curweightText.text, goalWeightText.text, goalTermNumText.text));
        this.gameObject.SetActive(false);
    }
}
