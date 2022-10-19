using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FosoObject : MonoBehaviour
{
    public delegate void OnBuild();
    public static event OnBuild onBuild;

    private float roadCreateRate = 5f;
    private float roadCreateTime = 0;

    //private float carCreateRate = 4f;
    //private float carCreateTime = 0;

    private int time = 0;
    private int counter = 0;
    private bool mehet = false;

    private Transform test; 

    private void Start()
    {
        StartCoroutine(TimeRoutine());
    }

    void Update()
    {
        if (counter >= 5 && mehet == true)
        {
            Onbuild();
            mehet = false;
        }

        roadCreateTime += Time.deltaTime;
        if (roadCreateTime > roadCreateRate)
        {
            roadCreateTime = 0;
            CreateRoad();
        }
    }

    private void CreateRoad()
    {
        var road = Medence.Instance.Get();
        road.transform.rotation = transform.rotation;
        road.transform.position = new Vector2(transform.position.x, transform.position.y + time - 6f);
        road.gameObject.SetActive(true);
        counter++;
        mehet = true;
    }

    public IEnumerator CreateCars(float posOnRoadX, float posOnRoadY, Test currentTest)
    {
        while (true)
        {
            var car = CarPool.Instance.Get();
            car.transform.parent = currentTest.transform;
            car.transform.rotation = transform.rotation;
            car.transform.position = new Vector2(posOnRoadX, posOnRoadY);
            car.gameObject.SetActive(true);
            yield return new WaitForSeconds(Random.Range(2, 7));
        }
    }

    IEnumerator TimeRoutine()
    {
        while (true)
        {
            time += 6;
            yield return new WaitForSeconds(5);
        }    
    }

    public void Onbuild()
    {
        if (onBuild != null && counter >= 5)
        {
            onBuild();
        }
    }
}
