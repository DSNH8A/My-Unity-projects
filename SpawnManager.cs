using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour 
{
    [SerializeField]
    private GameObject target;
    private Transform trafo;
    private Rigidbody targetBody;
    private bool isSpawning = false;

    void Start()
    {
        trafo = GetComponentInChildren<Transform>();
        isSpawning = true;
        StartCoroutine(SpawnRoutine());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(3f);

        while (isSpawning == true)
        {
            //GameObject Target = Instantiate(target, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
            
            //targetBody = GetComponentInChildren<Rigidbody>();
            //targetBody.AddForce(Vector3.up * 100f);
            //Target.transform.parent = null;
            ShotPool.Instance.GetFromPool();
            yield return new WaitForSeconds(Random.Range(5f, 15f));
        }
    }
}
