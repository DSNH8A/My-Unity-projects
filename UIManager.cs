using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] lives = new GameObject[3];
    private Player player;
    private GameObject currentLife;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
       
    }

   public  void Damage(int leves)
   {
        lives[leves].SetActive(false);
   }
}
