using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Sprite roadImage;
    public Vector3 localPosition;
    public Transform transform;

    /*
    public Map(Sprite mapImage, Vector3 localPosition, Transform transform)
    {
        this.mapImage = mapImage;   
        this.localPosition = localPosition;
        this.transform = transform;   
    }
    */
    public SpriteRenderer Image(Sprite street, Vector3 localposition, Transform parent)
    {
        GameObject feri = new GameObject("SpriteRenderer", typeof(SpriteRenderer));
        Transform transform = feri.transform;
        transform.position = localposition;
        transform.SetParent(parent, false); 
        SpriteRenderer spriterenderer = feri.GetComponent<SpriteRenderer>(); 
        Sprite sprite = street;
        spriterenderer.sprite = sprite;
        return spriterenderer;
    }

    void Start()
    {
        Image(roadImage, localPosition, transform);
    }
}

public class Grass : MonoBehaviour
{
    public Sprite grassImage;
    public Vector3 localPosition;
    public Transform transform;

    public SpriteRenderer GrassImage(Sprite street, Vector3 localposition, Transform parent)
    {
        GameObject feri = new GameObject("SpriteRenderer", typeof(SpriteRenderer));
        Transform transform = feri.transform;
        transform.position = localposition;
        transform.SetParent(parent, false);
        SpriteRenderer spriterenderer = feri.GetComponent<SpriteRenderer>();
        Sprite sprite = street;
        spriterenderer.sprite = sprite;
        spriterenderer.flipX = false;
        return spriterenderer;

        void Start()
        {
            GrassImage(grassImage, localPosition, transform); 
        }
    }
}

public class CalmBelt : MonoBehaviour
{
    public SpriteRenderer BeltImage(Sprite Belt, Vector3 localPosition, Transform parent)
    {
        GameObject sanyi = new GameObject("CalmBelt", typeof(SpriteRenderer));
        Transform transform = sanyi.transform;
        transform.position = localPosition;
        transform.SetParent(parent, false);
        SpriteRenderer spriteRenderer = sanyi.GetComponent<SpriteRenderer>();
        Sprite sprite = Belt;
        spriteRenderer.sprite = sprite;
        return spriteRenderer;

    }
}

public class CarCreator : MonoBehaviour
{
    public IEnumerator CreateCars(float posOnRoadX, float posOnRoadY, CarCreator currentTest)
    {
        while (true)
        {
            var car = CarPool.Instance.Get();
            car.transform.parent = currentTest.transform;
            car.transform.rotation = transform.rotation;
            car.transform.position = new Vector2(posOnRoadX, posOnRoadY);
            car.gameObject.SetActive(true);
            yield return new WaitForSeconds(Random.Range(2, 4));
        }
    }

    public void StartCreating()
    {
        StartCoroutine(CreateCars(-13f, 2.2f, this));
        StartCoroutine(CreateCars(-13f, 0.8f, this));
        StartCoroutine(CreateCars(13f, -2.2f, this));
        StartCoroutine(CreateCars(13f, -0.8f, this));
    }
}
