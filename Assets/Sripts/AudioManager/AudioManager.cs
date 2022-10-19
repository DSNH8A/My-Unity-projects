using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;   
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("Audio Manager is Null");   
            }
            return instance;
        }
    }

    public AudioClip diamondSound;
    public AudioClip swordCut;
    public AudioClip flameSword;

    //--SKELETON--
    public AudioClip skeletonDeath;
    public AudioClip skeletonAttack;
    public AudioClip skeletonFootStep;
    public AudioClip skeletonBreak;

    //--MOSSGIANT--
    public AudioClip mossgiantStep;
    public AudioClip mossgiantAttack;
    public AudioClip mossgiantHit;
    public AudioClip mossgiantDeath;

    //--SPIDER--
    public AudioClip spiderStep;
    public AudioClip spiderAttack;
    public AudioClip spiderHit;
    public AudioClip spiderDeath;
    public AudioClip spiderIdle;

    void Awake()
    {
        instance = this;   
    }
}
