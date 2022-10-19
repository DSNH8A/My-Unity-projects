using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager1 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cars = new GameObject[3];
    [SerializeField]
    private GameObject container;
    private bool spawning = true;

    public void Start()
    {
        //StartCoroutine(SpwanRoutine1());
        //StartCoroutine(SpwanRoutine2());
    }

    void Update()
    {
        
    }
    public IEnumerator SpawnRoutine1(GameObject car, float x, float y, GameObject container)
    {
        while (spawning == true)
        {
            car = Instantiate(car, new Vector3(x, y, 0f), Quaternion.identity);
            car.transform.parent = container.transform;
            yield return new WaitForSeconds(Random.Range(2, 5));
        }
    }

    public IEnumerator SpawnRoutine2(GameObject car, float x, float y, GameObject container)
    {
        while (spawning == true)
        {
            car = Instantiate(car, new Vector3(x, y, 0f), Quaternion.identity);
            car.transform.parent = container.transform;
            yield return new WaitForSeconds(Random.Range(2, 5));
        }
    }
}

