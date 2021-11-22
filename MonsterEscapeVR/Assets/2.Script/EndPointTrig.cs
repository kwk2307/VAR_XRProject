using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPointTrig : MonoBehaviour
{
    // 게임오버(성공) 부분 
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            GameMng.Instance.CalcKcal();
            GameMng.Instance.playerState = state.clear;

            UIMng.Instance.update_gameWinUI();
            UIMng.Instance.update_gazePointer();

            SoundMng.Instance.GameWin_s();
        }
    }

    IEnumerator ObjectCulling(GameObject go)
    {
        
        yield return null;
    }
}
