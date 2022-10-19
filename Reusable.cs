using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reusable<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    instance = new GameObject("Instance of " + typeof(T)).AddComponent<T>();   
                }
            }

            return instance;    
        }      
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);     
        }
    }

    public void Message()
    {
        Debug.Log("Vaslami message");
    }
}
