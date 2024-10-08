using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerState;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState currentState;
    public PlayerController playerController;
    // Start is called before the first frame update
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    void Start()
    {
        TransitionToState(new IdleState(this));
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }

    private void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.FixedUpdate();
        }
    }

    public void TransitionToState(PlayerState newstate)
    {
        currentState?.Exit();

        currentState = newstate;

        currentState.Enter();
        Debug.Log($"Transitioned to State {newstate.GetType().Name}");
    }
}
