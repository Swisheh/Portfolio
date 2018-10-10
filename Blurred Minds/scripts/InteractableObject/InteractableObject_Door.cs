using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InteractableObject_Door : InteractableObject
{

    public GameObject Player;
    public UnityEngine.AI.NavMeshAgent playerNav;
    Animator anim;
    public GameObject movePos;

    bool hasStarted = false;

    public override void DoAction(string ActionToPerform)
    {
        if (ActionsMatch("Leave party", ActionToPerform))
        { 
            RemoveUI();
            MoveToDoor();
            hasStarted = true;
        }

        else
        {

            RemoveUI();
        }
    }

    void Update()
    {
        if (hasStarted == true)
        {
            walkToDoor();
        }
      
    }

    void MoveToDoor()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerNav = Player.GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = Player.GetComponent<Animator>();


        playerNav.SetDestination(movePos.transform.position);
    }

    void walkToDoor()
    {

        // Check if we've reached the destination
        if (!playerNav.pathPending)
        {
            if (playerNav.remainingDistance <= playerNav.stoppingDistance)
            {
                if (!playerNav.hasPath || playerNav.velocity.sqrMagnitude == 0f)
                {
                    //Debug.Log("Destination not reached yet");
                    anim.SetFloat("walking", 0);
                    //Application.LoadLevel("blurredMindsGameOver");
                    PersistentData.GetPlayerStats().SetTimeAtGameEnd(timeManager.GetCurrentGameTimeScaled());
                    PersistentData.GetPlayerStats().SetBACAtGameEnd(PersistentData.GetPlayerStats().GetCurrentBAC());


                    //SceneManager.LoadScene("blurredMindsGameOver");
                    // Done
                    GameFlowManager GameFlowManager = GameObject.Find("GameFlowManager").GetComponent<GameFlowManager>();
                    GameFlowManager.MoveFromGameToPostGameScreen();
                }
            }
        }

        if (playerNav.velocity.sqrMagnitude > 0.2f)
        {
            //Debug.Log("player is moving");
            anim.SetFloat("walking", 1);
        }

    }
}





