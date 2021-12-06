using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameMng : MonoBehaviourPunCallbacks
{
    public static GameMng instance = null;

    private PhotonView PV;
    public List<string> bingo = new List<string>();

    public int currnet;
    public int turn = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        
        for(int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            if (PhotonNetwork.PlayerList[i] == PhotonNetwork.LocalPlayer)
            {
                currnet = i;
            }
        }

        foreach(var i in PhotonNetwork.PlayerList)
        {
            print(i);
        }

        PV = PhotonView.Get(this);
    }

    public void Add_bingo(string str)
    {
        if (currnet == turn)
        PV.RPC("Bingo", RpcTarget.All, str);
    }

    [PunRPC]
    public void Bingo(string str)
    {

        bingo.Add(str);

        RenewalBingoBoard(bingo);

        Chk_bingo();


        {
            turn++;
            if (turn == PhotonNetwork.PlayerList.Length)
            {
                turn = 0;
            }
        }
    }

    public void Bingo_clicked()
    {
        PV.RPC("Bingo_click", RpcTarget.All);
        
       
    }

    [PunRPC]
    public void Bingo_click()
    {
        GameObject Win = GameObject.Find("Canvas").transform.Find("Win").gameObject;
        Win.SetActive(true);
    }

    public void RenewalBingoBoard(List<string> bingo)
    {
        Text[] bingoBoard = GameObject.Find("Bingoboard").GetComponentsInChildren<Text>();

        foreach (var i in bingo)
        {
            foreach (var j in bingoBoard)
            {
                if (j.text == i)
                {
                    j.transform.parent.GetComponent<Image>().sprite = Resources.Load<Sprite>("circle_2");
                    j.transform.parent.gameObject.tag = "Clicked";
                    break;
                }
            }

        }
    }

    public void Chk_bingo()
    {
        Text[] bingoBoard = GameObject.Find("Bingoboard").GetComponentsInChildren<Text>();
        GameObject bingo_button = GameObject.Find("Canvas").transform.Find("BingoButton").gameObject;

        int tmp;

        int cnt1 = 0;
        for (int i = 0; i < 4; i++)
        {
            int cnt2 = cnt1;
            tmp = 0;
            for (int j = 0; j < 4; j++)
            {
                if(bingoBoard[cnt2].transform.parent.gameObject.tag == "Clicked")
                {
                    tmp++;
                }
                cnt2 += 1;
            }

            if(tmp == 4)
            {
                bingo_button.SetActive(true);
            }

            cnt1 += 4;
        }

        cnt1 = 0;
        for (int i = 0; i < 4; i++)
        {
            int cnt2 = cnt1;
            tmp = 0;
            for (int j = 0; j < 4; j++)
            {
                if (bingoBoard[cnt2].transform.parent.gameObject.tag == "Clicked")
                {
                    tmp++;
                }
                cnt2 += 4;
            }

            if (tmp == 4)
            {
                bingo_button.SetActive(true);
            }

            cnt1 += 1;
        }

        cnt1 = 0;
        tmp = 0;
        for (int j = 0; j < 4; j++)
        {
            if (bingoBoard[cnt1].transform.parent.gameObject.tag == "Clicked")
            {
                tmp++;
            }

            if (tmp == 4)
            {
                bingo_button.SetActive(true);
            }
            cnt1 += 5;
        }

        cnt1 = 3;
        tmp = 0;
        for (int j = 0; j < 4; j++)
        {
        
            if (bingoBoard[cnt1].transform.parent.gameObject.tag == "Clicked")
            {
                tmp++;
            }

            if (tmp == 4)
            {
                bingo_button.SetActive(true);
            }
            cnt1 += 3;
        }

        print("bingochk");
    }
    public void GameOver()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("MainMenu");
    }

}
