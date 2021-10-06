using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{

    [SerializeField] private GameObject slpash;
    //현재 프레임 
    private float pos;
    //이전 프레임
    private float pre_pos;

    private Vector3 tmp;

    // Start is called before the first frame update
    void Start()
    {
        pre_pos = transform.position.y;
        tmp = new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position.y;

        
        if (pre_pos > 0 ^ pos > 0)
        {
            Instantiate(slpash, transform.position + tmp , transform.rotation);
        }

        pre_pos = pos;
    }
}
