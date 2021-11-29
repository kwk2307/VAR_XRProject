using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocoEvent : MonoBehaviour
{
    public Animator ani;
    public GameObject sphere;
    public GameObject[] pos;
    public GameObject E;
    GameObject ob;
    void Start()
    {
        ani.SetBool("Stun", true);
        for (int i = 0; i < 3; i++)
        {
            ob = Instantiate(sphere, pos[i].transform.position, pos[i].transform.rotation) as GameObject;
            ob.transform.LookAt(E.transform);
            ob.transform.SetParent(GameObject.Find("Enemy").transform);
        }
        Destroy(GameObject.Find("Spear(Clone)"));
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
