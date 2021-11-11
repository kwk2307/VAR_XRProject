using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastRowing : MonoBehaviour
{
    [SerializeField] private GameObject tracker1;
    [SerializeField] private GameObject tracker2;

    public float trackerDistance;
    public float pretrackerDistance;

    public float gaze;
    Vector3 forward;
    LayerMask layerMask;
    RaycastHit hit;//������Ʈ ����
    private void Start()
    {
        pretrackerDistance = 1;
        forward = transform.TransformDirection(Vector3.forward);//����
        //UI���̾ �ɸ�
        layerMask = 1 << LayerMask.NameToLayer("UI");
    }

    // Update is called once per frame
    void Update()
    {
        trackerDistance = Vector3.Distance(tracker1.transform.position, tracker2.transform.position);

        if (pretrackerDistance < trackerDistance)
        {
            gaze += trackerDistance - pretrackerDistance;
        }
        else if (gaze > 0)
        {
            gaze -= Time.deltaTime;
        }


        if (Physics.Raycast(this.transform.position, forward, out hit, Mathf.Infinity, layerMask))
        {
           

            if (gaze > 1)
            {
                if (hit.transform.GetComponent<Button>() != null)
                {
                    //��ư onClick �̺�Ʈ �߻�
                    hit.transform.GetComponent<Button>().onClick.Invoke();

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
