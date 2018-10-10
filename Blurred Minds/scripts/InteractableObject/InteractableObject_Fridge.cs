using UnityEngine;
using System.Collections;

public class InteractableObject_Fridge : InteractableObject
{

    #region public

    public GameObject Player;
    public UnityEngine.AI.NavMeshAgent playerNav;
    Animator anim;
    public GameObject movePos;
    public GameObject[] food;
    public GameObject foodMessage;

    public float messageTime = 2F;

    public StartMenu_Sounds startSounds;

    #endregion public

    bool fridgeActive = false;
    bool fridgeReached = false;
    bool started = false;

    private Transform PlayerTransform;
    private Transform myTransform;

    

    public override void DoAction(string ActionToPerform)
    {
        if (ActionsMatch("Get Food & Drinks", ActionToPerform))
        {
            RemoveUI();
            moveToFridge();
            startSounds.Select();
            fridgeActive = true;
            started = true;
        }

        else
        {
            startSounds.Select();
            RemoveUI();
        }
    }


    void Update()
    {
        if (started == true)
        {
            PlayerTransform = Player.GetComponent<Transform>();

            if (fridgeActive == true)
            {
                walkToFridge();
            }
            if (fridgeReached == true)
            {
                fridgeActive = false;
                Player.transform.LookAt(myTransform);
                fridgeReached = false;
            }
        
            

        }

    }

    void moveToFridge()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerNav = Player.GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = Player.GetComponent<Animator>();
        myTransform = gameObject.GetComponent<Transform>();


        playerNav.SetDestination(movePos.transform.position);
    }


    void walkToFridge()
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
                    fridgeReached = true;
                    InteractableObject_Food.foodEaten = false;
                   foreach (GameObject objects in food)
                    {
                        objects.SetActive(true);
                    }
                    StartCoroutine(FoodReplenishedMessage());
                    startSounds.Select();
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

    IEnumerator FoodReplenishedMessage()
    {
        foodMessage.SetActive(true);
        yield return new WaitForSeconds(messageTime);
        foodMessage.SetActive(false);
    }
}

