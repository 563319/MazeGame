
//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;

public class PlayerIdleState : State
{
    //running speed var for example

    public PlayerIdleState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("entering idle state");
    }

    public override void Exit()
    {
        base.Exit();
    }



    public override void Update()
    {



    }

    public override void OnTriggerEnter(Collider collision)
    {

    }

    public override void FixedUpdate()
    {
    }
}