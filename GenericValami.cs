using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericValami<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    private T Spawner;
    [SerializeField]
    private GameObject target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
