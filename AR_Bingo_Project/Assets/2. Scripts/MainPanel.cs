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

    //룸생성 성공
    public override void OnCreatedRoom()
    {
        print("OnCreatedRoom");
    }

    //룸생성 실패
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("OnCreatedRoomFailed" + returnCode + "" + message);

    }

    //룸에 들어갔을때
    public override void OnJoinedRoom()
    {
        print("OnJoinedRoom");
        PhotonNetwork.LoadLevel("Room");
    }

    //룸 조인 실패
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("OnJoinedRoomFailed" + returnCode + "" + message);
    }

    //룸 렌덤조인 실패
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("OnJoinedRandomFailed" + returnCode + "" + message);
    }

    //룸에서 나갔을때
    public override void OnLeftRoom()
    {
        print("OnLeftRoom");

    }

    //다른 플레이어가 방에 들어왔을때
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        print("OnPlayerEnteredRoom" + newPlayer.NickName);

    }

    //다른 플레이어가 방에서 나갔을때 
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        print("OnPlayerLeftRoom" + otherPlayer.NickName);
    }


    //로비에 들어왔을때
    public override void OnJoinedLobby()
    {
        print("OnJoinedLobby");
    }


    //로비에서 나갔을 때
    public override void OnLeftLobby()
    {
        print("OnLeftLobby");

    }

    //룸 속성 변경
    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
    {
        print("OnRoomPropertiesUpdate" + propertiesThatChanged["Map"]);

    }


    //플레이어 속성 변경
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        print("OnPlayerPropertiesUpdate" + targetPlayer.NickName + " " + changedProps["Level"]);
    }

    //방장이 바꼈을때
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        print("OnmasterClientSwitched" + newMasterClient.NickName);
    }


    #endregion
}
