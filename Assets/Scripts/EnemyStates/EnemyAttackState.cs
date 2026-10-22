//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;

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
        enemy.anim.SetBool("isDefault", false);
        enemy.anim.SetBool("isAttacking", true);
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