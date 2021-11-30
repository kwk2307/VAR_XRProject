using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

            if (this.GetComponent<Slider>().value <= 1)
            {
                gazeDown = true;
            }
        }
        else
        {
            this.GetComponent<Slider>().value -= Time.deltaTime;
            if(this.GetComponent<Slider>().value == 0)
            {
                gazeDown = false;
            }
        }
    }
}
