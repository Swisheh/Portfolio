using UnityEngine;
using System.Collections;

public class InteractableObject_Alcohol : InteractableObject
{
    public GameObject Player;
    public UnityEngine.AI.NavMeshAgent playerNav;
    Animator anim;
    public GameObject movePos;
    public needs Needs;
    public GameObject ThirstIncreasedDisplay;

    public GameObject Audio;
    public StartMenu_Sounds startSounds;

    //private Renderer alcoholRenderer;
    private bool alcoholReached = false;
    private bool alcoholSelected = false;
    public static int alcoholDrunk = 0;
    public GameObject BACMessage;

    public GameObject TooDrunk;
    public GameObject GameScene;

    SlotMachineDrink newDrink;

    void start()
    {
        startSounds = Audio.GetComponent<StartMenu_Sounds>();
    }

    void Update()
    {

        if (alcoholSelected == true)
        {
            playerMoveToAlcohol();
        }

        if (alcoholReached == true)
        {
            //alcoholRenderer.enabled = false;
            
            startSounds.Drink();
            //Needs.increaseMyThirst();
            //StartCoroutine(IncreaseThirst());
            alcoholSelected = false;
            alcoholReached = false;
            alcoholDrunk++;
            
            
            StartCoroutine(ShowBACMessage());

            SlotMachineDrink[] drinks = PersistentData.GetPlayerStats().GetSlotMachineDrinks();
            SlotMachineDrink[] newDrinks = new SlotMachineDrink[drinks.Length + 1];
            
            newDrink.StandardDrinkEquivalence = 1.5f;

            for (int i = 0; i < drinks.Length; i++)
            {
                newDrinks[i] = drinks[i];
            }
            newDrinks[newDrinks.Length - 1] = newDrink;
            PersistentData.GetPlayerStats().SetSlotMachineDrinks(newDrinks);

            var CheckDrunk = PersistentData.GetPlayerStats().GetCurrentBAC();
            if (CheckDrunk >= 0.3)
            {
                TooDrunk.SetActive(true);
                GameScene.SetActive(false);
            }
            //Debug.Log("BAC after: " + PersistentData.GetPlayerStats().GetCurrentBAC());
        }


    }

    public override void DoAction(string ActionToPerform)
    {
        if (ActionsMatch("Drink Pre-mix 1.5 Standard Drinks", ActionToPerform))
        {
            // Debug.Log("drinking Alcohol");
            alcoholSelected = true;
            DrinkAlcohol();
            RemoveUI();
            startSounds.Select();
        }

        else
        {
            // Debug.Log("Cancel");
            RemoveUI();
        }
    }


    void playerMoveToAlcohol()
    {
        //  alcoholRenderer = gameObject.GetComponent<Renderer>();
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
                    
                    alcoholReached = true;
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

    IEnumerator ShowBACMessage()
    {
        Vector3 drinkPos = this.gameObject.transform.position;
        BACMessage.SetActive(true);
        this.gameObject.transform.position = new Vector3(0.0f, -100f, 0.0f); //shoot it under the map so it cant be used before disappearing
        yield return new WaitForSeconds(2);
        this.gameObject.transform.position = drinkPos; // move it back so it's not under map when replenished
        BACMessage.SetActive(false);
        this.gameObject.SetActive(false);
    }


    void DrinkAlcohol()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerNav = Player.GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = Player.GetComponent<Animator>();

        playerNav.SetDestination(movePos.transform.position);

    }

}




