using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class MainPanel : MonoBehaviourPunCallbacks
{

    public InputField RoomNameInputField;
    public InputField MaxPlayersInputField;

    public void OnCreateRoomButtonClicked()
    {
        string roomName = RoomNameInputField.text;
        roomName = (roomName.Equals(string.Empty)) ? "Room " + Random.Range(1000, 10000) : roomName;

        byte maxPlayers;
        byte.TryParse(MaxPlayersInputField.text, out maxPlayers);
        maxPlayers = (byte)Mathf.Clamp(maxPlayers, 2, 8);

        RoomOptions options = new RoomOptions { MaxPlayers = maxPlayers, PlayerTtl = 10000 };

        PhotonNetwork.CreateRoom(roomName, options, null);
    }

    public void RoomList()
    {
        PhotonNetwork.JoinLobby();
        PhotonNetwork.LoadLevel("RoomList");
    }


    #region CALLBACK

    //����� ����
    public override void OnCreatedRoom()
    {
        print("OnCreatedRoom");
    }

    //����� ����
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("OnCreatedRoomFailed" + returnCode + "" + message);

    }

    //�뿡 ������
    public override void OnJoinedRoom()
    {
        print("OnJoinedRoom");
        PhotonNetwork.LoadLevel("Room");
    }

    //�� ���� ����
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("OnJoinedRoomFailed" + returnCode + "" + message);
    }

    //�� �������� ����
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("OnJoinedRandomFailed" + returnCode + "" + message);
    }

    //�뿡�� ��������
    public override void OnLeftRoom()
    {
        print("OnLeftRoom");

    }

    //�ٸ� �÷��̾ �濡 ��������
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        print("OnPlayerEnteredRoom" + newPlayer.NickName);

    }

    //�ٸ� �÷��̾ �濡�� �������� 
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        print("OnPlayerLeftRoom" + otherPlayer.NickName);
    }


    //�κ� ��������
    public override void OnJoinedLobby()
    {
        print("OnJoinedLobby");
    }


    //�κ񿡼� ������ ��
    public override void OnLeftLobby()
    {
        print("OnLeftLobby");

    }

    //�� �Ӽ� ����
    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
    {
        print("OnRoomPropertiesUpdate" + propertiesThatChanged["Map"]);

    }


    //�÷��̾� �Ӽ� ����
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        print("OnPlayerPropertiesUpdate" + targetPlayer.NickName + " " + changedProps["Level"]);
    }

    //������ �ٲ�����
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        print("OnmasterClientSwitched" + newMasterClient.NickName);
    }


    #endregion
}
