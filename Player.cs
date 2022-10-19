using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody heldObject;
    private Transform pos;
    private Transform target;
    private Transform camera;
    private Vector3 look;
    private Vector3 shooot;
    private bool hasObject = false;
    private Transform feri;
    private string name;
    private Transform canvas;
    private Transform canvasChild;
    private Transform gotCanvasChild;
    private Vector3 posAfterButtonClick;
    public bool buttonWasPressed = false;

    void Start()
    {
        camera = transform.GetChild(0).GetComponent<Transform>();
        feri = transform.GetChild(1).GetComponent<Transform>();
        canvas = transform.GetChild(2).GetComponent<Transform>();
        SubscribeToEvent();
    }

    void Update()
    {
        Click();
        GetObject();
        Look();
        Shoot();
        PlaceTarget(gotCanvasChild);
    }

    private void Shoot()
    {
        if (heldObject != null && Input.GetKeyDown(KeyCode.Alpha0) && heldObject.transform.parent != null)
        {
            hasObject = false;
            heldObject.AddForce(shooot * 100);
            heldObject.useGravity = true;
            target.transform.parent = null;
        }
    }

    private void Look()
    {
        float _mouseX = Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + _mouseX, transform.localEulerAngles.z);

        float _mouseY = Input.GetAxis("Mouse Y");
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x - _mouseY, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }

    private void GetObject()
    {
        var speed = 2;
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime);

        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitinfo;
        if (Physics.Raycast(rayOrigin, out hitinfo) && hasObject == false)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                if (hitinfo.transform.name == "Target")
                {
                    hitinfo.transform.position = feri.position; 
                }
                else 
                {
                    hitinfo.transform.parent = this.transform;
                    GetObjectOther();
                }
            }
        }

        else if (Physics.Raycast(rayOrigin, out hitinfo) && hasObject == true)
        {
            shooot = hitinfo.transform.position;
        }
    }

    private void Click()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray cursorRay = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hitinfo2;

        if (Physics.Raycast(cursorRay, out hitinfo2))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("Hit: " + mousePosition);
                //pos.position = mousePosition;
               // buttonWasPressed = true;    
                name = hitinfo2.transform.name;
                Debug.Log(name);
            }
        }      
    }

    private void PlaceTarget(Transform trans)
    {
        if (hasObject == true && buttonWasPressed == true)
        {
            //SubscribeToEvent();
            switch (trans.name)
            {
                case "UpSide":
                    target.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 1);
                    target.rotation = this.transform.rotation;
                    target.transform.parent = this.transform;
                    UnsubscribeToEvevnt();
                    buttonWasPressed = false;
                    break;
                case "DownSide":
                    target.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z + 1);
                    target.rotation = this.transform.rotation;
                    target.transform.parent = this.transform;
                    UnsubscribeToEvevnt();
                    buttonWasPressed = false;
                    break;
                case "RightSide":
                    target.position = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z + 1);
                    target.rotation = this.transform.rotation;
                    target.transform.parent = this.transform;
                    Debug.Log("JobbOldal");
                    UnsubscribeToEvevnt();
                    buttonWasPressed = false;
                    break;
                case "LeftSide":
                    target.position = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z + 1);
                    target.rotation = this.transform.rotation;
                    target.transform.parent = this.transform;
                    UnsubscribeToEvevnt();
                    buttonWasPressed = false;
                    break;
            }
        }
    }

    private void GetObjectOther()
    {
        target = transform.GetChild(3).GetComponent<Transform>();
        target.rotation = this.transform.rotation;
        target.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 3f);
        heldObject = transform.GetChild(3).GetComponent<Rigidbody>();
        pos = transform.GetChild(3).GetComponent<Transform>();
        hasObject = true;
        //SubscribeToEvent();
    }

    private void SubscribeToEvent()
    {
        StaticEvent.getButtonTransform5 += GetObjectOther;
        StaticEvent.getButtonTransform += GetThoseTransforms;
        StaticEvent.getButtonTransform2 += GetThoseTransforms2;
        StaticEvent.getButtonTransform3 += GetThoseTransforms3;
        StaticEvent.getButtonTransform4 += GetThoseTransforms4;
  
    }

    private void UnsubscribeToEvevnt()
    {
        StaticEvent.getButtonTransform -= GetThoseTransforms;
        StaticEvent.getButtonTransform2 -= GetThoseTransforms2;
        StaticEvent.getButtonTransform3 -= GetThoseTransforms3;
        StaticEvent.getButtonTransform4 -= GetThoseTransforms4;
    }

    #region gettransforms
    public void GetThoseTransforms()
    {
        if (hasObject == true)
        {
            canvasChild = canvas.GetChild(0).GetComponent<Transform>();
            gotCanvasChild = canvasChild;
        }
    }

    public void GetThoseTransforms2()
    {
        if (hasObject == true)
        {
            canvasChild = canvas.GetChild(1).GetComponent<Transform>();
            gotCanvasChild = canvasChild;
        }
    }

    public void GetThoseTransforms3()
    {
        if (hasObject == true)
        {
            canvasChild = canvas.GetChild(2).GetComponent<Transform>();
            gotCanvasChild = canvasChild;
        }
    }

    public void GetThoseTransforms4()
    {
        if (hasObject == true)
        {
            canvasChild = canvas.GetChild(3).GetComponent<Transform>();
            gotCanvasChild = canvasChild;
        }
    }
    #endregion
}
