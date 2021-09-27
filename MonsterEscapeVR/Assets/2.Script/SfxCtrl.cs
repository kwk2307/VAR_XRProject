using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxCtrl : MonoBehaviour
{
    static AudioSource audioSource;
    public static AudioClip audioClip;

    private void OnCollisionEnter(Collision collision)
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.Play();
        //audioClip = Resources.Load<AudioClip>("속도를올리세요");
        //SoundPlay();
    }
    public void SoundPlay()
    {
        audioSource.PlayOneShot(audioClip);
    }
}