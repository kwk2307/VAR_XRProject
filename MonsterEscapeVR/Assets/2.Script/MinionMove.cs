using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MinionMove : MonoBehaviour
{
     Transform Target;
    float time;
    float speed = 0.7f;
    Animator ani;


    void Start()
    {
        Target = GameObject.Find("Player").transform;
        ani = transform.GetComponent<Animator>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time < 0.5f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 20);
        }
        else 
        {
            //1초만에 무조건 플레이어에 닿음
            transform.position = Vector3.LerpUnclamped(transform.position, Target.transform.position, time / 10);
            //transform.position = Vector3.LerpUnclamped(transform.position, Target.transform.position, speed * Time.deltaTime);
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

    public IEnumerator DeadMinion()
    {
        //죽는 애니 재생
        if (SceneManager.GetActiveScene().name == "Mode1")
        {
            ani.SetBool("Hit", true);

            speed = 0;

            transform.Find("spear").gameObject.SetActive(true);

            yield return new WaitForSeconds(3f);
        }else if (SceneManager.GetActiveScene().name == "Mode2")
        {

        }
        else if (SceneManager.GetActiveScene().name == "Mode3")
        {


        }
        
        //3초뒤에 제거
        Destroy(transform.gameObject);
    }
}
