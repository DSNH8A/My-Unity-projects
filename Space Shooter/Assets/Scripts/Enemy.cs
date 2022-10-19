using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 4f;

    private Player player;
    private Animator animator;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private GameObject _enemyLaser;
    private bool spawning = false;
    [SerializeField]
    public bool isDestroyed = false;
    [SerializeField]
    private GameObject enemyContainer;
    private float fireRate = 3.0f;
    private float canFire = -1.0f;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        //StartCoroutine(LaserRoutine());
    }

    void Update()
    {
        MovingEnemy();

        
        if (Time.time > canFire && isDestroyed != true)
        {
            fireRate = Random.Range(3.0f, 7.0f);
            canFire = Time.time + fireRate;
            GameObject enemyLaser = Instantiate(_enemyLaser, transform.position, Quaternion.identity);
            //Debug.Break();
            Laser[] lasers = enemyLaser.GetComponentsInChildren<Laser>();
            for (int i = 0; i < lasers.Length; i++)
            {
                lasers[i].AssignEnemyLaser();   
            }
            //lasers[0].AssignEnemyLaser();
            //lasers[1].AssignEnemyLaser();
            
        }     
    }

    void MovingEnemy()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (transform.position.y <= -7)
        {
            float randomX = Random.Range(-7f, 7f);
            transform.position = new Vector3(randomX, 7, 0);
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            isDestroyed = true;
            player.Damage();
            animator.SetTrigger("OnEnemyDeath");
            speed = 0;
            audioSource.Play();

            Destroy(GetComponent<Collider2D>());
            //Destroy(GetComponent<Transform>());
            
            Destroy(this.gameObject, 2.0f);
            
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
           
            if (player != null)
            {
               player.Score(10);
            }

            isDestroyed = true;
            animator.SetTrigger("OnEnemyDeath");
            speed = 0;
            audioSource.Play();
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.0f);
        }        
        
    }
    
}
