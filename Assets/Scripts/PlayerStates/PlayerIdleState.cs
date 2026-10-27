
//This is a derived class of State
//This means it inherits fields and methods from State.cs

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

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
        if (player.gm.totalCollected >= 244+2)
        {
            sm.ChangeState(sm.playerWinState);
        }
        //Debug.Log("Idle state");
    }

    public override void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //enemy damage player
            Debug.Log("hit enemy (idle)");
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