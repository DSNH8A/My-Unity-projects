using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamagabale
    {
    private bool damaged;
    private GameObject sight;
    private const float yPos = 0f;
    private float currentPosition;
    [SerializeField]
    private GameObject attackLeft, attackRight;

    //--AUDIO--
    public AudioSource audio;
    public AudioClip death;

    private void Awake()
    {
        currentPosition = transform.position.y;
        if (currentPosition != yPos)
        {
            transform.position = new Vector3(transform.position.x, currentPosition, 0);
        }

        else
        {
            transform.position = new Vector3(transform.position.x, yPos, 0);
        }
        sight = transform.GetChild(1).GetComponent<GameObject>();
    }

    //--INTERFACE--
    public bool isdamaged { get; set; }
    public int Health { get; set; }
    public float dangerzone { get; set; }
    public bool playsound { get; set; }
   

    public override void Init()
    {
        base.Init();
        Health = base.health;
        isdamaged = base.isdamaged;
        audio = GetComponent<AudioSource>();
        death = base.clip;
    }

    public override void Update()
    {
        base.Update();   
        transform.position = new Vector3(transform.position.x, currentPosition, 0);
    }

    /*
    void OnTriggerStay2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            
            isdamaged = true;
            animator.SetTrigger("Attack");
            Hit();
            
        }
    }
    */

    /*
    void Hit()
    {
        Collider2D _player = Physics2D.OverlapCircle(attackpoint.position, attackRange, Player);
        if (_player != null && canHit == true && Time.time > _canHit)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
            {
                return;
            }
            else 
            {
                Debug.Log("Found PLayer");
                _player.GetComponent<Player>().Damage();
                canHit = false;
                _canHit = Time.time + hitRate / 1f;
                canHit = true;
            }
        }
    }
    */

    public override void PlaySound(Enemy enemy, AudioClip clip)
    {
        if (enemy.name == "Skeleton")
        {
            audio.PlayOneShot(clip);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }

    IEnumerator HitRoutine()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
