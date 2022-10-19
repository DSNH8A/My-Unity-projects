using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : ObjectParent
{
    //private Vector4 startingColor;
    private Rigidbody rb;

    public override void Start()
    { 
        //float lebego = Random.Range(0f, 1f); 
        //startingColor = new Vector4(lebego, lebego, lebego *lebego, lebego);
        //this.GetComponent<Renderer>().material.color = startingColor; 
        rb = GetComponent<Rigidbody>();
        Speed();
        base.Start();
        //StaticEvent.onColorChange += Colorr;
    }

    public override void Update()
    {
        base.DestroyShit(this);
    }
    /*
    public void Colorr(Color newColor)
    {
        GetComponent<Renderer>().material.color = newColor;
    }
    */
    /*
    private void DestroyShit()
    {
        if (transform.position.y < border || transform.position.y > border * -1f)
        {
            ShotPool.Instance.AddToPool(this);
        }
    }
    */
    private void Speed()
    {
        rb.AddForce(Vector3.up * 100f);  
    }
}
