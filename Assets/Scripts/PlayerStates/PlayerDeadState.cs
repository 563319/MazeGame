

//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;

public class PlayerDeadState : State
{
    //running speed var for example

    public PlayerDeadState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log(" player entering dead state");
    }

    public override void Exit()
    {
        base.Exit();
    }



    public override void Update()
    {
        MainMenuKeyCheck();
        player.gm.playerHasLost = true;
        //show u died text
        player.deathText.SetActive(true);
        //red overlay
        player.deathRedOverlay.SetActive(true);
        //show button to return to menu 
        player.menuButton.SetActive(true);
        //show button to restart
        player.restartButton.SetActive(true);

        //death sound

    }

    public override void OnTriggerEnter(Collider collision)
    {

    }

    public override void FixedUpdate()
    {
    }

}