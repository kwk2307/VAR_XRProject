using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomExit : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
