
//This is a derived class of State
//This means it inherits fields and methods from State.cs

using Unity.VisualScripting;
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
        Debug.Log(" player entering idle state");
    }

    public override void Exit()
    {
        base.Exit();
    }



    public override void Update()
    {
        PlayerTorchUpdate();
        //test for input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            sm.ChangeState(sm.playerRunState);
        }
        if (player.gm.lives < 1)
        {
            sm.ChangeState(sm.playerDeadState);
        }
        if (player.gm.totalCollected >= 244)
        {
            sm.ChangeState(sm.playerWinState);
        }
        //Debug.Log("Idle state");
    }

    public override void OnTriggerEnter(Collider collision)
    {

    }

    public override void FixedUpdate()
    {
    }

}