//This is the base class 
// It defines the common methods and fields that all other states inherit
// You can include methods that you want to allow other states to use here

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public abstract class State
{
    protected EnemyScript enemy;
    protected PlayerScript player;
    protected StateMachine sm;
    
    //player vars
  
    //enemy vars

    // base constructor
    public State(EnemyScript enemy, StateMachine sm)
    {
        this.enemy = enemy;
        this.sm = sm;
        //this.anim = enemy.GetComponentInChildren<Animator>();
       // this.nav = enemy.GetComponent<NavMeshAgent>();
    }
    //player version
    public State(PlayerScript player, StateMachine sm)
    {
        this.player = player;
        this.sm = sm;
        
        // this.anim = enemy.GetComponentInChildren<Animator>();
        //this.nav = enemy.GetComponent<NavMeshAgent>();
        
    }
    

    //methods that can be overriden by each state
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void LateUpdate() { }
    public virtual void FixedUpdate() { }
    public virtual void Exit() { }
    public virtual void OnCollisionEnter(Collision collision) { }
    public virtual void OnTriggerEnter(Collider collision) { }
    public virtual void OnTriggerExit(Collider collision) { }

    //Common Shared Methods
    //Put methods that you wish to share between other states here
    //Set them to be public
    public void GoToRandomPoint()
    {
        //enemy.destPoint
        if (enemy.points.Count == 0)
        {
            return;
        }
        
        int item = Random.Range(0, enemy.points.Count);
        enemy.destPoint = enemy.points[item];
        enemy.nav.destination = enemy.destPoint.position;



    }
    public bool AgroSphereCast()
    {
        /*
        if (Physics.SphereCast(enemy.transform.position, enemy.agroRadius, Vector3.zero, out RaycastHit hit, 0 ))
        {
            
        }
        */
        if (Physics.CheckSphere(enemy.transform.position, enemy.agroRadius, LayerMask.GetMask("Player")))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool AttackSphereCast()
    {
        /*
        if (Physics.SphereCast(enemy.transform.position, enemy.agroRadius, Vector3.zero, out RaycastHit hit, 0 ))
        {
            
        }
        */
        if (Physics.CheckSphere(enemy.transform.position, enemy.agroRadius, LayerMask.GetMask("Player")))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    
}