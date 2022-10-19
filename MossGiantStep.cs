using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiantStep : MonoBehaviour
{
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void FootStep()
    {
        audio.PlayOneShot(AudioManager.Instance.mossgiantStep);   
    }

    public void Attack()
    {
        audio.PlayOneShot(AudioManager.Instance.mossgiantAttack);   
    }

    public void Hit()
    {
        audio.PlayOneShot(AudioManager.Instance.mossgiantHit);   
    }

    public void Death()
    {
        audio.PlayOneShot(AudioManager.Instance.mossgiantDeath);   
    }
}
