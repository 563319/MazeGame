//This is a derived class of State
//This means it inherits fields and methods from State.cs

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

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
        PlayerTorchUpdate();
        //movement
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
        
        if (direction.magnitude < 0.1f)
        {
            sm.ChangeState(sm.playerIdleState);
        }
        if (player.gm.lives < 1)
        {
            sm.ChangeState(sm.playerDeadState);
        }
        if (player.gm.totalCollected >= 244+2)
        {
            sm.ChangeState(sm.playerWinState);
        }

        //Debug.Log("run state");
    }

    public override void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Dot"))
        {
            Debug.Log("collided with dot");
            player.gm.score += 10;
            player.gm.totalCollected += 1;
            GameObject.Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Pellet"))
        {
            Debug.Log("collided with pellet");
            player.gm.score += 50;
            player.gm.totalCollected += 1;
            GameObject.Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //enemy damage player
            Debug.Log("hit enemy (run)");
            player.gm.lives -= 1;
            player.plr.GetComponent<CharacterController>().enabled = false;
            player.plr.transform.position = player.spawnPos;
            player.plr.GetComponent<CharacterController>().enabled = true;
            //player.enemyObj.transform.position = player.enemySpawnPoint;
            player.enemyObj.GetComponent<NavMeshAgent>().Warp(player.enemySpawnPoint);
            //do red flash
        }
    }
    /*
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //enemy damage player
            Debug.Log("hit enemy");
            player.gm.lives -= 1;
            player.plr.transform.position = player.spawnPos;
            //do red flash
        }
    }
    */
    

    public override void FixedUpdate()
    {
    }
    

}