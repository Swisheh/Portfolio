using UnityEngine;
using System.Collections;

public class InteractableObject_Coffee : InteractableObject
{
    public GameObject Player;
    public UnityEngine.AI.NavMeshAgent playerNav;
    Animator anim;
    public GameObject movePos;
    public needs Needs;
    public GameObject ThirstIncreasedDisplay;

    public GameObject Audio;
    public StartMenu_Sounds startSounds;
 

    //private Renderer coffeeRenderer;
    private bool coffeeReached = false;
    private bool coffeeSelected = false;
    public static int coffeeDrunk = 0;

    void start()
    {
        startSounds = Audio.GetComponent<StartMenu_Sounds>();
    }

    void Update()
    {

       // coffeeRenderer = gameObject.GetComponent<Renderer>();

        if(coffeeSelected == true)
        {
            playerMoveToCoffee();
        }

        if (coffeeReached == true)
        {
            //coffeeRenderer.enabled = false;
            
            startSounds.Drink();
            Needs.increaseMyThirst();
            StartCoroutine(IncreaseThirst());
            coffeeSelected = false;
            coffeeReached = false;
            coffeeDrunk++;
        }


    }

    IEnumerator IncreaseThirst()
    {
        Vector3 drinkPos = this.gameObject.transform.position;
        ThirstIncreasedDisplay.SetActive(true);
        this.gameObject.transform.position = new Vector3(0.0f, -100f, 0.0f); //shoot it under the map so it cant be used before disappearing
        yield return new WaitForSeconds(1);
        this.gameObject.transform.position = drinkPos; // move it back so it's not under map when replenished
        ThirstIncreasedDisplay.SetActive(false);
        this.gameObject.SetActive(false);

    }

    public override void DoAction(string ActionToPerform)
    {
        if (ActionsMatch("Drink", ActionToPerform))
        {
           // Debug.Log("drinking Coffee");
            coffeeSelected = true;
            DrinkCoffee();
            RemoveUI();
            startSounds.Select();
        }

        else
        {
           // Debug.Log("Cancel");
            RemoveUI();
        }
    }


    void playerMoveToCoffee()
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
                    coffeeReached = true;
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



    void DrinkCoffee()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerNav = Player.GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = Player.GetComponent<Animator>();

        playerNav.SetDestination(movePos.transform.position);

    }

}




