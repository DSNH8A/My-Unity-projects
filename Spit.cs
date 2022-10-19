using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour
{
    private Player player;
    private float speed = 2;
    private Animator animator;
    private SpriteRenderer sRenderer;
  

    void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Player>();
        StartCoroutine(DestroyRoutine());
        sRenderer = GameObject.Find("Spider_Sprite").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.Damage();
            Destroy(this.gameObject);
        }

        if (other.tag == "FlameSword")
        {
            Debug.Log("Köpet!!");
            this.gameObject.SetActive(false);   
        }
    }
}
