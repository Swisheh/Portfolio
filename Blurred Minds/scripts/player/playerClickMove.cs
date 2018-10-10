using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class playerClickMove : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent navAgent;
    Animator anim;

    private Vector3 viewPos;
    public GameObject waterDrop;
    private GameObject instantiatedObject;
    public float time = 1;

    //public particleSystemDestory destroyMe;
   public StartMenu_Sounds startSounds;

    ParticleSystem water;
    ParticleEmitter waterEmission;

    void Awake()
    {
        GetComponents();
        //water = waterDrop.GetComponent<ParticleSystem>();
    }

    // Use this for initialization
    void Start ()
    {
        GetComponents();
       
       
	}
	
    void GetComponents()
    {
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update ()
    {
        if (!navAgent || !anim)
        {
            GetComponents();
            return;
        }

        MoveToDestination();

        if (InteractableObject.InteractMenuOpen==false)
        {
            if (!GetInput())
                return;

            //Debug.Log("Should move");
            
        }
        else if (InteractableObject.InteractMenuOpen == false)
        {
            anim.SetFloat("walking", 0);
            navAgent.Stop();
        }

        
    }

    private void MoveToDestination()
    {
        // Check if we've reached the destination
        if (!navAgent.pathPending)
        {
            if (navAgent.remainingDistance <= navAgent.stoppingDistance)
            {
                if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f)
                {
                    //Debug.Log("Destination not reached yet");
                    anim.SetFloat("walking", 0);
                    // Done
                }
            }
        }

        if (navAgent.velocity.sqrMagnitude > 0.2f)
        {
            //Debug.Log("player is moving");
            anim.SetFloat("walking", 1);
        }
    }

 

    private bool GetInput()
    {
        if (!EventSystem.current || EventSystem.current.name != "EventSystem_Game")
        {
            EventSystem.current = GameObject.Find("EventSystem_Game").GetComponent<EventSystem>();
        }

        //Don't path if the mouse is over a UI element
        if (EventSystem.current.IsPointerOverGameObject())
            return false;
               
        //TODO: This should use unity's input manager rather than hard coded
        if (Input.GetMouseButtonUp(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Vector3 clickPoint = hit.point;
                clickPoint.y = 0.7f;
                navAgent.SetDestination(clickPoint);
                instantiatedObject = Instantiate(waterDrop, clickPoint, Quaternion.identity);
                //Debug.Log(clickPoint);
                water = instantiatedObject.GetComponent<ParticleSystem>();
                water.Emit(1);
                Destroy(instantiatedObject, time);
            }

            return true;
        }
        else
        {
            return false;
        }
    }
}
