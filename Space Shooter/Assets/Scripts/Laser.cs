using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
    {
    private float speed = 8.0f;
    [SerializeField]
    public bool isEnemLaser = false;
    private bool playerLaser;
    [SerializeField]
    private GameObject enemyLaser;

    void Start()
    {
        Debug.Log(transform.parent);
    }


    void Update()
    {
        StartCoroutine(EnemyLaserRoutine());

        if (isEnemLaser == false) 
        {
            MoveUp();
        }
        else
        { 
            MoveDown();
        }
    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y > 7f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }
    }

    void MoveDown()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -6f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

           Destroy(this.gameObject);
        }
    }

    public void AssignEnemyLaser()
    {
        isEnemLaser = true;   
    }

    IEnumerator EnemyLaserRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && isEnemLaser == true)
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                if (player.shieldPowerUpIsActive == false)
                {
                    player.Damage();
                    //player.DamageBackup();
                    //player.lives ++;
                }

                if (player.shieldPowerUpIsActive == true)
                {
                    player.shieldPowerUpIsActive = false;
                    player.shield.SetActive(false);
                }
            }

        }
    }

}
