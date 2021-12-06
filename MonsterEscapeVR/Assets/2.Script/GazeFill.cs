using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GazeFill : MonoBehaviour
{
    private bool gazeDown = false;
    private void Update()
    {
        if (!gazeDown)
        {
            if (this.GetComponent<Slider>().value < UIMng.Instance.gazevalue)
            {
                this.GetComponent<Slider>().value += Time.deltaTime;
            }

            if (this.GetComponent<Slider>().value >= 1)
            {
                gazeDown = true;
                //
                Transform enemymove = GameObject.Find("Enemy").transform;

                if (SceneManager.GetActiveScene().name == "Mode1")
                {
                    StartCoroutine(enemymove.GetComponent<EnemyMove>().CrocoEvent());
                }
                else if (SceneManager.GetActiveScene().name == "Mode2")
                {
                    StartCoroutine(enemymove.GetComponent<EnemyMove>().SharkEvent());
                }
                else if (SceneManager.GetActiveScene().name == "Mode3")
                {
                    StartCoroutine(enemymove.GetComponent<EnemyMove>().KrakenEvent());
                }
            }
        }
        else
        {
            this.GetComponent<Slider>().value -= Time.deltaTime;
            if (this.GetComponent<Slider>().value == 0)
            {
                gazeDown = false;
                UIMng.Instance.gazevalue = 0;
            }
        }
    }
}
