//This is a derived class of State
//This means it inherits fields and methods from State.cs

using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPatrolState : State
{
    //running speed var for example

    public EnemyPatrolState(EnemyScript enemy, StateMachine sm) : base(enemy, sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("enemy entering patrol state");
        enemy.anim.SetBool("isDefault", true);
        enemy.anim.SetBool("isAttacking", false);
    }

    public override void Exit()
    {
        base.Exit();
    }



    public override void Update()
    {
        //Debug.Log("remainingDistance: " + enemy.nav.remainingDistance);
        //look around for the player randomly
        //i need to add loads of points around the level and put them in an array and choose one at random if a path can made then set the destination to it
        if (!enemy.nav.pathPending && enemy.nav.remainingDistance < 0.5f)
        {
            GoToRandomPoint();
        }

        //if player in agro radius go to attack (sees the player)
        if (AgroSphereCast() == true)
        {
            sm.ChangeState(sm.enemyAttackState);
        }
        //enemy.nav.destination = player.plr.transform.position;
        if (enemy.gm.playerHasWon == true)
        {
            sm.ChangeState(sm.enemyIdleState);
        }
        if (enemy.gm.playerHasLost == true)
        {
            sm.ChangeState(sm.enemyIdleState);
        }
    }

    public override void OnTriggerEnter(Collider collision)
    {

    }

    public override void FixedUpdate()
    {
    }
}