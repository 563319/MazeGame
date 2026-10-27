//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEditor.Search;
using UnityEngine;

public class PlayerWinState : State
{
    //running speed var for example

    public PlayerWinState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log(" player entering win state");
    }

    public override void Exit()
    {
        base.Exit();
    }



    public override void Update()
    {
        player.gm.playerHasWon = true;
        //display win text
        player.winText.SetActive(true);
        //show button to return to menu 
        player.menuButton.SetActive(true);
        //show button to restart
        player.restartButton.SetActive(true);

        //win sound
    }

    public override void OnTriggerEnter(Collider collision)
    {

    }

    public override void FixedUpdate()
    {
    }

}