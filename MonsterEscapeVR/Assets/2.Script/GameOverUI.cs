using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverUI : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.name == "GameOverUI_Win")
        {
            Button btn = transform.GetComponent<Button>();
            btn.onClick.AddListener(SceneMng.Instance.GoToMain);
        }
        if (this.gameObject.name == "GameOverUI_Fail ")
        {
            Button btn = transform.GetComponent<Button>();
            btn.onClick.AddListener(SceneMng.Instance.GoToMain);
        }
    }

    
}
