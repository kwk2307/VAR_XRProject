using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    Text text;
    float time;
    public GameObject WarnUp;//워밍업 영상
    public VideoPlayer WarmUpVideo;
    public GameObject rowing; //로잉영상
    public VideoPlayer rowingPlayer;
    public GameObject panel; // 패널

    [SerializeField] private Animator anim_boat;
    float waitTime;

    bool startRowing = false;
    bool cancelRowing = false;
    GameObject sideCam;

    AudioSource clear;
    public GameObject[] announce;

    public GameObject[] Enemy;
    public GameObject[] angry;

    public GameObject cross;


    void Start()
    {
        text= GameObject.Find("Text").GetComponent<Text>();
        WarmUpVideo.Stop();
        rowingPlayer.Stop();
       

        StartCoroutine("Greet");

        sideCam = GameObject.Find("SideView");
        sideCam.SetActive(false);

        clear = GameObject.Find("ClearSound").GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        

        if (startRowing == true)
        {
            if (anim_boat.GetFloat("Position") >= 0.8f)
            {
                clear.Play();
                text.text = "잘 하셨습니다.  다시 앞으로 가보겠습니다.";
                announce[3].SetActive(true);
                cancelRowing = true;
                startRowing = false;
                
            }
            
        }
        if(cancelRowing == true)
        {
            //앞으로 놓으면
            if (anim_boat.GetFloat("Position") <= 0.2f)
            {
                clear.Play();
                text.text = "잘 하셨습니다.";
                announce[4].SetActive(true);
                cancelRowing = false;
                sideCam.SetActive(false);
                StartCoroutine(EnemySay());
            }


        }


    }
    IEnumerator Greet()
    {
        text.text = "Monster Eescape에 오신 것을 환영합니다";
        yield return new WaitForSeconds(3);
        text.text = "이제부터 간단한 준비운동을 시작하겠습니다";
        yield return new WaitForSeconds(4.5f);
        text.text = "안전을 위해 로잉머신에 앉은채로 따라해주세요";
        yield return new WaitForSeconds(7f);
        panel.SetActive(false);
        WarnUp.SetActive(true);
        WarmUpVideo.Play();
        yield return new WaitForSeconds((float)(WarmUpVideo.length)); //동영상 길이만큼 기다린다.
        
            WarnUp.SetActive(false);
            StartCoroutine(GuideRowing());
        

    }
    IEnumerator GuideRowing()
    {
        yield return new WaitForSeconds(1f);
        panel.SetActive(true);
        text.text = "본격적으로 로잉머신의 사용법을 배워보겠습니다";
        announce[0].SetActive(true);
        yield return new WaitForSeconds(5);
        //로잉머신 동영상 재생
        panel.SetActive(false);
        rowing.SetActive(true);
        rowingPlayer.Play();
        yield return new WaitForSeconds((float)(rowingPlayer.length)); //동영상 길이만큼 기다린다.
        rowing.SetActive(false);
        panel.SetActive(true);

        text.text = "이제 직접 해보겠습니다";
        announce[1].SetActive(true);
        sideCam.SetActive(true);
        yield return new WaitForSeconds(3);
        text.text = "당겨보세요";
        announce[2].SetActive(true);
        startRowing = true;

    }
    IEnumerator EnemySay()
    {
        yield return new WaitForSeconds(1);
        text.text = "이제 적에 대해 알려드리겠습니다.";
        announce[5].SetActive(true);
        yield return new WaitForSeconds(5);

        text.text = "적은 모드에 따라 악어, 상어, 크라켄이 있습니다.";
        announce[6].SetActive(true);

        yield return new WaitForSeconds(1.2f);

        Instantiate(Enemy[0]);
        Enemy[0].transform.position = new Vector3(-10, -0.8f, 23);
        angry[0] = GameObject.Find("Angry");
        GameObject.Find("Angry").SetActive(false);

yield return new WaitForSeconds(1.1f);

        Instantiate(Enemy[1]);
        Enemy[1].transform.position = new Vector3(0, -2.36f, 30);
        angry[1] = GameObject.Find("Angry");
        GameObject.Find("Angry").SetActive(false);

        yield return new WaitForSeconds(1f);

        Instantiate(Enemy[2]);
        Enemy[2].transform.position = new Vector3(10, -3f, 30);
        angry[2] = GameObject.Find("Angry");
        GameObject.Find("Angry").SetActive(false);
        print("크라켄 생성 " + Enemy[2].transform.position);


        yield return new WaitForSeconds(5);
        text.text = "당신은 이 괴물들에게서 노를 저어 도망쳐야 합니다.";
        announce[7].SetActive(true);
        yield return new WaitForSeconds(5);
        StartCoroutine(GuideAngry());

    }

    IEnumerator GuideAngry()
    {
        text.text = "적은 랜덤하게 분노모드로 들어갑니다.";
        announce[8].SetActive(true);
        yield return new WaitForSeconds(5);
        text.text = "분노모드에 들어간 적은 속도가 빨라지니 조심하세요!";
        announce[9].SetActive(true);
        yield return new WaitForSeconds(5);
        text.text = "적 위에 생긴 빨간색 느낌표를 통해 적이 분노모드임을 알 수 있습니다.";
        announce[10].SetActive(true);
        for (int i= 0; i< 3; i++)
        {
            angry[i].SetActive(true);
        }
        yield return new WaitForSeconds(7);
        text.text = "이 때 적은 미니언을 만들어냅니다.";
        announce[15].SetActive(true);
        yield return new WaitForSeconds(4);
        text.text = "화면 중앙에 생기는 조준점으로 응시하면 물리칠 수 있습니다.";
        announce[16].SetActive(true);
        cross.SetActive(true);
        yield return new WaitForSeconds(7);
        StartCoroutine(QuitTuto());

    }

    IEnumerator QuitTuto()
    {
        text.text = "괴물들에게서 쫓기는 긴박함이 싫으신 분들을 위한 관광모드도 있습니다.";
        announce[11].SetActive(true);
        yield return new WaitForSeconds(6);
        text.text = "관광모드 또한 메인화면에서 선택하여 들어가실 수 있습니다";
        announce[12].SetActive(true);
        yield return new WaitForSeconds(5);
        text.text = "이것으로 튜토리얼을 마치겠습니다.";
        announce[13].SetActive(true);
        yield return new WaitForSeconds(5);
        text.text = "부디 생존하시길 빕니다.";
        announce[14].SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMenu");

    }
}
