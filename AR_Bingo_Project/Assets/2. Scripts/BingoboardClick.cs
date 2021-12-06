using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BingoboardClick : MonoBehaviour
{
    private Button btn;

    private void Start()
    {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(Clicked);
    }
    
    public void Clicked()
    {
        if (this.gameObject.tag != "Clicked")
        {
            GameMng.instance.Add_bingo(this.transform.Find("Text").GetComponent<Text>().text);

        }
    }
}
