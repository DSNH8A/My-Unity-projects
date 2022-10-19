using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   private static GameManager instance;
    public static GameManager Instance
    {
        get 
        {
            if (instance == null)
            {
                Debug.Log("Error");
            }
            return instance;   
        }
    }

    public bool HasKeyToCastle { get; set; }
    public bool hasFlameSword { get; set; }
    public bool hasBoots { get; set; }

    private void Awake()
    { 
        instance = this;
    }
}
