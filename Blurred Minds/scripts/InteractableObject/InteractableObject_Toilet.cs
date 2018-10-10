using UnityEngine;
using System.Collections;

public class InteractableObject_Toilet : InteractableObject
{
    public GameObject Player;
    public UnityEngine.AI.NavMeshAgent playerNav;
    public GameObject movePos;
    public GameObject rotatePos;
    Animator anim;

    public GameObject Audio;
    public StartMenu_Sounds startSounds;

    bool toiletReached = false;
    bool toiletselected = false;
    Quaternion originalRotation;
    public float rotationSpeed = 2f;

    public ParticleSystem emitter;
    public GameObject toilet;
    public float flushTime = 2F;
    public GameObject flushMessage;

    private Renderer toiletRenderer;

    void start()
    {
  
        emitter = toilet.GetComponent<ParticleSystem>();
        emitter.Stop();
        startSounds = Audio.GetComponent<StartMenu_Sounds>();
    }

    void Update()
    {

        // coffeeRenderer = gameObject.GetComponent<Renderer>();

        if (toiletselected == true)
        {
            playerMoveToToilet();
        }

        if (toiletReached == true)
        {
            //coffeeRenderer.enabled = false;
            startSounds.Flush();
            StartCoroutine(startShower());
            StartCoroutine(showerMessagePlay());
            toiletselected = false;
            toiletReached = false;
        }


    }

    IEnumerator showerMessagePlay()
    {
        flushMessage.SetActive(true);
        yield return new WaitForSeconds(3F);
        flushMessage.SetActive(false);
    }

    IEnumerator startShower()
    {
        emitter = toilet.GetComponent<ParticleSystem>();
        emitter.Play();
        yield return new WaitForSeconds(flushTime);
        emitter.Stop();
    }

    public override void DoAction(string ActionToPerform)
    {
        if (ActionsMatch("Use", ActionToPerform))
        {
            // Debug.Log("drinking Coffee");
            toiletselected = true;
            setDestinationToilet();
            RemoveUI();
            startSounds.Select();
        }

        else
        {
            // Debug.Log("Cancel");
            RemoveUI();
        }
    }

    void playerMoveToToilet()
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
                    toiletReached = true;
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



    void setDestinationToilet()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerNav = Player.GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = Player.GetComponent<Animator>();

        playerNav.SetDestination(movePos.transform.position);

    }


}
