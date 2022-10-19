using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    private SpriteRenderer renderer;
    private Vector3 pos;
    private int[] speedVariation = new int[] {1, 2, 3};
    private int variations;
    private Transform roadPos;

    private float carCreateRate;
    private float carCreateTime = 0;
    private Transform carPos;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        pos = transform.position;

        variations = speedVariation[Random.Range(0, 3)];
        carCreateRate = Random.Range(2f, 5f);
    }

    void Update()
    {
        Pooling();
        GiveThemSpeed(variations);
        GiveThemDirection();
    }

    private void GiveThemSpeed(int variations)
    {
        switch (variations)
        {
            case 1:
            {
               speed = 8;
            }
                break;
            case 2:
            {
               speed = 7;
            }
                break;
            case 3:
            {
                speed = 6;
            }
                break;
        }
    }

    private void GiveThemDirection()
    {
        if (pos.x > 0)
        {
            renderer.flipX = true;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    private void Pooling()
    {
        if (transform.position.x > 13f || transform.position.x < -13f)
        {
            CarPool.Instance.ReturnToPool(this);
        }
    }
}
