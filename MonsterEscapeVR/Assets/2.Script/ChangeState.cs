using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameMng.Instance.playerState = state.playing;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
