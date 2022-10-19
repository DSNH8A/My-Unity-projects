using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueState : BaseState
{
    public override void ValamiState(StateManager color)
    {
        Debug.Log("Blue State!!");
    }


    public override void OtherState(StateManager color)
    {
        Debug.Log("RedState!!");   
    }
   
}
