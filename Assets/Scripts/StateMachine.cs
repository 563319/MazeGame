using Unity.IO.LowLevel.Unsafe;
using UnityEngine;


//Handles initialisation of states, switching of states
//It handles calling Update and FixedUpdate for the currently active state

public class StateMachine
{
    public State currentState, lastState;

    //declare all states here
    //public IdleState idleState;
    //public AttackState attackState;
    //public PatrolState patrolState;

    //player states
    public PlayerIdleState playerIdleState;
    public PlayerRunState playerRunState;
    public PlayerDeadState playerDeadState;
    public PlayerWinState playerWinState;
    //public PlayerRunState playerRunState;
    //enemy states
    public EnemyIdleState enemyIdleState;
    public EnemyPatrolState enemyPatrolState;
    public EnemyAttackState enemyAttackState;

    //constructor
    public StateMachine(EnemyScript enemy)            //enemy
    {
        //initialise all states here
        //idleState = new IdleState(enemy, this);
        //attackState = new AttackState(enemy, this);
        //patrolState = new PatrolState(enemy, this);

        enemyIdleState = new EnemyIdleState(enemy, this);
        enemyPatrolState = new EnemyPatrolState(enemy, this);
        enemyAttackState = new EnemyAttackState(enemy, this);

    }
    public StateMachine(PlayerScript player)         //player
    {
        //initialise all states here
        //idleState = new IdleState(enemy, this);
        //attackState = new AttackState(enemy, this);
        //patrolState = new PatrolState(enemy, this);

        playerIdleState = new PlayerIdleState(player, this);
        playerRunState = new PlayerRunState(player, this);
        playerDeadState = new PlayerDeadState(player, this);
        playerWinState = new PlayerWinState(player, this);
    }

    public void Init(State startingState)
    {
        currentState = startingState;
        lastState = null;
        startingState.Enter();
    }

    public void ChangeState(State newState)
    {
        currentState.Exit();

        lastState = currentState;
        currentState = newState;
        newState.Enter();
    }

    public void Update()
    {
        currentState.Update();
    }

    public void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

}