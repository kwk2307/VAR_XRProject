using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPointTrig : MonoBehaviour
{
    // ���ӿ���(����) �κ� 

    public GameObject gameWinUI;
    // �ְ��� Ȯ�� �κ�
    public string bestRecord;
    // �ְ���(��,��,�и���) 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            GameMng.Instance.playerState = state.clear;
            UIMng.Instance.update_gameWinUI();
        }
    }
}
