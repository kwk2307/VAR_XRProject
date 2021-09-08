using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTest : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = transform.GetComponent<Animator>();
    }

    private void Update()
    {
    
    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(0, 0, 100, 200),"aa"))
        {
            anim.Play("Unreal Take", -1, 0.2f);
        }
    }
}
