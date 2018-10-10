using UnityEngine;
using System.Collections;

public class InteractableObject_DanceFloor : InteractableObject
{

    public GameObject Player;
    public UnityEngine.AI.NavMeshAgent playerNav;
    Animator anim;
    public GameObject movePos;
    public needs Needs;
    public GameObject FunIncreasedDisplay;

    public static int DancePerformed;

    public GameObject Audio;
    public StartMenu_Sounds startSounds;

    //private Renderer coffeeRenderer;
    private bool DanceFloorReached = false;
    private bool DanceFloorSelected = false;

    void start()
    {
        startSounds = Audio.GetComponent<StartMenu_Sounds>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {


        if (DanceFloorSelected == true)
        {
            playerMoveToDanceFloor();
        }

        if (DanceFloorReached == true)
        {
            //Needs.increaseMyFun();
            //StartCoroutine(IncreaseFun());
            StartCoroutine(DanceForSeconds());
            DanceFloorSelected = false;
            DanceFloorReached = false;
        }


    }

    IEnumerator IncreaseFun()
    {
        FunIncreasedDisplay.SetActive(true);
        yield return new WaitForSeconds(1);
        FunIncreasedDisplay.SetActive(false);
        DancePerformed++;
    }

    IEnumerator DanceForSeconds()
    {
        anim.SetFloat("dancing", 1);
        yield return new WaitForSeconds(6);
        anim.SetFloat("dancing", 0);
    }

    public override void DoAction(string ActionToPerform)
    {
        if (ActionsMatch("Dance", ActionToPerform))
        {
            // Debug.Log("drinking Coffee");
            DanceFloorSelected = true;
            GoToDanceFloorPos();
            RemoveUI();
            startSounds.Select();
        }

        else
        {
            // Debug.Log("Cancel");
            RemoveUI();
        }
    }


    void playerMoveToDanceFloor()
    {
        //  coffeeRenderer = gameObject.GetComponent<Renderer>();
        Player = GameObject.FindGameObjectWithTag("Player");
        playerNav = Player.GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = Player.GetComponent<Animator>();

        // Check if we've reached the destination
        if (!playerNav.pathPending)
        {
            if (playerNav.remainingDistance <= playerNav.stoppingDistance)
            {
                if (!playerNav.hasPath || playerNav.velocity.sqrMagnitude == 0f)
                {
                    //Debug.Log("Destination not reached yet");
                    DanceFloorReached = true;
                    anim.SetFloat("walking", 0);
                    
                    GameFlowManager GameFlowManager = GameObject.Find("GameFlowManager").GetComponent<GameFlowManager>();
                    GameFlowManager.MoveFromGameToMFDancer();
                    // Done
                }
            }
        }

        if (playerNav.velocity.sqrMagnitude > 0.2f)
        {
            //Debug.Log("player is moving");
            anim.SetFloat("walking", 1);
        }

    }



    void GoToDanceFloorPos()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerNav = Player.GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = Player.GetComponent<Animator>();

        playerNav.SetDestination(movePos.transform.position);

    }

}
