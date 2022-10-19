using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
    {
    [SerializeField]
    protected int speed = 1;
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;
    [SerializeField]
    protected GameObject diamond1;
    protected Vector3 target;
    public bool isdead;
    protected bool isdamaged;
    protected bool on = true;
    protected Animator animator;
    protected SpriteRenderer renderer;
    protected Transform player;
    protected LayerMask Fight;
    protected AudioSource audio;
    [SerializeField]
    protected AudioClip clip;
    protected float distance;
    public Transform attackpoint, attackpoint2;
    public float attackRange;
    public LayerMask Player;
    protected bool canHit;
    protected float _canHit;
    protected float hitRate = 1.0f;
    [SerializeField]
    protected float sightRange = 3f;
    [SerializeField]
    protected float dangerzone = 1.5f;
    private Skeleton skeleton;
    private MossGiant mossGiant;

    public virtual void Start()
    {
        on = true;
        Init();
        target = pointA.position;
    }

    public virtual void Init()
    {
        mossGiant = GetComponent<MossGiant>();
        skeleton = GetComponent<Skeleton>();
        audio = GetComponentInChildren<AudioSource>();
        animator = GetComponentInChildren<Animator>();
        renderer = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    public virtual void Movement()
    {
        if (target == pointA.position)
        {
            renderer.flipX = true;
        }

        else
        {
            renderer.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            target = pointB.position;
            animator.SetBool("Idle", true);
        }

        else if (transform.position == pointB.position)
        {
            target = pointA.position;
            animator.SetBool("Idle", true);       
        }

        else
        {
            animator.SetTrigger("Walk");
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public virtual void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        {
            return;
        }

        if (isdead == true)
        {
            on = false;
        }

        distance = Vector3.Distance(transform.position, player.transform.position);

        if (on == true)
        {
            Movement();
        }

        StayInBorders();
        Attack();

    }

    public virtual void Attack()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        {
            speed = 0;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            speed = 0;
        }

        else
        {
            speed = 1;
        }

        if (distance < sightRange && distance > dangerzone && on == false)
        {

            on = false;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        }
        if (distance < dangerzone)
        {
            on = false;
            animator.SetTrigger("Attack");
            canHit = true;  
            Hit();
        }

        if (distance > dangerzone)
        {
            on = true;
            //transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
            animator.SetTrigger("Walk");
        }
    }

    protected void StayInBorders()
    {
        if ((transform.position.x < pointA.transform.position.x || transform.position.x > pointB.transform.position.x))
        {
            //animator.SetTrigger("Walk");
            //isdamaged = false;
            on = true;
        }

        if (on == false)
        {

            if (player.transform.position.x > transform.position.x)
            {
                renderer.flipX = false;
            }
            else if (player.transform.position.x < transform.position.x)
            {
                renderer.flipX = true;
            }
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sword" || other.tag == "FlameSword")
        {
            isdamaged = true;
            audio.PlayOneShot(AudioManager.Instance.swordCut);
            animator.SetTrigger("Hit");
            Damage();
            Attack();
        }
    }

    public void Damage()
    {
        if (isdead == true)
            return;
        health--;
       //Debug.Log("Health: " + health);
        if (health < 1)
        {   
            isdead = true;
            animator.SetTrigger("Death");
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
            {
                return;
            }
            Destroy(this.GetComponent<Collider>());
            GameObject diamond = Instantiate(diamond1, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = this.gems;
            Destroy(this.gameObject, 1f);       
        }
    }
    public virtual void Hit()
    {
        StartCoroutine(HitRoutine());
    }

    IEnumerator HitRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        if (renderer.flipX == false)
        {
            Collider2D _player = Physics2D.OverlapCircle(attackpoint.position, attackRange, Player);
            if (_player != null && canHit == true && Time.time > _canHit)
            {

                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    canHit = false;
                    _canHit = Time.time + hitRate / 1f;
                    Debug.Log("Found PLayer");
                    _player.GetComponent<Player>().Damage();
                    canHit = true;
                }
            }
        }

        if (renderer.flipX == true)
            {
            Collider2D _player = Physics2D.OverlapCircle(attackpoint2.position, attackRange, Player);
            if (_player != null && canHit == true && Time.time > _canHit)
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    canHit = false;
                    _canHit = Time.time + hitRate / 1f;
                    Debug.Log("Found PLayer");
                    _player.GetComponent<Player>().Damage();
                    canHit = true;
                }
            }
        }
    }

    public virtual void PlaySound(Enemy enemy, AudioClip clip)
    {
        if (enemy.name == "Skeleton")
        {
            audio.PlayOneShot(clip);
        }
    }
}
