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
            GameMng.Instance.CalcKcal();
            GameMng.Instance.playerState = state.clear;

            UIMng.Instance.update_gameWinUI();
            UIMng.Instance.update_gazePointer();
        }
    }

    IEnumerator ObjectCulling(GameObject go)
    {
        
        yield return null;
    }
}
