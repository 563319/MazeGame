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
        enemy.anim.SetBool("isDefault", true);
        enemy.anim.SetBool("isAttacking", false);
    }

    public override void Exit()
    {
        base.Exit();
    }



    public override void Update()
    {
        //chase player
        //if player in attack radius change animation 

        //enemy.anim.SetBool("isDefault", true);
        //enemy.anim.SetBool("isAttacking", false);
        
        //if player not in agro radius go to patrol
    }

    public override void OnTriggerEnter(Collider collision)
    {

    }

    public override void FixedUpdate()
    {
    }
}