//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;

public class PlayerRunState : State
{
    //running speed var for example

    public PlayerRunState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("player entering run state");
    }

    public override void Exit()
    {
        base.Exit();
    }



    public override void Update()
    {
       // Input.GetAxis("Mouse X") * sensitivity;
        //plrObj.transform.position = Input.GetAxis("Mouse Y") * sensitivity;
        


    }

    public override void OnTriggerEnter(Collider collision)
    {

    }

    public override void FixedUpdate()
    {
    }
}