using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
    {
    [SerializeField]
    private float speed = 10f;
    private float multiplier = 2f;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private GameObject tripleShotPrefab;
    [SerializeField]
    private float fireRate = 0.5f;
    private float canFire = -0.15f;
    [SerializeField]
    public int lives = 6;
    private Spawn_Manager spawnManager;
    [SerializeField]
    private bool tripleShot = false;
    [SerializeField]
    public GameObject shield;
    [SerializeField]
    private GameObject fireLeft;
    [SerializeField]
    private GameObject fireRight;
    [SerializeField]
    private bool speedPowerUpIsActive = false;
    [SerializeField]
    public bool shieldPowerUpIsActive = false;
    [SerializeField]
    private int score;
    private UI_Manager uiManager;
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip laserSound;
    [SerializeField]
    private AudioClip explosionSound;
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private Laser laser;
   

    void Start()
    {

        transform.position = new Vector3(0, -4, 0);
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
        uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
       
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = laserSound;

        if (spawnManager == null)
        {
            Debug.LogError("The SpawnManager is NULL.");
        }
        if (uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL");
        }
    }

    void Update()
    {

        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
        {
            audioSource.Play();
            FireLaser();
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.y >= 7)
        {
            transform.position = new Vector3(transform.position.x, 7, 0);
        }
        else if (transform.position.y <= -5.2f)
        {
            transform.position = new Vector3(transform.position.x, -5.2f, 0);
        }

        //transform.position new Vector3(transform.position.x, Mathf.Clamp(transform.position.y -7, 0), 0);

        if (transform.position.x >= 10f)
        {
            transform.position = new Vector3(-10, transform.position.y, 0);
        }
        else if (transform.position.x <= -10f)
        {
            transform.position = new Vector3(10, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
            canFire = Time.time + fireRate;
        if (tripleShot == true)
        {
            Instantiate(tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
     
    }

    public void Damage()
    {
 
        if (shieldPowerUpIsActive == true)
        {
            shieldPowerUpIsActive = false;
            shield.SetActive(false);
           
          
            return;            
        }
        lives --;
       
        if (lives == 2)
        {
            fireLeft.SetActive(true);
        }

        if (lives == 1)
        {
            fireRight.SetActive(true);
        }

        uiManager.UpdateLives(lives);

        if (lives <= 0)
        {
           
            Instantiate(explosion, transform.position, Quaternion.identity);
            spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);

        }
    }

    public void TripleShotActive()
    {
        tripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine()); 
    }
    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);

        tripleShot = false;
    }
    public void SpeedPowerUp()
    {
        speedPowerUpIsActive = true;
        if (speedPowerUpIsActive == true)
        {
            StartCoroutine(SpeedPowerUpRoutine());
            speed *= multiplier;
        }
        
        IEnumerator SpeedPowerUpRoutine()
        {
            if (speedPowerUpIsActive == true)
            {
                yield return new WaitForSeconds(5.0f);
                speedPowerUpIsActive = false;
                speed /= multiplier;
            }
        }
       
    }
    public void ShieldPowerUp()
    {
        shieldPowerUpIsActive = true;
        shield.SetActive(true);
        shield.transform.parent = this.transform;
    }
   
    public void Score(int points)
    {
        score += points;
        uiManager.UpdateScore(score);
    }

    public void DamageBackup()
    {
        lives++;
    }

    public void DamageBackup2()
    {
        lives--;
    }
}
