using UnityEngine;
using System.Collections;

public class InteractableObject_Food : InteractableObject
{

    public GameObject Player;
    public UnityEngine.AI.NavMeshAgent playerNav;
    Animator anim;
    public GameObject movePos;
    public GameObject foodObject;
    public needs Needs;
    public GameObject hungerIncreasedDisplay;

    public GameObject Audio;
    public StartMenu_Sounds startSounds;

    public static int foodCount;

  
    private bool foodReached = false;
    private bool foodSelected = false;
    public static bool foodEaten = false;

    void start()
    {
        startSounds = Audio.GetComponent<StartMenu_Sounds>();
    }

    void Update()
    {
        if (foodSelected == true)
        {
            playerMoveToFood();
        }

        if (foodReached == true)
        {
            //coffeeRenderer.enabled = false;
            foodEaten = true;
            //startSounds.Drink();
            Needs.increaseMyHunger();
            StartCoroutine(hungerIncreased());
            foodSelected = false;
            foodReached = false;
            foodCount++;
        }

        if(foodEaten==false)
        {
            this.foodObject.gameObject.SetActive(true);
        }


    }

    IEnumerator hungerIncreased()
    {
        Vector3 foodPos = this.gameObject.transform.position;
        hungerIncreasedDisplay.SetActive(true);
        this.gameObject.transform.position = new Vector3(0.0f, -100f, 0.0f); //shoot it under the map so it cant be used before disappearing
        yield return new WaitForSeconds(1);
        this.gameObject.transform.position = foodPos; // move it back so it's not under map when replenished
        this.foodObject.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        hungerIncreasedDisplay.SetActive(false);
    }

    public override void DoAction(string ActionToPerform)
    {
        if (ActionsMatch("Eat Food", ActionToPerform))
        {
            // Debug.Log("drinking Coffee");
            foodSelected = true;
            EatFood();
            RemoveUI();
            //startSounds.Select();
        }

        else
        {
            // Debug.Log("Cancel");
            RemoveUI();
        }
    }


    void playerMoveToFood()
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
                    foodReached = true;
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



    void EatFood()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerNav = Player.GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = Player.GetComponent<Animator>();

        playerNav.SetDestination(movePos.transform.position);

    }
}
