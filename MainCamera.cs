using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private float speed = 1f;
    private float startTime;

    void Start() 
    {
        
    }

    void Update()
    {    
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
