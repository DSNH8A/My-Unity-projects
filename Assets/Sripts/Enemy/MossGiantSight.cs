using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiantSight : Enemy, IDamagabale
{
    public int Health { get; set; }
    public bool isdamaged { get; set; }
    public float dangerzone { get; set; }
    public bool playsound { get; set; }

    public override void Init()
    {
        base.Init();
 
    }

    void Damage()
    { 
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            base.Attack();
        }
    }
}
