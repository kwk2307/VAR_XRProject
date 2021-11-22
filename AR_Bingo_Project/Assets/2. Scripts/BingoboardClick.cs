using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BingoboardClick : MonoBehaviour
{
    public Image TestImage;
    public Sprite TestSprite;

    private void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(ChangeImage);
        btn.onClick.AddListener(updateGameMng);
    }

    public void ChangeImage()
    {
        TestImage.sprite = TestSprite;
    }

    public void updateGameMng() {
        GameMng.instance.Add_bingo(this.transform.Find("Text").GetComponent<Text>().text);
    }
    
}
