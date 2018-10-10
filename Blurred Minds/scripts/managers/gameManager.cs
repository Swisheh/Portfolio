using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    private levelLoader Loader;
    private timeManager timeMan;
    private EventManager EventDispatcher;

    public static gameManager instance = null;

    //Singletons, yay!
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
        Loader = GetComponent<levelLoader>();
        timeMan = GetComponent<timeManager>();
        EventDispatcher = GetComponent<EventManager>();

        BindToEvents();

        //PreLoadInitialiseGame();
        PostLoadInitialiseGame();
    }
	
    void BindToEvents()
    {
        //EventManager.OnMainGameStarted += StartMainGame;
    }

    public void StartMainGame()
    {
        //Debug.Log("Main game started");
        if (timeMan)
        {
            timeMan.StartGameTime();
        }

        EventDispatcher.CallOnMainGameStarted();
    }

    private void PreLoadInitialiseGame()
    {
        LoadLevels();
    }

    public void PostLoadInitialiseGame()
    {
        EventDispatcher.CallLevelLoadFinished(true);
        EventDispatcher.CallOnSlotMachineStarted();

        
    }

    private void LoadLevels()
    {
        if (Loader)
        {
            EventManager.CallLevelLoadStarted();
            Loader.BeginLoad();
            
        }
        else
        {
            EventDispatcher.CallLevelLoadFinished(false);
        }
    }

    public void SlotMachineFinished()
    {
        EventDispatcher.CallOnSlotMachineFinished();
        ConfigureGameInitialState();
    }

    //The slot machine has done it's thing, now we'll set up those variables before the game starts
    private void ConfigureGameInitialState()
    {
        //Set game time to start time + drinking period.

        GameTime StartingTime = new GameTime(18, 0);
        GameTime DrinkingDuration = PersistentData.GetPlayerStats().GetSlotMachineDrinkingPeriod();

        timeManager.SetGameStartingTime(StartingTime + DrinkingDuration);

        //timeManager.SetGameStartingTime(PersistentData.GetPlayerStats().GetSlotMachineDrinkingPeriod() + timeManager.instance.StartGameTime )

        //Set player BAC to peak BAC - metabolised time.

        //EventDispatcher.CallOnSlotMachineStarted();
        EventDispatcher.CallOnMainGameInitialised();
    }

    

}
