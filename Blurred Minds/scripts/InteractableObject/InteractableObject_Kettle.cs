using UnityEngine;
using System.Collections;

public class InteractableObject_Kettle : InteractableObject
{
    public GameObject Player;
    public UnityEngine.AI.NavMeshAgent playerNav;
    Animator anim;
    public GameObject movePos;
    public GameObject[] Coffee;

    public float messageTime = 2F;
    public GameObject drinkMessage;


    public GameObject Audio;
    public StartMenu_Sounds startSounds;

    
    private bool KettleReached = false;
    private bool KettleSelected = false;

    void start()
    {
        startSounds = Audio.GetComponent<StartMenu_Sounds>();
    }

    void Update()
    {

        if (KettleSelected == true)
        {
            playerMoveToKettle();
        }

        if (KettleReached == true)
        {
            StartCoroutine(MakeCoffeeCup());
            StartCoroutine(DrinksReplenishedMessage());
            startSounds.Select();
            KettleSelected = false;
            KettleReached = false;
        }


    }

    IEnumerator MakeCoffeeCup()
    {
        startSounds.Kettle();
        yield return new WaitForSeconds(2);
        foreach(GameObject coffeeCups in Coffee)
        {
            coffeeCups.SetActive(true);
        }
       
    }

    IEnumerator DrinksReplenishedMessage()
    {
        drinkMessage.SetActive(true);
        yield return new WaitForSeconds(messageTime);
        drinkMessage.SetActive(false);
    }

    
    public override void DoAction(string ActionToPerform)
    {

        if (ActionsMatch("Make Coffee", ActionToPerform))
        {
            Debug.Log("drinking Coffee");
            KettleSelected = true;
            SetKettleDestination();
            RemoveUI();
            startSounds.Select();
        }


        else
        {
            Debug.Log("Cancel");
            RemoveUI();
        }
    }


    void playerMoveToKettle()
    {
       
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
                    KettleReached = true;
                    anim.SetFloat("walking", 0);

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



    void SetKettleDestination()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerNav = Player.GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = Player.GetComponent<Animator>();

        playerNav.SetDestination(movePos.transform.position);

    }

}
