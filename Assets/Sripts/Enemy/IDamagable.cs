using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagabale
{
    int Health { get; set; }
    bool isdamaged { get; set; }
    float dangerzone { get; set; }  
    bool playsound { get; set; }

    void Damage();
}
