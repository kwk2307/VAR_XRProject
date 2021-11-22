using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameMng : MonoBehaviourPunCallbacks
{
    public static GameMng instance = null;
   
    private PhotonView PV;
    public List<string> bingo = new List<string>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        PV = PhotonView.Get(this);
    }

   public void Add_bingo(string str)
    {
        PV.RPC("Bingo", RpcTarget.All, str);
    }

    [PunRPC]
    public void Bingo(string str)
    {
        bingo.Add(str);
    }
}
