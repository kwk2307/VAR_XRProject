using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPointTrig : MonoBehaviour
{
    // 게임오버(성공) 부분 

    public GameObject gameWinUI;
    // 최고기록 확인 부분
    public string bestRecord;
    // 최고기록(분,초,밀리초) 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            GameMng.Instance.playerState = state.clear;
            UIMng.Instance.update_gameWinUI();
        }
    }
}
