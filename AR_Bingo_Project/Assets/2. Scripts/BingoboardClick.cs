using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BingoboardClick : MonoBehaviour
{
    public Image TestImage;
    public Sprite TestSprite;
    private Button btn;

    private void Start()
    {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(Clicked);    
    }
    
    public void Clicked()
    {
        TestImage.sprite = TestSprite;
        GameMng.instance.Add_bingo(this.transform.Find("Text").GetComponent<Text>().text);
        
        btn.onClick.RemoveAllListeners();
    }
}
