//This is the base class 
// It defines the common methods and fields that all other states inherit
// You can include methods that you want to allow other states to use here

using UnityEngine;
using UnityEngine.AI;

public abstract class State
{
    protected EnemyScript enemy;
    protected PlayerScript player;
    protected StateMachine sm;

    //player vars
    public GameObject cineCam;
    public GameObject plrObj;
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
        this.cineCam = GameObject.FindWithTag("CineCam");
        this.plrObj = GameObject.FindWithTag("Player");
        // this.anim = enemy.GetComponentInChildren<Animator>();
        //this.nav = enemy.GetComponent<NavMeshAgent>();
        
    }
    

    //methods that can be overriden by each state
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void Exit() { }
    public virtual void OnCollisionEnter(Collision collision) { }
    public virtual void OnTriggerEnter(Collider collision) { }
    public virtual void OnTriggerExit(Collider collision) { }

    //Common Shared Methods
    //Put methods that you wish to share between other states here
    //Set them to be public


    
}