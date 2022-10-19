using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamagabale
{
    //--INTERFACE--
    public bool isdamaged { get; set; }
    public int Health { get; set; }
    public float dangerzone { get; set; }
    public bool playsound { get; set; }


    private const float yPos = 0.7f;
    private float currentPosition;
    private bool damaged;
    private AudioSource audio;
    private bool canPlay = false;
    public bool _canhit;
    public GameObject attackLeft, attackRight;
    private SpriteRenderer renderer;
    private float sightRange;
    private float hitRate = 0.3f;
    private bool canHit;
    public bool walkSound;
    private bool walk;

    private void Awake()
    {
        renderer = GetComponentInChildren<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
        currentPosition = transform.position.y;
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
        Health = base.health;
        Health = 3;
        isdamaged = base.isdamaged;
        audio = base.audio;
        sightRange = base.sightRange;  
    }

    public override void Update()
    {
        base.Update();
        transform.position = new Vector3(transform.position.x, currentPosition, 0);
        if (base.isdead == true)
        {
            PlaySound(this, AudioManager.Instance.skeletonDeath);
            base.isdead = false;
            Destroy(this.gameObject ,1.0f);   
        }
    }

    public override void PlaySound(Enemy enemy, AudioClip clip)
    {
        if (enemy.name == "Skeleton")
        {
            audio.PlayOneShot(clip);   
        }
    }

    /*
    public override void Hit()
    {
        Collider2D _player = Physics2D.OverlapBox(attackpoint, attackRange, 31);
        if (_player != null && _canhit == true && Time.time > base._canHit)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                _canhit = false;
                base._canHit = Time.time + base.hitRate / 1f;
                Debug.Log("Found PLayer");
                _player.GetComponent<Player>().Damage();
                _canhit = true;
            }
        }
    }*/

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }
}
