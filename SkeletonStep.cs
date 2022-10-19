using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStep : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip skeletonBreak;

    void Init()
    {
    }

    public void FootStep()
    {
        audio.Play();
    }

    public void HitSound()
    {
        audio.PlayOneShot(skeletonBreak);   
    }

    public void AttackSound()
    {
        audio.PlayOneShot(AudioManager.Instance.skeletonAttack);   
    }
}
