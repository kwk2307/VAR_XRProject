using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public int poolSize = 10;
    GameObject[] envirObjectPool;
    void Start()
    {
        //ȯ�� ������Ʈ���� ���� �� �ִ� ũ��� ������ش�.
        envirObjectPool = new GameObject[poolSize];
        //������Ʈ ������ŭ �ݺ�

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
