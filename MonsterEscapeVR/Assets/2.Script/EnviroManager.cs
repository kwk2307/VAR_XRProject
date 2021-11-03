using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroManager : MonoBehaviour
{
    public float distance = 110;
    public float delayTime = 0f;
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Enemy")
        {
            //애니메이터가 있다면
            /*if (other.gameObject.GetComponent<Animator>() != null)
            {
                //애니메이터 재생을 멈추고
                other.gameObject.GetComponent<Animator>().Rebind();
                other.gameObject.GetComponent<Animator>().Update(0f);
                print("애니메이터 재생 멈춤");
            }*/

            other.transform.position -= Vector3.forward * distance;
            Instantiate(other);
            Destroy(other.gameObject);

        }
    }

}
