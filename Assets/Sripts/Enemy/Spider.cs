using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamagabale
    {
    //--INTERFACE--
    private bool damaged;
    public bool isdamaged { get; set; }
    public int Health { get; set; }
    public float dangerzone { get; set; }
    public bool playsound { get; set; }

    private const float yPos = 1.7f;
    private float currentPosition;
    //[SerializeField]
    //private GameObject spit;
    private bool canSpit;
    private float canspit;
    private float spitRate = 1f;
    private Player player;


    public override void Start()
    {
        currentPosition = transform.position.y;
        base.Start();   
        player = GameObject.Find("Player").GetComponent<Player>();
        if (currentPosition != yPos)
            {
            transform.position = new Vector3(transform.position.x, currentPosition, 0);
        }

        else 
        {
            transform.position = new Vector3(transform.position.x, yPos, 0);
        }
       
    }

    public override void Init()
    {
        base.Init();
        Health = 1;
    }

    public override void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            return;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            return;
        }
        base.Update();

        transform.position = new Vector3(transform.position.x, currentPosition, 0);
        if (base.distance < 2f && Time.time > canspit && base.isdead == false && transform.position.x != pointA.position.x && transform.position.x != pointB.position.x) 
        {
            canspit = Time.time + spitRate / 1f;
            Angle();
        }

       if (distance > 2f)
       {
            animator.SetTrigger("Walk");
       }
    }

    public override void Attack()
    {
        if (isdamaged == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        if (distance < 2f && player.turned == true)
        {
            Debug.Log("Attack");
            animator.SetTrigger("Attack");
        }

        else
        {
            animator.SetTrigger("Walk"); 
        }     
    }

    private void Angle()
    {

        if (player.transform.position.x < transform.position.x)
        {
            SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
            renderer.flipX = true;
        }

        if (player.transform.position.x > transform.position.x)
        {
            SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
            renderer.flipX = false;
        }
    }

}
