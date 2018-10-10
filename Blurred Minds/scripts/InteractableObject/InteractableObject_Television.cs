using UnityEngine;
using System.Collections;

public class InteractableObject_Television : InteractableObject
{

    public GameObject television;
    public Texture[] tvtex;
    bool televisionOn = false;
    public GameObject movePos;
    public GameObject Player;
    public UnityEngine.AI.NavMeshAgent playerNav;
    Animator anim;

    private bool RodrigoRacerSelected = false;
    private bool RodrigoRacerReached = false;

    private bool HTVSelected = false;
    private bool HTVReached = false;

    public StartMenu_Sounds startSounds;

    void Update()
    {
        if (RodrigoRacerSelected == true)
        {
            playerMoveToRRacer();
        }

        if (RodrigoRacerReached == true)
        {  
            RodrigoRacerSelected = false;
            RodrigoRacerReached = false;
        }

        if (HTVSelected == true)
        {
            playerMoveToHTV();
        }

        if (HTVReached == true)
        {
            HTVSelected = false;
            HTVReached = false;
        }
    }

    public override void DoAction(string ActionToPerform)
    {
        if (ActionsMatch("Turn On", ActionToPerform))
        {
            if(televisionOn==true)
            {
                Debug.Log("television is already turned on");
                startSounds.Select();
                RemoveUI();
            }
            else if(televisionOn==false)
            {
                Debug.Log("turned Television on");
                turnOn();
                startSounds.Select();
                RemoveUI();
            }
         
        }

        if (ActionsMatch("Turn Off", ActionToPerform))
        {
            if (televisionOn == true)
            {
                Debug.Log("television Turned off");
                turnOff();
                RemoveUI();
                startSounds.Select();
            }
            else if (televisionOn == false)
            {
                Debug.Log("television is already off");
                RemoveUI();
            }

        }

        if (ActionsMatch("Play 'Rodrigo Racer'", ActionToPerform))
        {
            RodrigoRacerSelected = true;
            GoToRodrigoRacer();
            RemoveUI();
        }

        else
        {
            Debug.Log("Cancel");
            RemoveUI();
        }

        if (ActionsMatch("Watch Some TV", ActionToPerform))
        {
            HTVSelected = true;
            GoToHTV();
            RemoveUI();
        }

        else
        {
            Debug.Log("Cancel");
            RemoveUI();
        }
    }

    void turnOn()
    {
        Material mat = television.GetComponentInChildren<Renderer>().material;
        if(televisionOn==false)
        {
            mat.mainTexture = tvtex[0];
            televisionOn = true;
        }
     
    }

    void turnOff()
    {
        Material mat = television.GetComponentInChildren<Renderer>().material;

        if (televisionOn==true)
        {
            televisionOn = false;
            mat.mainTexture = tvtex[1];
        }
    }

    void playerMoveToRRacer()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerNav = Player.GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = Player.GetComponent<Animator>();

        if (!playerNav.pathPending)
        {
            if (playerNav.remainingDistance <= playerNav.stoppingDistance)
            {
                if (!playerNav.hasPath || playerNav.velocity.sqrMagnitude == 0f)
                {
                    //Debug.Log("Destination not reached yet");
                    RodrigoRacerReached = true;
                    anim.SetFloat("walking", 0);

                    GameFlowManager GameFlowManager = GameObject.Find("GameFlowManager").GetComponent<GameFlowManager>();
                    GameFlowManager.MoveFromGameToRRacer();
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

    void GoToRodrigoRacer()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerNav = Player.GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = Player.GetComponent<Animator>();

        playerNav.SetDestination(movePos.transform.position);
    }



    void playerMoveToHTV()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerNav = Player.GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = Player.GetComponent<Animator>();

        if (!playerNav.pathPending)
        {
            if (playerNav.remainingDistance <= playerNav.stoppingDistance)
            {
                if (!playerNav.hasPath || playerNav.velocity.sqrMagnitude == 0f)
                {
                    //Debug.Log("Destination not reached yet");
                    HTVReached = true;
                    anim.SetFloat("walking", 0);

                    GameFlowManager GameFlowManager = GameObject.Find("GameFlowManager").GetComponent<GameFlowManager>();
                    GameFlowManager.MoveFromGameToHTV();
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

    void GoToHTV()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerNav = Player.GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = Player.GetComponent<Animator>();

        playerNav.SetDestination(movePos.transform.position);
    }


}
