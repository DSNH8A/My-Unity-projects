using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericPooling<T> : MonoBehaviour where T : Component
{
    [SerializeField]
    private T prefab;
    [SerializeField]
    private int counter = 0;

    public static GenericPooling<T> Instance { get; private set; }
    private Queue<T> objects = new Queue<T>();

    private void Awake()
    {
        Instance = this;
    }

    public T Get()
    {
        if (objects.Count == 0)
        {
            AddObjects(10);   
        }
        return objects.Dequeue();   
    }

    private void AddObjects(int count)
    {
        var newObject = Instantiate(prefab);
        newObject.gameObject.SetActive(false);
        objects.Enqueue(newObject);
    }

    public void ReturnToPool(T objectToreturn)
    {
        objectToreturn.gameObject.SetActive(false);
        objects.Enqueue(objectToreturn);
        counter++;
    }
}

public abstract class GenericPoolingForCars<Car> : MonoBehaviour where Car : Component
{
    [SerializeField]
    private Car car1;
    [SerializeField]
    private Car car2;
    [SerializeField]
    private Car car3;

    private int counter = 0;

    private Car MakeArayForCars(Car car1, Car car2, Car car3)
    {
        Car[] cars = new Car[] { car1, car2, car3 };
        Car chosenCar = cars[Random.Range(0, 3)];
        return chosenCar;
    }

    public static GenericPoolingForCars<Car> Instance { get; private set; }
    private Queue<Car> cars = new Queue<Car>();
    
    private void Awake()
    {
        Instance = this;
    }

    public Car Get()
    {
        if (cars.Count == 0)
        {
            AddCars(10);
        }
        return cars.Dequeue();
    }

    private void AddCars(int count)
    {
        var newCar = Instantiate(MakeArayForCars(car1, car2, car3));
        newCar.gameObject.SetActive(false);
        cars.Enqueue(newCar);
    }

    public void ReturnToPool(Car CarToReturn)
    {
        CarToReturn.gameObject.SetActive(false);
        cars.Enqueue(CarToReturn);
        //counter++;
    }
}