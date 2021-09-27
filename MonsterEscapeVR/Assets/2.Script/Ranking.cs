using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ranking : MonoBehaviour
{
    public Text[] Rank=new Text[10]; // 10위까지 랭킹텍스트
    public string temp;
    SpectatorViewUI1 rankingSV= GameObject.Find("Spectator_Canvas").GetComponent<SpectatorViewUI1>();
    void Start()
    {
        // 랭킹 1~10위까지 출력
        RankingPrint();
    }

   
    void Update()
    {
        // 랭킹 알고리즘 연산
        // 1. SpectatorViewUI1 스크립트에서 출력된 최고기록을 Rank[0]에 넣어준다.
        // 2. 만약, 새로 나온 기록이 기존에 존재하는 Rank[0] 기록보다 최단 기록인경우 서로 스왑한다.
        // temp에 기존의 최고기록 Rank[0] 저장 , Rank[1]엔 새로운 기록 저장하여 스왑

    
    }

    void RankingPrint()
    {
        for (int i = 0; i < 10; i++)
        {

            Rank[i].text = rankingSV.rankMinute[i] + ":" + rankingSV.rankSecond[i] + ":" + rankingSV.rankMilli[i];


        }

    }
       
    }

