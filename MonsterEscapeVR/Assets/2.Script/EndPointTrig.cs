using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPointTrig : MonoBehaviour
{
    // ���ӿ���(����) �κ� 
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            GameMng.Instance.playerState = state.clear;
            UIMng.Instance.update_gameWinUI();
        }
    }
}
