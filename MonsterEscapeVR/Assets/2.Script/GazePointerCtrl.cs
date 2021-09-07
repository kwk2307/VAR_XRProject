using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazePointerCtrl : MonoBehaviour
{
    public Transform uiCanvas;
    public Image gazeImg;

    Vector3 defaultScale;
    public float uiScaleVal = 1f;

    bool isHitObj;
    GameObject prevHitObj;
    GameObject curHitObj;
    float curGazeTime = 0;
    public float gazeChargeTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        defaultScale = uiCanvas.localScale;
        curGazeTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = transform.TransformPoint(Vector3.forward);

        Ray ray = new Ray(transform.position, dir);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            uiCanvas.localScale = defaultScale * uiScaleVal * hitInfo.distance;
            uiCanvas.position = transform.forward * hitInfo.distance;
            if (hitInfo.transform.tag == "GazeObj")
            {
                isHitObj = true;
            }
            curHitObj = hitInfo.transform.gameObject;
        }

        else
        {
            uiCanvas.localScale = defaultScale * uiScaleVal;
            uiCanvas.position = transform.position + dir;
        }

        uiCanvas.forward = transform.forward * -1;

        if (isHitObj)
        {
            if (curHitObj == prevHitObj)
            {
                curGazeTime += Time.deltaTime;
            }
            else
            {
                prevHitObj = curHitObj;
            }
        }
        else
        {
            curGazeTime = 0;
            prevHitObj = null;
        }
        curGazeTime = Mathf.Clamp(curGazeTime, 0, gazeChargeTime);
        gazeImg.fillAmount = curGazeTime / gazeChargeTime;

        isHitObj = false;
        curHitObj = null;
    }
}
