using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
    {
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private GameObject enemyContainer;

    [SerializeField]
    private GameObject tripleshot;
    [SerializeField]
    private GameObject[] powerUps = new GameObject[3];

    [SerializeField]
    private GameObject asteroid;

    public bool stopSpawning = false;
    [SerializeField]
    private GameObject explosion;
    private bool asteroidSpawn = false;

    [SerializeField]
    private GameObject player;

    void Start()
    {
        //StartCoroutine(AsteroidRoutine());
        Vector3 PosToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
        Instantiate(asteroid, PosToSpawn, Quaternion.identity);
    }

    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.5f); 

        while (stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy =  Instantiate(enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }  
       
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        yield return new WaitForSeconds(2.5f);

        while (stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(powerUps[randomPowerUp], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 8));
        }
                          
    }
    /*
    IEnumerator AsteroidRoutine()
    {
        while (stopSpawning == false)
        { 
            
            Vector3 PosToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            Instantiate(asteroid, PosToSpawn, Quaternion.identity);
            if (asteroidSpawn == true)
            {
                yield return new WaitForSeconds(Random.Range(30f, 60f));
            }
         
        }
    }  
    */

    public void OnPlayerDeath()
    {
        stopSpawning = true;   
    }

    public void Spawning()
    {
        StartCoroutine(Spawn());
        StartCoroutine(SpawnPowerUpRoutine());
    }

}
