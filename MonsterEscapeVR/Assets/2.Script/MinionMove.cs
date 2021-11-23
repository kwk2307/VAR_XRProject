using UnityEngine;
using System.Collections;

public class MinionMove : MonoBehaviour
{
     Transform Target;
    float time;



    void Start()
    {
        Target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time < 0.5f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 20);
        }
        else //1.5초 이후 타겟으로 간다
        {
            transform.position = Vector3.LerpUnclamped(transform.position, Target.transform.position, Time.deltaTime*.8f);

            
        }
        //플레이어를 바라보기
        Vector3 directionVec = Target.position - this.transform.position;
        Quaternion qua = Quaternion.LookRotation(directionVec);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, qua, Time.deltaTime*2f);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") //플레이어와 충돌할 경우
        {
            //스피드를 깍는다
            other.transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 5000) * Time.deltaTime);

            Destroy(this.gameObject);
        }
    }
}
