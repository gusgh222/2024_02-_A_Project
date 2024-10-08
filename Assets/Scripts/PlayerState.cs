using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected PlayerStateMachine stareMachine;
    protected PlayerController playerController;

    public PlayerState(PlayerStateMachine stateMachine)
    {
        this.stareMachine = stateMachine;
        this.playerController = stateMachine.playerController;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }

    protected void CheckTransitions()
    {
        if (playerController.isGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stareMachine.TransitionToState(new JumpingState(stareMachine));
            }
            else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                stareMachine.TransitionToState(new MoveingState(stareMachine));
            }
            else
            {
                stareMachine.TransitionToState(new IdleState(stareMachine));
            }
        }
        else
        {
            if(playerController.GetVerticalVelocity() != 0)
            {
                stareMachine.TransitionToState(new JumpingState(stareMachine));
            }
            else
            {
                stareMachine.TransitionToState(new FallingState(stareMachine));
            }
        }
        
    }

    public class IdleState : PlayerState
    {
        public IdleState(PlayerStateMachine stateMachine) : base(stateMachine) { }
        public override void Update()
        {
            CheckTransitions();
        }
        
    }

    public class MoveingState : PlayerState
    {
        public MoveingState(PlayerStateMachine stateMachine) : base(stateMachine) { }
        public override void Update()
        {
            CheckTransitions();
        }

        public override void FixedUpdate()
        {
            playerController.HandleMovement();
        }
    }

    public class FallingState : PlayerState
    {
        public FallingState(PlayerStateMachine stateMachine) : base(stateMachine) { }
        public override void Update()
        {
            CheckTransitions();
        }

    }

    public class JumpingState : PlayerState
    {
        public JumpingState(PlayerStateMachine stateMachine) : base(stateMachine) { }
        public override void Update()
        {
            CheckTransitions();
        }

    }
}