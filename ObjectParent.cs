using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectParent : MonoBehaviour
{
    public Color[] colors = new Color[4];
    protected Vector4 color;
    protected float border  = -8f;

    public virtual void Start()
    {
        float lebego = Random.Range(0f, 1f);
        color = new Vector4(lebego, lebego, lebego *lebego, lebego);
        StaticEvent.onColorChange += ColorChange;
        GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, 4)];

    }

    public virtual void Update()
    {
        
    }

    protected void ColorChange(Color newColor)
    {
        GetComponent<MeshRenderer>().material.color = newColor;   
    }

    protected void DestroyShit(Target target)
    {
        if (transform.position.y < border || transform.position.y > border * -1f)
        {
            ShotPool.Instance.AddToPool(target);
        }
    }
}
