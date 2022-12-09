using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Undead_State
{
    UndeadUp,
    UndeadDown,
    UndeadHurt
}

public class UndeadStateManager : MonoBehaviour
{
    UndeadState currentState;
    [SerializeField]
    List<UndeadState> states = new();
    public UndeadState State => currentState;

    [SerializeField]
    Animator animator;

    public UndeadState GetCurrentState()
    {
        return currentState;
    }

    private void Awake()
    {
        currentState = FindState(Undead_State.UndeadUp);
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchState(Undead_State state)
    {
        Debug.Log("switching state ?" + state.ToString());

        currentState.OnStateExit();
        currentState = FindState(state);
        currentState.OnStateEnter();
    }

    UndeadState FindState(Undead_State state)
    {
        return states[((int)state)];
    }
}
