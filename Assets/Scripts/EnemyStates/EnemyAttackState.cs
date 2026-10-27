//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;
using UnityEngine.UI;

public class EnemyAttackState : State
{
    //running speed var for example

    public EnemyAttackState(EnemyScript enemy, StateMachine sm) : base(enemy, sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("enemy entering attack state");
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
        //chase player
        enemy.nav.destination = enemy.plr.transform.position;
        //if player in attack radius change animation 
        if (AttackSphereCast() == true)
        {
            enemy.anim.SetBool("isDefault", false);
            enemy.anim.SetBool("isAttacking", true);
        }
        if (AttackSphereCast() == false)
        {
            enemy.anim.SetBool("isDefault", true);
            enemy.anim.SetBool("isAttacking", false);
        }
        
        //if player not in agro radius go to patrol
        if (AgroSphereCast() == false)
        {
            sm.ChangeState(sm.enemyPatrolState);
        }
        if (enemy.gm.playerHasWon == true)
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