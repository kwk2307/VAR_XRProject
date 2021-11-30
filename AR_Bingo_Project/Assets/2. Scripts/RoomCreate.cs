using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RoomCreate : MonoBehaviour
{
    NetworkMng networkMng;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        networkMng = GameObject.Find("NetworkMng").GetComponent<NetworkMng>();
        
        btn.onClick.AddListener(()=> networkMng.JoinRoom(transform.Find("Name").GetComponent<Text>().text));        
    }

    public void JoinedRoom()
    {
       
    }
}
