using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    private int r;
    void Start()
    {


    }


    public void ButtonClick()
    {
        r = Random.Range(1, 17);

        Debug.Log(r);

        foreach (GameObject item in GameObject.Find("Bingoboard").GetComponent<Bingo>().dd)
        {
            if (r.ToString() == item.tag)
            {
                Debug.Log("print");

                item.GetComponentInParent<Image>().sprite = Resources.Load("circle_2", typeof(Sprite)) as Sprite;

  
            }
        }
    }

    // Update is called once per frame
    void Update()
    {



    }
}
