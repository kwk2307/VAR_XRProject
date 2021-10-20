using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuButtonSetting : MonoBehaviour
{
    [SerializeField] Button mode1;
    [SerializeField] Button mode2;
    [SerializeField] Button mode3;

    [SerializeField] Button healing1;
    [SerializeField] Button healing2;
    [SerializeField] Button healing3;

    // Start is called before the first frame update
    void Start()
    {
        mode1.onClick.AddListener(SceneMng.Instance.GotoMode1);
        mode2.onClick.AddListener(SceneMng.Instance.GotoMode2);
        mode3.onClick.AddListener(SceneMng.Instance.GotoMode3);
        healing1.onClick.AddListener(SceneMng.Instance.GotoVenice);
        healing2.onClick.AddListener(SceneMng.Instance.GotoSouthPole);
        healing3.onClick.AddListener(SceneMng.Instance.GotoLake);
    }

}
