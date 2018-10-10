using UnityEngine;
using System.Collections;

public class InteractableObject_BeerPong : InteractableObject
{

    public GameObject Player;
    public UnityEngine.AI.NavMeshAgent playerNav;
    Animator anim;
    public GameObject movePos;
    public needs Needs;
    public GameObject FunIncreasedDisplay;

    public GameObject Audio;
    public StartMenu_Sounds startSounds;

    private bool BeerPongReached = false;
    private bool BeerPongSelected = false;

    void start()
    {
        startSounds = Audio.GetComponent<StartMenu_Sounds>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {


        if (BeerPongSelected == true)
        {
            playerMoveToBeerPong();
        }

        if (BeerPongReached == true)
        {
            //Needs.increaseMyFun();
            //StartCoroutine(IncreaseFun());
            
            BeerPongSelected = false;
            BeerPongReached = false;
        }


    }

    IEnumerator IncreaseFun()
    {
        FunIncreasedDisplay.SetActive(true);
        yield return new WaitForSeconds(1);
        FunIncreasedDisplay.SetActive(false);
    }


    public override void DoAction(string ActionToPerform)
    {
        if (ActionsMatch("Play Beer Pong", ActionToPerform))
        {
            Debug.Log("Playing Beer Pong");
            BeerPongSelected = true;
            GoToBeerPongPos();
            RemoveUI();
            //startSounds.Select();
        }

        else
        {
            // Debug.Log("Cancel");
            RemoveUI();
        }
    }


    void playerMoveToBeerPong()
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
                    BeerPongReached = true;
                    anim.SetFloat("walking", 0);

                    GameFlowManager GameFlowManager = GameObject.Find("GameFlowManager").GetComponent<GameFlowManager>();
                    GameFlowManager.MoveFromGameToDrinkToss();
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



    void GoToBeerPongPos()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerNav = Player.GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = Player.GetComponent<Animator>();

        playerNav.SetDestination(movePos.transform.position);

    }

}
