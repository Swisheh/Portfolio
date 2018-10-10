using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGameBACCheck : MonoBehaviour
{
    //this class will check what the Player's BAC was and if it was Zero when they left the party. Then It'll give feedback. 
    float EndingBAC;
    public GameObject BACWIN;
    public GameObject BACLOSE;
    public GameObject BACTooHigh;
    public GameObject FunTooLow;
    //public GameObject needsZero;
    public GameObject ThirstTooLow;
    public GameObject RoadDeath;
    public GameObject FireDeath;
    public GameObject evaluationstuff;
    public GameObject CrystalDeath;

    bool forceTrue = true;

    public GameObject tipBox;
    public GameObject bacZeroTip;

    bool tipBoxOpen = false;


    public Text EndBacText;
    public GameObject EndBacInput;

    #region coffeeTextTip
    public Text CoffeeText;
    public GameObject textInput;
    public GameObject CoffeeTip;
    #endregion coffeeTextTip

    #region foodTips
    public Text foodText;
    public GameObject foodTextInput;
    public GameObject FoodTip;
    #endregion foodtips;

    public Text danceText;
    public GameObject danceTextInput;


    bool checkBAC = false;

    public StartMenu_Sounds Music;

    // Use this for initialization
    void Start()
    {
        Debug.Log(EndingBAC);

        checkBAC = false;
        EndingBAC = PersistentData.GetPlayerStats().GetCurrentBAC();
        BACWIN.SetActive(false);
        BACLOSE.SetActive(false);
        Music.MenuMusicPlay();
        //needsZero.SetActive(false);
        //CoffeeTip.SetActive(false);
        //EndBacInput.SetActive(false);
        //tipBoxOpen = false;
        //bacZeroTip.SetActive(false);
        //tipBox.SetActive(false);
        //FunTooLow.SetActive(false);
        //BACTooHigh.SetActive(false);
        //ThirstTooLow.SetActive(false);
        //RoadDeath.SetActive(false);
        //FireDeath.SetActive(false);
        //CrystalDeath.SetActive(false);


        checkWinLoseState();

    }


    // Update is called once per frame
    void Update()
    {
        //checkVariables();
        checkWinLoseState();
        //evaluationstuff.SetActive(forceTrue);

    }


    //See the website at: https://www.officer.com/investigations/article/10959606/blood-alcohol-levels-and-blackouts for BAC info

    void checkWinLoseState()
    {

        if (needs.needsZero == false)
        {
            EndingBAC = PersistentData.GetPlayerStats().GetCurrentBAC();
            //needsZero.SetActive(false);
            if (checkBAC == false)
            {
                if (EndingBAC < 0.010)
                {
                    BACWIN.SetActive(true);
                    checkBAC = true;
                }
                else if (EndingBAC > 0)
                {
                    BACLOSE.SetActive(true);
                    checkBAC = true;
                }


            }


            //This one is for food, don't want to touch the baseline
            //else if (needs.needsZero == true)
            //{
            //    needsZero.SetActive(true);
            //    EndBacText = EndBacInput.GetComponent<Text>();
            //    EndBacText.text = "Your finishing Blood alcohol concentration was " + EndingBAC.ToString();
            //}

            //else if (needs.thirstZero == true)
            //{
            //    ThirstTooLow.SetActive(true);
            //    EndBacText = EndBacInput.GetComponent<Text>();
            //    EndBacText.text = "Your finishing Blood alcohol concentration was " + EndingBAC.ToString();
            //}
            //else if (needs.funZero == true)
            //{
            //    FunTooLow.SetActive(true);
            //    EndBacText = EndBacInput.GetComponent<Text>();
            //    EndBacText.text = "Your finishing Blood alcohol concentration was " + EndingBAC.ToString();
            //}

        }
    }
    
    //void checkVariables()
    //{
    //    CoffeeText = textInput.GetComponent<Text>();
    //    CoffeeText.text = "-You had " + InteractableObject_Coffee.coffeeDrunk + " cups of coffee";

    //    foodText = foodTextInput.GetComponent<Text>();
    //    foodText.text = "-You ate food " + InteractableObject_Food.foodCount + " times";

    //    danceText = danceTextInput.GetComponent<Text>();
    //    danceText.text = "You danced " + InteractableObject_DanceFloor.DancePerformed + " times";
    //}

    public void OpenTips()
    {
        if (tipBoxOpen == false)
        {
            tipBox.SetActive(true);
            tipBoxOpen = true;
            checkTips();
        }
        else if (tipBoxOpen == true)
        {
            tipBox.SetActive(false);
            tipBoxOpen = false;
        }


    }

    void checkTips()
    {
        if (tipBoxOpen == true)
        {
            if (InteractableObject_Coffee.coffeeDrunk >= 3)
            {
                CoffeeTip.SetActive(true);
            }
            if (InteractableObject_Food.foodCount >= 3)
            {
                FoodTip.SetActive(true);
            }

            else if (InteractableObject_Coffee.coffeeDrunk <= 3 && InteractableObject_Food.foodCount <= 3)
            {
                bacZeroTip.SetActive(true);
            }
        }
    }


}