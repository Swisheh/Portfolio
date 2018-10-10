using UnityEngine;
using System.Collections;

public class InteractableObject_Shower : InteractableObject
{
    public GameObject Player;
    public UnityEngine.AI.NavMeshAgent playerNav;
    Animator anim;
    public GameObject movePos;
    // public needs Needs;
    // public GameObject ThirstIncreasedDisplay;

    public GameObject Audio;
    public StartMenu_Sounds startSounds;
    private bool showerReached = false;
    private bool showerSelected = false;

    public float showerTime = 4f;
    public GameObject shower;
    public GameObject showerMessage;
    ParticleSystem emitter;

    void start()
    {
        emitter = shower.GetComponent<ParticleSystem>();
        emitter.Stop();
        startSounds = Audio.GetComponent<StartMenu_Sounds>();
    }

    void Update()
    {

        // coffeeRenderer = gameObject.GetComponent<Renderer>();

        if (showerSelected == true)
        {
            playerMoveToShower();
        }

        if (showerReached == true)
        {
            //coffeeRenderer.enabled = false;

            StartCoroutine(startShower());
            StartCoroutine(showerMessagePlay());
            showerSelected = false;
            showerReached = false;
        }


    }

    IEnumerator showerMessagePlay()
    {
        showerMessage.SetActive(true);
        yield return new WaitForSeconds(3F);
        showerMessage.SetActive(false);
    }

    IEnumerator startShower()
    {
        emitter = shower.GetComponent<ParticleSystem>();
        emitter.Play();
        yield return new WaitForSeconds(showerTime);
        emitter.Stop();
    }

    public override void DoAction(string ActionToPerform)
    {
        if (ActionsMatch("Take Shower", ActionToPerform))
        {
            // Debug.Log("drinking Coffee");
            showerSelected = true;
            setDestinationShower();
            RemoveUI();
            startSounds.Select();
        }

        else
        {
            // Debug.Log("Cancel");
            RemoveUI();
        }
    }

    void playerMoveToShower()
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
                    showerReached = true;
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



    void setDestinationShower()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerNav = Player.GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = Player.GetComponent<Animator>();

        playerNav.SetDestination(movePos.transform.position);

    }
}
