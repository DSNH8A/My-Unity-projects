using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderStep : MonoBehaviour
{
    private AudioSource audio;
    public GameObject spit;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Spit()
    {
        GameObject spitt = Instantiate(spit, transform.position, Quaternion.identity);       
    }

    public void SpiderAttack()
    {
        audio.PlayOneShot(AudioManager.Instance.spiderAttack);  
    }

    public void SpiderDeath()
    {
        audio.PlayOneShot(AudioManager.Instance.spiderDeath);   
    }

    public void SpiderIdle()
    {
        audio.PlayOneShot(AudioManager.Instance.spiderIdle);   
    }

    public void SpiderHit()
    {
        audio.PlayOneShot(AudioManager.Instance.spiderHit);   
    }
}
