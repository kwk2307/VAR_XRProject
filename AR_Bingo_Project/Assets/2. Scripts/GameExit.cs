using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameExit : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
