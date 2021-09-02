using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomListClick : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("RoomList");
    }

}
