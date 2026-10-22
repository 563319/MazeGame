//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;

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



    }

    public override void OnTriggerEnter(Collider collision)
    {

    }

    public override void FixedUpdate()
    {
    }
}