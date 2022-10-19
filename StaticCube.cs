using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCube : ObjectParent
{
    //public Color[] colors = new Color[4];
   
    public override void Start()
    {
        //StaticEvent.onColorChange += Change;
        //GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, 4)];
        base.Start();
    }

    void Update()
    {
     
    }

    public void Change(Color newColor)
    {
        GetComponent<MeshRenderer>().material.color = newColor;   
    }
}
