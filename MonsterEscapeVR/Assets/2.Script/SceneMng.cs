using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMng : MonoBehaviour
{
    Image fadeImage;
    float fadeCount =0;
    bool startFade = false;

    private void Start()
    {
        fadeImage = GameObject.Find("FadeImage").GetComponent<Image>();
        GoToMain();
    }
    

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
    public void ReGame()
    { 
        StartCoroutine(LoadScene("Mode1"));
    }
    public void GotoTutorial()
    {
        StartCoroutine(LoadScene("Tutorial"));
    }

    IEnumerator LoadScene(string sceneName)
    {
        yield return null;

        yield return new WaitForSeconds(2f); //화면 페이드 아웃될 여유시간

      
            AsyncOperation asyncOper = SceneManager.LoadSceneAsync(sceneName);
            while (!asyncOper.isDone)
            {
                yield return null;
                Debug.Log(asyncOper.progress);
                //프로그레스 바 구현 할 수 있음
            }

        
        
    }

}
