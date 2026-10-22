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
        /*
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        

        player.moveDir = new Vector3(horizontal, 0f, vertical);//.normalized;
        player.rb.linearVelocity += player.moveDir * player.moveSpeed * Time.deltaTime;

        Debug.Log("player.rb.linearVelocity: " + player.rb.linearVelocity);
        Debug.Log("player.moveDir  player.moveSpeed " + player.moveDir + player.moveSpeed);
        if (player.rb.linearVelocity.magnitude < 0.1)
        {
            sm.ChangeState(sm.playerIdleState);
        }       
        */
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + player.cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(player.plr.transform.eulerAngles.y, targetAngle, ref player.turnSmoothVelocity, player.turnSmoothTime);
            player.plr.transform.rotation  = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            player.controller.Move(moveDir.normalized * player.speed * Time.deltaTime);

        }
        


 
    }

    public override void OnTriggerEnter(Collider collision)
    {

    }

    public override void FixedUpdate()
    {
    }

}