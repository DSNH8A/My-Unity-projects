using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour 
{
    [SerializeField]
    private GameObject[] cars = new GameObject[3];
    private bool spawning = true;
    private Player player;
    [SerializeField]
    //protected T spriteRenderer;

    public void Start()
    {
        //StartCoroutine(SpwanRoutine1());
        //StartCoroutine(SpwanRoutine2());
        player = GetComponent<Player>();
    }

    public IEnumerator SpawnRoutine1(GameObject car, float x, float y, GameObject container)
    {
        while (spawning == true)
        {
            car = Instantiate(car,new  Vector3(x, y, 0f), Quaternion.identity);
            car.transform.parent = container.transform;
            yield return new WaitForSeconds(Random.Range(2, 5));
        }
    }

    public IEnumerator SpawnRoutine2(GameObject car, float x, float y, GameObject container)
    {
        while (spawning == true)
        {
            car = Instantiate(car , new Vector3(x, y, 0f), Quaternion.identity);
            car.transform.parent = container.transform;
            yield return new WaitForSeconds(Random.Range(2, 5));
        }
    }
}
