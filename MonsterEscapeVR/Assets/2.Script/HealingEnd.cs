using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingEnd : MonoBehaviour
{
    public GameObject endUI;
    
    public void EndUI()
    {
        endUI.SetActive(true);
    }
}
