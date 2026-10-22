
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
        Debug.Log(" player entering idle state");
    }

    public override void Exit()
    {
        base.Exit();
    }



    public override void Update()
    {
        /*
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

       
        player.moveDir = new Vector3(horizontal, 0f, vertical);//.normalized;
        player.rb.linearVelocity += player.moveDir * player.moveSpeed * Time.deltaTime;

        Debug.Log("player.rb.linearVelocity: " + player.rb.linearVelocity);
        Debug.Log("player.moveDir  player.moveSpeed " + player.moveDir + player.moveSpeed);

        if (player.rb.linearVelocity.magnitude > 0.1)
        {
            sm.ChangeState(sm.playerRunState);
        }
        */

    }

    public override void OnTriggerEnter(Collider collision)
    {

    }

    public override void FixedUpdate()
    {
    }

}