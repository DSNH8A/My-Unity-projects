using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamagabale
{
    private Rigidbody2D rg;
    private float liftForce = 7f;
    private float speed = 2.0f;
    [SerializeField]
    private LayerMask ground;
    private bool resetJumpNeeded = false;
    private PlayerAnimator playerAnimator;
    private SpriteRenderer rend;
    //--SWORDARC--
    private SpriteRenderer _rend;
   


    private Transform attackTransform;
    private Animator animator;
    public int diamondCount = 0;
    [SerializeField]
    private GameObject attack1, attack2, attack3, attack4;
    [SerializeField]
    public bool turned = false;
    [SerializeField]
    private BoxCollider2D enemy;
    private float hitrate = 0.75f;
    private float canhit;
    public Vector3 target;
    public Transform attackpoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private Enemy _enemy;
    private bool gruonded = false;

    // --AUDIO--
    private AudioSource audio;
    public AudioClip swordswing;
    public AudioClip jump;
    public AudioClip death;

    // --INTERFACE--
    [SerializeField]
    public int Health {get; set;}
    public bool isdamaged { get; set; }
    public float dangerzone { get; set; }
    public bool playsound { get; set; }


    void Start()
    {
        _enemy = GetComponent<Enemy>();
        audio = GetComponent<AudioSource>();
        target = new Vector3(transform.position.x, transform.position.y + 1f, 0);
        rg = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
        rend = GetComponentInChildren<SpriteRenderer>();
        animator = transform.GetChild(1).GetComponent<Animator>();
        _rend = transform.GetChild(1).GetComponent<SpriteRenderer>();
        attackTransform = transform.GetChild(1).GetComponent<Transform>();
        enemy = GetComponent<BoxCollider2D>();
        Health = 4;
    } 

    void Update()
    {
        Movement();
        IsGrounded();
        Attack();
        JumpAttack();
        RunAttack();
        UIManager.Instance.DiamondDisplay(diamondCount);
    }

    void Movement()
    {
        float move = Input.GetAxis("Horizontal");
        float moveUp = Input.GetAxis("Vertical"); 

        gruonded = IsGrounded();
        
        if ((Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true))
        {
            //audio.PlayOneShot(jump);
            rg.velocity = new Vector2(rg.velocity.x, liftForce);
            StartCoroutine(JumpRoutine());
            playerAnimator.Jump(true);        
        }

        if (GameManager.Instance.hasBoots == true)
        {
            rg.velocity = new Vector2(move * speed, moveUp);
        }
        else 
        {
            rg.velocity = new Vector2(move * speed, rg.velocity.y);
        }
        playerAnimator.Move(move);

        if (move > 0)
        {
            Flip(true);
        }
        else if (move < 0)
        {
            Flip(false);
        }
    }

    IEnumerator JumpRoutine()
    {
        resetJumpNeeded = true; 
        yield return new WaitForSeconds(0.1f);
        resetJumpNeeded = false;
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, ground.value);
        Debug.DrawRay(transform.position, Vector2.down *0.6f, Color.red);

        if (hit.collider != null)
        {
            if (resetJumpNeeded == false)
                playerAnimator.Jump(false);
            return true;  
        }
        return false;
    }

    void Flip(bool faceRight)
    {
        if (faceRight == true)
        {
            rend.flipX = false;
            _rend.flipY = false;
            _rend.flipX = false;
            turned = false;
            Vector3 newPos = _rend.transform.localPosition;
            newPos.x = 0;
            _rend.transform.localPosition = newPos;
        }

        else if (faceRight == false)
        {
            rend.flipX = true;
            //_rend.flipY = true;
            _rend.flipX = true;
            turned = true;
            Vector3 newPos = _rend.transform.localPosition;
            newPos.x = 0;
            _rend.transform.localPosition = newPos;
        }
    }

    void Attack()
    {
     
        if (Input.GetMouseButtonDown(0) && Time.time > canhit)
        {
            if (GameManager.Instance.hasFlameSword == true)
            {
                Debug.Log("FlameSword");
                attack3.tag = "FlameSword";
                attack4.tag = "FlameSword";
            }
            canhit = Time.time + hitrate;
            StartCoroutine(BoxesRoutine1());
            StartCoroutine(BoxesRoutine2());
           // animator.SetTrigger("SwordArc");
            playerAnimator.Attack();
            if (GameManager.Instance.hasFlameSword == true)
            {
                audio.PlayOneShot(AudioManager.Instance.flameSword);
            }

            else 
            {
                audio.PlayOneShot(swordswing);
            }
           
            Hit();
        }
    }

    void JumpAttack()
    {
        if (Input.GetMouseButtonDown(0) && IsGrounded() == false)
        {
            playerAnimator.JumpAttack();   
        }
    }

    void RunAttack()
    {
        if (rg.velocity.x != 0 && Input.GetMouseButtonDown(0))
        {
            playerAnimator.RunAttack();
        }
    }

    IEnumerator BoxesRoutine2()
    {

        if (turned == true)
        {
            yield return new WaitForSeconds(0.2f);
            attack2.SetActive(false);

            yield return new WaitForSeconds(0.1f);
            attack4.SetActive(false);
        }

        else
        {
            //yield return new WaitForSeconds(0.2f);
            //attack1.SetActive(false);

            yield return new WaitForSeconds(0.2f);
            attack3.SetActive(false);
        }
    }

    IEnumerator BoxesRoutine1()
    {
        if (turned == true)
        {
            //yield return new WaitForSeconds(0.1f);
            //attack2.SetActive(true);

            yield return new WaitForSeconds(0.1f);
            attack4.SetActive(true);
        }

        else
        {
            //yield return new WaitForSeconds(0.1f);
            //attack1.SetActive(true);
            //Debug.Log("Attack1");

            yield return new WaitForSeconds(0.1f);
            attack3.SetActive(true);
            Debug.Log("Attack3");
        }
    }

    public void Damage()
    {
        Health--;
        UIManager.Instance.UpdateLives(Health);

        if (Health < 1)
        {
            audio.PlayOneShot(death);
            playerAnimator.Death();
            Destroy(this.gameObject, 1.0f);   
        }
    }

    void Hit()
    {
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitenemies)
        {
            Debug.Log("EnenmyHIt!!");   
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if(other.tag == "End")
        {
            if (GameManager.Instance.HasKeyToCastle == true)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
