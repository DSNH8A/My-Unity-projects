using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    BaseState currentState;
    RedState redState = new RedState();
    BlueState blueState = new BlueState();

    void Start()
    {
        currentState = redState;
        currentState.ValamiState(this);
    }

    void Update()
    {
        currentState.OtherState(this);
    }

    public void SwitchState(BaseState state)
    {
        currentState = state;
        state.ValamiState(this);    
    }
}
