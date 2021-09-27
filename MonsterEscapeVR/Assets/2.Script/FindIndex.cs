using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FindIndex : MonoBehaviour
{

    [SerializeField] private GameObject[] tracker;

    // Start is called before the first frame update
    void Start()
    {
        List<uint> index = new List<uint>();
        var error = ETrackedPropertyError.TrackedProp_Success;
        for (uint i = 0; i < 16; i++)
        {
            var result = new System.Text.StringBuilder((int)64);
            OpenVR.System.GetStringTrackedDeviceProperty(i, ETrackedDeviceProperty.Prop_RenderModelName_String, result, 64, ref error);
            if (result.ToString().Contains("tracker"))
            {
                index.Add(i);
            }
        }

        for (int i = 0; i < index.Count; i++)
        {
            tracker[i].GetComponent<SteamVR_TrackedObject>().index = (SteamVR_TrackedObject.EIndex)index[i];
        }

    }
}
