using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentFactory : MonoBehaviour
{
    public GameObject[] enviroment;
    GameObject envir;
    int array;
    void Start()
    {
        //���տ� ��� �Ҵ�Ǿ� �ִ��� �˾Ƴ���
        array = enviroment.Length;

        envir = Instantiate(enviroment[UnityEngine.Random.Range(0, array)]);
        envir.transform.position = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
