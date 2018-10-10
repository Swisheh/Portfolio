using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InteractableObject : MonoBehaviour
{
    
    public static bool InteractMenuOpen;
    public static bool open;

    //The list of actions that this object can do when clicked on
    public string[] InteractionActions;

    //The ui button element that will be spawned for each action
    public GameObject InteractButtonToSpawn;
  

    //The buttons will be spawned inside this panel.
    //TODO: Move this panel to the approximate location on the screen that the mouse was clicked (like the sims)
    public GameObject InteractionPanelToSpawnIn;
    Image PanelToSpawn;
    //A temporary reference to the instantiated button. This is reused for each button.
    private GameObject SpawnedInteractionButton;

    //A persistent array of spawned buttons so we can destroy them
    private GameObject[] SpawnedButtons;

    //Vector3 mousePositionInWorldPoint;

    // Use this for initialization
    void Start ()
    {
        SpawnedButtons = new GameObject[InteractionActions.Length];
        PanelToSpawn = InteractionPanelToSpawnIn.GetComponent<Image>();
        PanelToSpawn.enabled = false;
    }
   	

    //Create each button for each action
    public void CreateUI()
    {
        InteractableObject.InteractMenuOpen = true;

        for (int i = 0; i < InteractionActions.Length; i++)
        {
            //Create a button and store a reference to it
            SpawnedInteractionButton = (GameObject)Instantiate(InteractButtonToSpawn);
            SpawnedInteractionButton.transform.SetParent(InteractionPanelToSpawnIn.transform, false);
            SpawnedButtons[i] = SpawnedInteractionButton;
            

            //Move it to inside the panel
            RectTransform ButtonTransform = SpawnedInteractionButton.GetComponent<RectTransform>();
            ButtonTransform.transform.localPosition = new Vector3(0f, -30f * i);
           

            //Set the text on the button to the action
            ButtonTransform.gameObject.transform.GetChild(0).GetComponent<Text>().text = InteractionActions[i];

            //Tell the button what function (and action) to call when it's pressed
            string ButtonAction = InteractionActions[i];
            SpawnedInteractionButton.GetComponent<Button>().onClick.AddListener( delegate { DoAction(ButtonAction); });
        }

    }


    public void RemoveUI()
    {
        if (InteractableObject.InteractMenuOpen == true)
        {
            InteractableObject.InteractMenuOpen = false;
            //TODO: Remove UI elements
            foreach (GameObject button in SpawnedButtons)
            {
                if (!button)
                    continue;
                button.SetActive(false);
                button.GetComponent<Button>().onClick.RemoveAllListeners();
                Destroy(button);

            }
            for(int i = 0; i < InteractionPanelToSpawnIn.transform.childCount; i++)
            {
                Destroy(InteractionPanelToSpawnIn.transform.GetChild(i).gameObject);
            }
        }
    
    }

    public virtual void DoAction(string ActionToPerform)
    {
        if (ActionsMatch("ACTION", ActionToPerform))
        {
            Debug.Log("Poop");
            InteractMenuOpen = true;
        }
        else
        {
            Debug.Log("Cancel poop");
            RemoveUI();
            InteractMenuOpen = false;
        }

    }

    public bool ActionsMatch(string _Action, string _ActionToPerform)
    {
        return (_Action.ToLower() == _ActionToPerform.ToLower()) ? true : false;
    }


    public void OnMouseDown()
    {
        //Don't do anything if there's a UI on top of us
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        
        InteractableObject[] AllInteractables = FindObjectsOfType<InteractableObject>();
        foreach (InteractableObject Interactable in AllInteractables)
        {
            Interactable.RemoveUI();
        }
        

        //mousePositionInWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if(InteractableObject.InteractMenuOpen == false)
        {
            CreateUI();
        }

        InteractionPanelToSpawnIn.transform.position = Input.mousePosition + new Vector3(0, -10);



    }



}
