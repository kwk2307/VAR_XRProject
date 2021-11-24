using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastRowing : MonoBehaviour
{
    [SerializeField] private GameObject tracker1;
    [SerializeField] private GameObject tracker2;
    [SerializeField] private Image Gazepointer;

    private float trackerDistance;
    private float pretrackerDistance;

    private float gaze;  

    private void Start()
    {
        pretrackerDistance = 1;
    }

    // Update is called once per frame
    void Update()
    {
        trackerDistance = Vector3.Distance(tracker1.transform.position, tracker2.transform.position);

        if (pretrackerDistance < trackerDistance && gaze < 1)
        {
            gaze += (trackerDistance - pretrackerDistance) * 1.5f;
        }
        else if (gaze > 0)
        {
            gaze -= Time.deltaTime;
        }

        //print(gaze);
        Gazepointer.fillAmount = gaze;
        RaycastHit hit;//오브젝트 정보

        Vector3 forward = transform.TransformDirection(Vector3.forward);//방향
        //UI레이어만 걸림
        LayerMask layerMask = 1 << LayerMask.NameToLayer("UI");

        if (Physics.Raycast(this.transform.position, forward, out hit, Mathf.Infinity, layerMask))
        {
            if (gaze > 1)
            {
                if (hit.transform.GetComponent<Button>() != null)
                {
                    //버튼 onClick 이벤트 발생
                    hit.transform.GetComponent<Button>().onClick.Invoke();

                    SoundMng.Instance.ToggleSound_s();

                }
                else if (hit.transform.GetComponent<Toggle>() != null)
                {
                    hit.transform.GetComponent<Toggle>().isOn = true;
                }
            }
        }       
        pretrackerDistance = trackerDistance;        
    }
}
