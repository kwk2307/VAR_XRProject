using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ranking : MonoBehaviour
{
    public Text[] Rank=new Text[10]; // 10������ ��ŷ�ؽ�Ʈ
    public string temp;
    SpectatorViewUI1 rankingSV= GameObject.Find("Spectator_Canvas").GetComponent<SpectatorViewUI1>();
    void Start()
    {
        // ��ŷ 1~10������ ���
        RankingPrint();
    }

   
    void Update()
    {
        // ��ŷ �˰��� ����
        // 1. SpectatorViewUI1 ��ũ��Ʈ���� ��µ� �ְ����� Rank[0]�� �־��ش�.
        // 2. ����, ���� ���� ����� ������ �����ϴ� Rank[0] ��Ϻ��� �ִ� ����ΰ�� ���� �����Ѵ�.
        // temp�� ������ �ְ��� Rank[0] ���� , Rank[1]�� ���ο� ��� �����Ͽ� ����

    
    }

    void RankingPrint()
    {
        for (int i = 0; i < 10; i++)
        {

            Rank[i].text = rankingSV.rankMinute[i] + ":" + rankingSV.rankSecond[i] + ":" + rankingSV.rankMilli[i];


        }

    }
       
    }

