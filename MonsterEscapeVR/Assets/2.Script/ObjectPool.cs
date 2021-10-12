using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public int poolSize = 10;
    GameObject[] envirObjectPool;
    void Start()
    {
        //환경 오브젝트들을 담을 수 있는 크기로 만들어준다.
        envirObjectPool = new GameObject[poolSize];
        //오브젝트 갯수만큼 반복

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
