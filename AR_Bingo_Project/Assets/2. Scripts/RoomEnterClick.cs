using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomEnterClick : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Room");
    }

}

