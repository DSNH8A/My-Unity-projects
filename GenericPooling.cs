using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericPooling<T> : MonoBehaviour where T : Component
{
    [SerializeField]
    private T prefab; 
    [SerializeField]
    private Transform[] positionsToAppear = new Transform[3];

    public static GenericPooling<T> Instance { get; private set; }
    private Queue<T> objects = new Queue<T>();

    private void Awake()
    {
        Instance = this;
        //GrowPool(1);
        AudioManager.Instance.Message();
    }

    public T GetFromPool()
    {
        if (objects.Count == 0)
        {
            GrowPool(3);
        }
        return objects.Dequeue();

    }

    private void GrowPool(int count)
    {
        var instanceToAdd = Instantiate(prefab, positionsToAppear[Random.Range(0, 3)]);
        //instanceToAdd.Initialize(ScorePointer);
        instanceToAdd.gameObject.SetActive(true);
        objects.Enqueue(instanceToAdd);
    }

    public void AddToPool(T objectToreturn)
    {
        objectToreturn.gameObject.SetActive(false);
        objects.Enqueue(objectToreturn);
    }  
}
