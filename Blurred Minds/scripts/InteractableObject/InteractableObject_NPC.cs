using UnityEngine;
using System.Collections;

public class InteractableObject_NPC : InteractableObject
{
    #region public

    public GameObject Player;
    public UnityEngine.AI.NavMeshAgent playerNav;
    Animator anim;
    public GameObject movePos;
    public float rotationSpeed = 2f;
    public GameObject FunIncreasedDisplay;

    public needs Needs;
    public StartMenu_Sounds startSounds;

    #endregion public

    //stores original rotation of NPC before he/she talks to player
    Quaternion originalRotation;


    Animator NPCAnim;

    bool NPC_active = false;
    bool NPC_Reached = false;
    bool restoreRotation = false;
    bool started = false;

    private Transform PlayerTransform;
    private Transform myTransform;

    public override void DoAction(string ActionToPerform)
    {
        if (ActionsMatch("Talk", ActionToPerform))
        {
            Debug.Log("Left the party");
            RemoveUI();
            MoveToNPC();
            startSounds.Select();
            NPC_active = true;
            started = true;
        }

        else
        {
            startSounds.Select();
            Debug.Log("Cancel");
            RemoveUI();
        }
    }


    void Update()
    {
        if(started==true)
        {
            PlayerTransform = Player.GetComponent<Transform>();
            NPCAnim = gameObject.GetComponent<Animator>();

            if (NPC_active == true)
            {
                walktoNPC();
            }
            if (NPC_Reached == true)
            {
                NPC_active = false;
                Player.transform.LookAt(myTransform);
                StartCoroutine("talkToNPC");
                startSounds.talk();
                NPC_Reached = false;
                //Debug.Log("start coroutine talking to NPC");
            }
            if (restoreRotation == true)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, Time.deltaTime * rotationSpeed);
                if (transform.rotation == originalRotation)
                {
                    restoreRotation = false;
                }
            }

        }

    }

    void MoveToNPC()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerNav = Player.GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = Player.GetComponent<Animator>();
        originalRotation = transform.rotation;
        myTransform = gameObject.GetComponent<Transform>();


        playerNav.SetDestination(movePos.transform.position);
    }
    
    IEnumerator talkToNPC()
    {

        //rotate NPC to player and play their talking animation for 5 seconds and then stop.
        //while talking increase "fun" player is having.
        Needs.increaseMyFun();
        StartCoroutine(funIncreasedDisplay());
        gameObject.transform.LookAt(PlayerTransform);
        NPCAnim.SetFloat("talking", 1);
        yield return new WaitForSeconds(5);
        NPCAnim.SetFloat("talking", 0);
        restoreRotation = true;
        yield break;
    }   

    IEnumerator funIncreasedDisplay()
    {
        FunIncreasedDisplay.SetActive(true);
        yield return new WaitForSeconds(1);
        FunIncreasedDisplay.SetActive(false);
    }

    void walktoNPC()
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
                    NPC_Reached = true;
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
}
