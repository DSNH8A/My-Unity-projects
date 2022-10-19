using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePointer : MonoBehaviour
{
    public Vector3 position;
    public int score;
    private MeshRenderer targetColor;

    private StaticEvent staticEvent;

    private void Start()
    {
        staticEvent = GameObject.Find("StaticEvent").GetComponent<StaticEvent>();
        position = transform.position;
        StaticEvent.changePointerPoition += PositionExChange;
        StaticEvent.onColorChange += ColorChange;
        targetColor = GetComponent<MeshRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            MeshRenderer otherMesh = other.transform.GetComponent<MeshRenderer>();

            if (otherMesh.material.color == targetColor.material.color && other.tag == "Target")
            {
                score += 10;
            }

            else 
            { 
               Debug.Log("Color doesnt match!!!");
                score -= 10; 
            }
            
            if (other.tag == "Static")
            {
                score += 10;
                Debug.Log("Sanyi");
            }
        }
        
    }

    private void ColorChange(Color newColor)
    {
        GetComponent<MeshRenderer>().material.color = newColor;   
    }

    public void PositionExChange()
    {
        ScorePointer[] collectible = FindObjectsOfType<ScorePointer>();
        for (int i = 0; i < collectible.Length; i++)
        {
            collectible[0].transform.position = collectible[Random.Range(0, 4)].position;
            collectible[1].transform.position = collectible[Random.Range(0, 4)].position;
            collectible[2].transform.position = collectible[Random.Range(0, 4)].position;
            collectible[3].transform.position = collectible[Random.Range(0, 4)].position;
        }
    }
}
