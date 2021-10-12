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
        //집합에 몇개가 할당되어 있는지 알아내기
        array = enviroment.Length;

        envir = Instantiate(enviroment[UnityEngine.Random.Range(0, array)]);
        envir.transform.position = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
