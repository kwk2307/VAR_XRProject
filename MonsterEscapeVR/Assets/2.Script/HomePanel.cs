using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePanel : MonoBehaviour
{
    public void Click()
    {
        print("Aaa");
        UIMng.Instance.update_gameEnd();
    }
}
