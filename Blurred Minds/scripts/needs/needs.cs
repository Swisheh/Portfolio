using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class needs : MonoBehaviour
{
    #region needs

    //needs
    public int hunger = 100;
    public int fun = 100;
    public int thirst = 100;

    public float decreaseRate = 1F;

    bool IsActive = false;

    public static bool hungerZero = false;
    public static bool funZero = false;
    public static bool thirstZero = false;

    public static bool needsZero = false;

    #endregion needs

    #region sliders

    public Slider thirstBar;
    public Slider HungerBar;
    public Slider funBar;

    public GameObject transitionScreen;
    public Image transition;
    Color finalColor;
    public float transitionTime = 10;

    #endregion sliders

    public GameObject funDisplay;

    bool resumed;
    public GameObject FoodDeath;
    public GameObject ThirstDeath;
    public GameObject FunDeath;
    public GameObject GameScene;
    // Use this for initialization
    public void Start ()
    {
        IsActive = false;
        EventManager.OnMainGameStarted += startNeeds;

        hungerZero = false;
        thirstZero = false;
        needsZero = false;
        funZero = false;

        transitionScreen.SetActive(false);
        //Decrease needs over time


    }

    void OnDestroy()
    {
        //Make sure we unbind from the event if this script is being destroyed
        EventManager.OnMainGameStarted -= startNeeds;
    }

    void startNeeds()
    {
        IsActive = true;
    }


    // Update is called once per frame
    void Update ()
    {

        if(IsActive==true)
        {
            InvokeRepeating("thirstDecrease", 2, decreaseRate);
            InvokeRepeating("funDecrease", 2, decreaseRate);
            InvokeRepeating("hungerDecrease", 2, decreaseRate);
            IsActive = false;
        }

         //defining values of sliders
       thirstBar.value = thirst;
       HungerBar.value = hunger;
       funBar.value = fun;

        if(hunger <= 0)
        {
            needsZero = true;
            /*
            //game over
            PersistentData.GetPlayerStats().SetTimeAtGameEnd(timeManager.GetCurrentGameTimeScaled());
            PersistentData.GetPlayerStats().SetBACAtGameEnd(PersistentData.GetPlayerStats().GetCurrentBAC());
            GameFlowManager GameFlowManager = GameObject.Find("GameFlowManager").GetComponent<GameFlowManager>();
            GameFlowManager.MoveFromGameToPostGameScreen();
            needsZero = true;
            */
            //StartCoroutine(EndGameTransitionScreen());
            GameScene.SetActive(false);
            FoodDeath.SetActive(true);
        }
        if (fun <= 0)
        {
            needsZero = true;
            /*
            //game over
            PersistentData.GetPlayerStats().SetTimeAtGameEnd(timeManager.GetCurrentGameTimeScaled());
            PersistentData.GetPlayerStats().SetBACAtGameEnd(PersistentData.GetPlayerStats().GetCurrentBAC());
            GameFlowManager GameFlowManager = GameObject.Find("GameFlowManager").GetComponent<GameFlowManager>();
            GameFlowManager.MoveFromGameToPostGameScreen();
            needsZero = true;
            */
            //StartCoroutine(EndGameTransitionScreen());
            GameScene.SetActive(false);
            FunDeath.SetActive(true);
        }
        if (thirst <= 0)
        {
            needsZero = true;
            /*
            //game over
            PersistentData.GetPlayerStats().SetTimeAtGameEnd(timeManager.GetCurrentGameTimeScaled());
            PersistentData.GetPlayerStats().SetBACAtGameEnd(PersistentData.GetPlayerStats().GetCurrentBAC());
            GameFlowManager GameFlowManager = GameObject.Find("GameFlowManager").GetComponent<GameFlowManager>();
            GameFlowManager.MoveFromGameToPostGameScreen();
            needsZero = true;
            */
            //StartCoroutine(EndGameTransitionScreen());
            GameScene.SetActive(false);
            ThirstDeath.SetActive(true);
        }

        //printing values
        // Debug.Log(string.Format("thirst is at" + thirst));
        // Debug.Log(string.Format("fun is at" + fun));
    }

    IEnumerator EndGameTransitionScreen()
    {
        transitionScreen.SetActive(true);
        //transition.GetComponent<CanvasRenderer>().SetAlpha(0.1f);
        //transition.CrossFadeAlpha(100, Time.time * transitionTime, true);
        //transitionScreen.SetActive(false);
        yield return new WaitForSeconds(transitionTime);
        PersistentData.GetPlayerStats().SetTimeAtGameEnd(timeManager.GetCurrentGameTimeScaled());
        PersistentData.GetPlayerStats().SetBACAtGameEnd(PersistentData.GetPlayerStats().GetCurrentBAC());
        GameFlowManager GameFlowManager = GameObject.Find("GameFlowManager").GetComponent<GameFlowManager>();
        GameFlowManager.MoveFromGameToPostGameScreen();
        
    }


    #region decreasingNeeds

    void thirstDecrease()
    {
        if(thirst>0)
        {
            thirst-=1;
        }
    }

    void hungerDecrease()
    {
        if(hunger>0)
        {
            hunger -= 1;
        }
    }

    void funDecrease()
    {
        if(fun>0)
        {
            fun -= 1;
        }
    }

    #endregion decreasingNeeds


    #region increasingNeeds

    IEnumerator increaseFun()
    {
        if(fun<100)
        {
            fun += 10;
            funBar.value = fun;
            funDisplay.SetActive(true);

        }
        yield return new WaitForSeconds(1);
        funDisplay.SetActive(false);
    
    }

    public void increaseMyFun()
    {
        StartCoroutine(increaseFun());
    }

    #endregion increasingNeeds

    #region increasingThirst

    IEnumerator increaseThirst()
    {
        if(thirst<100)
        {
            thirst += 25;
            thirstBar.value = thirst;
        }
        yield return new WaitForSeconds(1);
    }

    public void increaseMyThirst()
    {
        StartCoroutine(increaseThirst());
    }

    #endregion increasingThirst

    public void increaseMyHunger()
    {
        StartCoroutine(increaseHunger());
    }

    IEnumerator increaseHunger()
    {
        if(hunger<100)
        {
            hunger += 40;
            HungerBar.value = hunger;
        }
        yield return new WaitForSeconds(1);
    }

}
