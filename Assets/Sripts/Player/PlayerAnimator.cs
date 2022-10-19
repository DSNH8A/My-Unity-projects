using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private Animator swordArc;
    private Animator flameSword;
    private Animator flameSwordFlip; 
    private SpriteRenderer renderer;
    private Player player;

    void Start()
    {
        player = transform.parent.GetComponent<Player>();
        flameSwordFlip = GameObject.Find("FlameSwordFlip").GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        swordArc = GameObject.Find("SwordArc").GetComponent<Animator>();
        flameSword = GameObject.Find("FlameSword").GetComponent<Animator>();
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(float move)
    {
        animator.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump()
    {
        StartCoroutine(JumpRoutine());  
    }

    public void Jump(bool jumping)
    {
        animator.SetBool("Jump", jumping);
    }

    public void Attack()
    {

        if (GameManager.Instance.hasFlameSword == true)
        {
            if (player.turned == true)
            {
                flameSwordFlip.SetTrigger("FlameSwordFlip");

                StartCoroutine(AttackRoutine());
            }

            else if (player.turned == false)
            {
                flameSword.SetTrigger("FlameSwordFlip");
                StartCoroutine(AttackRoutine());
            }
            
        }

        else
        {
            StartCoroutine(AttackRoutine());
            swordArc.SetTrigger("SwordArc");
        }

    }

    IEnumerator JumpRoutine()
    {
        animator.SetBool("Jump", true);

        yield return new WaitForSeconds(1.0f);

        animator.SetBool("Jump", false);
    }

    IEnumerator AttackRoutine()
    {
        animator.SetBool("Attack", true);
        
        yield return new WaitForSeconds(0.5f);

        animator.SetBool("Attack", false);
    }

    public void JumpAttack()
    {

        animator.SetTrigger("JumpAttack");   
    }

    public void RunAttack()
    {
        animator.SetTrigger("RunAttack");   
    }

    public void Death()
    {
        animator.SetTrigger("Death");   
    }

}
