using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class UIActions_GameOver : MonoBehaviour
{
    public WMG_Axis_Graph Graph;
    public WMG_Series GraphSeries;
    public GameObject MainMenu;
    public GameObject GameOverScreen;

    void Start()
    {
        //PopulateGraph();
    }

    public void ReturnToMainMenu()
    {
        
        //Destroy statics
        Destroy(gameManager.instance);
        Destroy(timeManager.instance);
        Destroy(PersistentData.instance);

        //reset variables to zero
        InteractableObject_Coffee.coffeeDrunk = 0;
        InteractableObject_Food.foodCount = 0;
        InteractableObject_DanceFloor.DancePerformed = 0;

        SceneManager.LoadScene("BACToZeroMain");
        //GameOverScreen.SetActive(false);
        //MainMenu.SetActive(true);

        //SendAnalytics();

        //string json = JsonUtility.ToJson(Analytics);
        //File.WriteAllText(Application.dataPath + "/Saves/worldData.json", json);
    }
/*
    private void SendAnalytics()
    {
        //game duration stuff
        float StartingTime = PersistentData.GetPlayerStats().GetTimeAtGameStart();
        float EndingTime = PersistentData.GetPlayerStats().GetTimeAtGameEnd();
        float GameDurationFloat = EndingTime - StartingTime;
        int DisplayTimeHours = ((int)GameDurationFloat / 3600);
        float temp = (((GameDurationFloat) / 3600.0f) - (DisplayTimeHours)) * 60f;
        int DisplayTimeMinutes = (int)temp;
        GameTime GameDuration = new GameTime(DisplayTimeHours, DisplayTimeMinutes);
        float[] BACsAtTime = SetIncrements(GameDurationFloat, 17);

        //analytics stuff
        BacToZeroAnalyticsSession Analytics = new BacToZeroAnalyticsSession();
        Analytics.gameName = "BACToZero";

        //data goes here
        Analytics.FoodEaten = InteractableObject_Food.foodCount;
        Analytics.coffeeDrunk = InteractableObject_Coffee.coffeeDrunk;
        Analytics.timesDanced = InteractableObject_DanceFloor.DancePerformed;
        Analytics.BAC = PersistentData.GetPlayerStats().GetCurrentBAC();
        Analytics.GameDuration = GameDuration.Hours + "h" + GameDuration.Minutes + "m";

        SceneController Controller = GameObject.Find("_Analytics").GetComponent<SceneController>();
        Controller.TriggerGameOver("Game over string", Analytics);
        Debug.Log(JsonUtility.ToJson(Analytics));
        //string json = JsonUtility.ToJson(Analytics);

    }

    private void PopulateGraph()
    {

        //Determine how long the player was at the party for
        //game end time - game start time
        float StartingTime = PersistentData.GetPlayerStats().GetTimeAtGameStart();
        float EndingTime = PersistentData.GetPlayerStats().GetTimeAtGameEnd();

        //TODO handle rolling over past midnight

        float GameDurationFloat = EndingTime - StartingTime;

        int DisplayTimeHours = ((int)GameDurationFloat / 3600);
        float temp = (((GameDurationFloat) / 3600.0f) - (DisplayTimeHours)) * 60f;
        int DisplayTimeMinutes = (int)temp;
        GameTime GameDuration = new GameTime(DisplayTimeHours, DisplayTimeMinutes);

        float[] BACsAtTime = SetIncrements(GameDurationFloat, 17);

        //Debug.Log("Game start time: " + StartingTime.Hours + "h " + StartingTime.Minutes + "m");
        //Debug.Log("Game end time: " + EndingTime.Hours + "h " + EndingTime.Minutes + "m");
        Debug.Log("Game duration: " + GameDuration.Hours + "h " + GameDuration.Minutes + "m");

        //Set the x axis length to that 

        //Get the player's start and end BAC
        float StartingBAC = PersistentData.GetPlayerStats().GetStartingBAC();
        float EndingBAC = PersistentData.GetPlayerStats().GetCurrentBAC();

        //Get an even distribution of those values

        //plot them on the graph
        Graph.Init();
        for (int i = 0; i < BACsAtTime.Length; i++)
        {
            GraphSeries.pointValues.Add(new Vector2((i + 1), BACsAtTime[i]));
        }

        //Set graph X axis labels

        GenerateXAxisLabels(GameDurationFloat);
    }

    private void GenerateXAxisLabels(float GameDurationFloat)
    {

        float XAxisIntervals = GameDurationFloat / Graph.xAxis.axisLabels.Count;

        for (int i = 0; i < Graph.xAxis.axisLabels.Count; i++)
        {
            float LabelTimeFloat = (XAxisIntervals * (i + 1)) + PersistentData.GetPlayerStats().GetTimeAtGameStart();
            GameTime LabelTime;

            LabelTime.Hours = (int)LabelTimeFloat / 3600;
            LabelTime.Hours -= (LabelTime.Hours / 24) * 24;
            LabelTime.Minutes = RoundMinutesToNearestQuarter(LabelTimeFloat / 3600 - (int)LabelTimeFloat / 3600);

            string LabelHours = LabelTime.Hours.ToString();
            string LabelMinutes = LabelTime.Minutes.ToString();

            //if ()

            Graph.xAxis.axisLabels[i] = LabelTime.Hours.ToString() + ":" + LabelTime.Minutes.ToString();
        }
    }

    private int RoundMinutesToNearestQuarter(float Minutes)
    {
        //Debug.Log("Float minutes: " + Minutes);

        int MinutesInt = (int)(Minutes * 60);
        int NearestQuarter = 0;

        NearestQuarter = 15 * (MinutesInt / 15);

        return NearestQuarter;
    }

    private float[] SetIncrements(float Duration, int Increments)
    {
        float StepSize = (Duration / 3600) / Increments;
        /*
        int DisplayTimeHours = ((int)Duration / 3600);
        float temp = (((Duration) / 3600.0f) - (DisplayTimeHours)) * 60f;
        int DisplayTimeMinutes = (int)temp;
        GameTime GameDuration = new GameTime(DisplayTimeHours, DisplayTimeMinutes);
        */
        /*
        float[] BACs = new float[Increments];

        for (int i = 0; i < Increments; i++)
        {
            float BAC = CalculateBACAtTimeSinceGameStart(StepSize * i);
            BACs[i] = BAC;
            Debug.Log("BAC at " + (StepSize * i) + ": " + BAC);
        }

        return BACs;
    }

    private float CalculateBACAtTimeSinceGameStart(float Time)
    {
        float CurrentTimeAsFloat = (Time / 3600f);

        float DrinkingPeriod = Time + timeManager.GameTimeToFloatTime(PersistentData.GetPlayerStats().GetSlotMachineDrinkingPeriod());
        float StandardDrinks = 0;
        SlotMachineDrink[] Drinks = PersistentData.GetPlayerStats().GetSlotMachineDrinks();

        foreach (SlotMachineDrink drink in Drinks)
        {
            StandardDrinks += drink.StandardDrinkEquivalence;
        }

        float BAC = BACCalculator.CalculateEstimatedBACWidmark(StandardDrinks, PersistentData.GetPlayerStats().GetPlayerGender(), PersistentData.GetPlayerStats().GetPlayerWeight(), DrinkingPeriod);

        return BAC;
    }
    */
}
