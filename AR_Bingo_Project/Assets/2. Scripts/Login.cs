using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Login : MonoBehaviourPunCallbacks
{

    [SerializeField] public InputField PlayerNameInput;
    #region UNITY
    public void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PlayerNameInput.text = "Player" + Random.Range(1000, 10000);
    }
    #endregion

    #region UI CALLBACK
    public void OnLoginButtonClicked()
    {
        string playerName = PlayerNameInput.text;

        if (!playerName.Equals(""))
        {
            PhotonNetwork.LocalPlayer.NickName = playerName;
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            Debug.LogError("Player Name is invalid.");
        }
    }
    #endregion

    #region CALLBACK
    //���Ӽ��� ���� ����
    public override void OnConnected()
    {
        print("OnConnected");
    }

    //�����ͼ��� ���� ����
    public override void OnConnectedToMaster()
    {
        print("OnConnectedToMaster");
        PhotonNetwork.LoadLevel("MainMenu"); // Scene �̵�
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("OnDisconnected");
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        print("OnPlayerPropertiesUpdate" + targetPlayer.NickName + " " + changedProps["Level"]);
    }
    #endregion
}
