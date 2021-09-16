using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMng : MonoBehaviour
{
    
    public void GotoModeSelect()
    {
        StartCoroutine(LoadScene("ModeSelect"));
    }
    public void GotoRanking()
    {
        StartCoroutine(LoadScene("Ranking"));
    }
    public void GotoMode1()
    {
        StartCoroutine(LoadScene("Mode1"));
    }
    public void GotoMode2()
    {
        StartCoroutine(LoadScene("Mode2"));
    }
    public void GotoMode3()
    {
        StartCoroutine(LoadScene("Mode3"));
    }
    public void Gamerule()
    {
        StartCoroutine(LoadScene("Mode1"));
    }
    public void GoToMain()
    {
        StartCoroutine(LoadScene("MainMenu"));
    }

    IEnumerator LoadScene(string sceneName)
    {
        yield return null;
      
        AsyncOperation asyncOper = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncOper.isDone)
        {
            yield return null;
            Debug.Log(asyncOper.progress);
            //프로그레스 바 구현 할 수 있음
        }
    }

}
