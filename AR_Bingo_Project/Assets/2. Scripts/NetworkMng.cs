using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class NetworkMng : MonoBehaviourPunCallbacks
{
    [Header("Login")]
    [SerializeField] public GameObject LoginPanel;
    [SerializeField] public InputField PlayerName;

    [Header("Login_After")]
    [SerializeField] public GameObject Login_After;
    [SerializeField] public GameObject QuickStart;
    [SerializeField] public GameObject RoomCreate;
    [SerializeField] public GameObject RoomList;

    [Header("Login_Before")]
    [SerializeField] public GameObject Login_Before;
    [SerializeField] public GameObject Login;

    [Header("Room_Create")]
    [SerializeField] public GameObject RoomCreatePanel;
    [SerializeField] public InputField RoomName;
    [SerializeField] public InputField RoomNum;

    [Header("Room_List")]
    [SerializeField] public GameObject RoomListPanel;


    #region UNITY
    public void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PlayerName.text = "Player" + Random.Range(1000, 10000);
        RoomName.text = "Room" + Random.Range(0, 100);
    }
    #endregion

    #region 서버연결
    public void Connect()
    {
        string playerName = PlayerName.text;

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

    public void CreateRoom()
    {
        if (!RoomName.Equals(""))
        {
            if (RoomNum.Equals(""))
            {
                PhotonNetwork.CreateRoom(RoomName.text, new RoomOptions { MaxPlayers = byte.Parse(RoomNum.text)});
            }
            else
            {
                Debug.LogError("Room Num is invalid.");
            }
        }
        else
        {
            Debug.LogError("Room Name is invalid.");
        }
     
    }

    #endregion

    #region CALLBACK
    //네임서버 연결 성공
    public override void OnConnected()
    {
        print("OnConnected");
    }

    //마스터서버 연결 성공
    public override void OnConnectedToMaster()
    {
        print("OnConnectedToMaster");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Login_After.SetActive(true);
        Login_Before.SetActive(false);
        LoginPanel.SetActive(false);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("OnDisconnected");
        Login_After.SetActive(false);
        Login_Before.SetActive(true);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        print("OnPlayerPropertiesUpdate" + targetPlayer.NickName + " " + changedProps["Level"]);
    }
    #endregion

    public override void OnCreatedRoom()
    {
        RoomCreatePanel.SetActive(false);
    }

    public override void OnCreateRoomFailed(short returnCode, string message) 
    {
        Debug.LogError(message);
    }

    public override void OnJoinRandomFailed(short returnCode, string message) 
    {
        Debug.LogError(message);
    }
}
