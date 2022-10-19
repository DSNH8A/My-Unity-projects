using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private int speed = 4;
    private float rotation = 30.0f;
    [SerializeField]
    private GameObject explosion;
    private Spawn_Manager spawnManager;
   
    private void Start()
    {
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
        transform.position = new Vector3(0, 2);
    }

    private void Update()
    {
        AsteroidMovement();
        
    }

    private void AsteroidMovement()
    {
        //transform.Translate(Vector3.down * Time.deltaTime * speed);
        //transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Laser")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            speed = 0;
            Destroy(other.gameObject);
            Destroy(this.gameObject, 0.25f);
            spawnManager.Spawning();
            
        }
    }

    
}
