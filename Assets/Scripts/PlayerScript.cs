using Unity.AI.Navigation.LowLevel;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    StateMachine sm;

    public GameManagerData gm;
    public Transform cam;
    public float speed = 6f;
    //public Rigidbody rb;
    public CharacterController controller;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    public GameObject plr;
    public GameObject torch;
    public bool torchIsOn;
    
    //public Vector3 moveDir;

    void Start()
    {
        sm = new StateMachine(this); //"this" means - pass a reference of this script (player script) to the statemachine
        sm.Init(sm.playerIdleState); //this will be the first state to run
        //sm.Init(sm.playerRunState);
        //Cursor.lockState = CursorLockMode.Locked;
        gm.score = 0;
        
    }
    private void Update()
    {
        sm.Update();
    }

    void FixedUpdate()
    {
        sm.FixedUpdate();
        //below code needs to be moved

    }
    //add your additional collision handling here
    void OnCollisionEnter(Collision collision)
    {
        sm.currentState.OnCollisionEnter(collision);
    }
    void OnTriggerEnter(Collider collision)
    {
        sm.currentState.OnTriggerEnter(collision);
    }
    void OnTriggerExit(Collider collision)
    {
        sm.currentState.OnTriggerExit(collision);
    }
}
