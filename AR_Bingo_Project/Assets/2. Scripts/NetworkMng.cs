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
    [SerializeField] public GameObject loginPanel;
    [SerializeField] public InputField playerName;

    [Header("Login_After")]
    [SerializeField] public GameObject login_After;
    [SerializeField] public GameObject quickStart;
    [SerializeField] public GameObject roomCreate;
    [SerializeField] public GameObject roomList;

    [Header("Login_Before")]
    [SerializeField] public GameObject login_Before;
    [SerializeField] public GameObject login;

    [Header("Room_Create")]
    [SerializeField] public GameObject roomCreatePanel;
    [SerializeField] public InputField roomName;
    [SerializeField] public InputField roomNum;

    [Header("Room_List")]
    [SerializeField] public GameObject roomListPanel;
    [SerializeField] public GameObject roomListPanel_content;
    [SerializeField] public GameObject roomInst;

    [Header("Room")]
    [SerializeField] public GameObject roomPanel;
    [SerializeField] public GameObject roomPanel_content;
    [SerializeField] public GameObject userInst;

    List<RoomInfo> myList = new List<RoomInfo>();

    #region UNITY
    public void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        playerName.text = "Player" + Random.Range(1000, 10000);

        roomName.text = "Room" + Random.Range(0, 100);
        roomNum.text = "4";
    }
    #endregion

    #region 서버연결
    public void Connect()
    {
        string playerName = this.playerName.text;

        if (!playerName.Equals(""))
        {
            PhotonNetwork.LocalPlayer.NickName = playerName;
            print("connect click");
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            Debug.LogError("Player Name is invalid.");
        }
    }
    public void CreateRoom()
    {
        if (!roomName.Equals(""))
        {
            if (!roomNum.Equals(""))
            {
                PhotonNetwork.CreateRoom(roomName.text, new RoomOptions { MaxPlayers = byte.Parse(roomNum.text)});
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
    private void MyRoomListRenewal()
    {
        var child = roomListPanel_content.GetComponentsInChildren<Transform>();

        foreach (var iter in child)
        {
            if (iter != roomListPanel_content.transform)
            {
                Destroy(iter.gameObject);
            }
        }

        for (int i = 0; i < myList.Count; ++i)
        {
            GameObject go = Instantiate(roomInst, roomListPanel_content.transform);
            go.transform.Find("Name").GetComponent<Text>().text = myList[i].Name;
            go.transform.Find("Number").GetComponent<Text>().text = myList[i].PlayerCount + "/" + myList[i].MaxPlayers;
        }
    }
    private void MyRoomRenawal()
    {
        var child = roomPanel_content.GetComponentsInChildren<Transform>();

        foreach (var iter in child)
        {
            if (iter != roomPanel_content.transform)
            {
                Destroy(iter.gameObject);
            }
        }

        foreach (var iter in PhotonNetwork.CurrentRoom.Players)
        {
            GameObject go = Instantiate(userInst, roomPanel_content.transform);
            go.transform.Find("Captain").gameObject.SetActive(iter.Value.IsMasterClient);
            go.transform.Find("Name").gameObject.GetComponent<Text>().text = iter.Value.NickName;
        }

        if (PhotonNetwork.IsMasterClient)
        {
            roomPanel.transform.Find("GameStart").gameObject.SetActive(true);
        }
    }
    public void GameStart()
    {
        PhotonNetwork.LoadLevel("GameScene");
    }
    public void JoinRandomRoom() => PhotonNetwork.JoinRandomRoom();

    public void RoomQuit() => PhotonNetwork.LeaveRoom();

    public void JoinRoom(string roomname) => PhotonNetwork.JoinRoom(roomname);
    
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
        login_After.SetActive(true);
        login_Before.SetActive(false);
        loginPanel.SetActive(false);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("OnDisconnected");
        login_After.SetActive(false);
        login_Before.SetActive(true);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        print("OnPlayerPropertiesUpdate" + targetPlayer.NickName + " " + changedProps["Level"]);
    }

    public override void OnCreatedRoom()
    {
        roomCreatePanel.SetActive(false);
    }

    public override void OnCreateRoomFailed(short returnCode, string message) 
    {
        Debug.LogError(message);
    }

    public override void OnJoinRandomFailed(short returnCode, string message) 
    {
        Debug.LogError(message);
    }

    public override void OnJoinedRoom()
    {
        print("OnJoinedRoom");

        MyRoomRenawal();
        roomListPanel.SetActive(false);
        roomPanel.SetActive(true);
        
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        MyRoomRenawal();
    }
    
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        MyRoomRenawal();
    }
    
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        int roomCount = roomList.Count;
        for (int i = 0; i < roomCount; i++)
        {
            if (!roomList[i].RemovedFromList)
            {
                if (!myList.Contains(roomList[i])) myList.Add(roomList[i]);
                else myList[myList.IndexOf(roomList[i])] = roomList[i];
            }
            else if (myList.IndexOf(roomList[i]) != -1) myList.RemoveAt(myList.IndexOf(roomList[i]));
        }

        MyRoomListRenewal();
    }
    
    #endregion
}
