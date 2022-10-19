using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private Sprite road;
    [SerializeField]
    private Sprite grassImage;

    [SerializeField]
    private GameObject[] cars = new GameObject[3];

    [SerializeField]
    private GameObject container;

    private BoxCollider2D collider;
    private Rigidbody2D rb;

    private float lifetime;
    private float maxLifeTime = 20;

    private FosoObject fosoObject;
    private CarCreator creator;

    private void OnEnable()
    {
        fosoObject = GameObject.Find("FosoObject").GetComponent<FosoObject>();
        lifetime = 0;
        FosoObject.onBuild += Prepare;
        //FosoObject.onBuild += AssignSpawner;
    }

    private void OnDisable()
    {
        FosoObject.onBuild -= AssignSpawner;
    }

    void Start()
    {
        container = GameObject.Find("Container");

        this.gameObject.layer = 6;

        Map map = new Map();
        SpriteRenderer sprite = map.Image(road, new Vector3(0, 0, 0), this.transform);
        sprite.transform.localScale = new Vector2(2f, 1f);

        AssignSpawner();
        
        collider = gameObject.AddComponent<BoxCollider2D>();
        collider.offset = new Vector2();
        collider.isTrigger = true;
        collider.size = new Vector2(30f, 6f);

        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

        Grass grass = new Grass();
        SpriteRenderer grassSprite = grass.GrassImage(grassImage, new Vector3(0, 0, 0), this.transform);
        grassSprite.transform.localScale = new Vector2(2f, 1f);
    }

    private void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime > maxLifeTime)
        {
           Medence.Instance.ReturnToPool(this);
        }

        FosoObject.onBuild -= Prepare;
    }

    void OnColisionEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("HIT!!");   
        }
    }

    private void Prepare()
    {
        fosoObject = GameObject.Find("FosoObject").GetComponent<FosoObject>();
        container = GameObject.Find("Container");

        Map map = new Map();

        Grass grass = new Grass();

        AssignSpawner();
    }

    private void AssignSpawner()
    {
        StartCoroutine(fosoObject.CreateCars(transform.position.x -13f, transform.position.y + 2.2f, this));
        StartCoroutine(fosoObject.CreateCars(transform.position.x -13f, transform.position.y + 0.8f, this));
        StartCoroutine(fosoObject.CreateCars(transform.position.x + 13f, transform.position.y -2.2f, this));
        StartCoroutine(fosoObject.CreateCars(transform.position.x + 13f, transform.position.y -0.8f, this));
    }
}
