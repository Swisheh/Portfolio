using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlcoholConsumptionTracker : MonoBehaviour
{
    public List<DrinkConsumed> DrinksConsumed = new List<DrinkConsumed>();
    public GameObject GraphPointPrefab;
    public Transform GraphParent;



    float CurrentBAC;

	// Use this for initialization
	void Start ()
    {
        /*
        StartNewDrink(2f, 1f);
        StartCoroutine("ChartBAC");
        Debug.Log( BACCalculator.CalculateEstimatedBAC (2, PlayerStats.PlayerGender.MALE, 70, 1f) );
        */
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*
        //BACCalculator.CalculateEstimatedBAC()
        CalculateBAC(DrinksConsumed[0]);
        */

        UpdateCurrentBAC();
	}

    void Stuff()
    {

    }

    float CalculateBAC(DrinkConsumed Drink)
    {
        //float CulmulativeBAC = 0f;

        GameTime TimeStartedDrinking = Drink.TimeDrinkStarted;
        GameTime TimeFinishedDrinking = TimeStartedDrinking;

        TimeFinishedDrinking.Hours += Mathf.RoundToInt(Drink.DrinkingPeriodInHours);
        float DrinkingPeriodTruncated = Drink.DrinkingPeriodInHours - Mathf.RoundToInt(Drink.DrinkingPeriodInHours);
        TimeFinishedDrinking.Minutes = Mathf.RoundToInt(Mathf.Lerp(0f, 59f, (DrinkingPeriodTruncated)));

        GameTime CurrentTime = timeManager.GetInGameTime();

        float a = timeManager.GameTimeToRawTime(TimeStartedDrinking);
        float b = timeManager.GameTimeToRawTime(TimeFinishedDrinking);
        float t = timeManager.GameTimeToRawTime(CurrentTime);

        Debug.Log("TIME: " + a + ", " + b + ", " + t);

        float i = Mathf.InverseLerp(a, b, t);

        Debug.Log("i: " + i);

        Debug.Log("PEAK BAC: " + Drink.PeakBAC);

        CurrentBAC = Mathf.Lerp(0f, Drink.PeakBAC, i);
        Debug.Log("Current BAC: " + CurrentBAC);

        //After we stopped drinking, lower the BAC
        if (i == 1f)
        {
            float CurrentTimeRaw = timeManager.GameTimeToRawTime(CurrentTime);
            float TimeFinishedDrinkingRaw = timeManager.GameTimeToRawTime(TimeFinishedDrinking);
            float TimeSinceStoppedDrinkingRaw = CurrentTimeRaw - TimeFinishedDrinkingRaw;
            GameTime TimeSinceStoppedDrinking = timeManager.RawTimeToGameTime(TimeSinceStoppedDrinkingRaw);

            Debug.Log("Time since stopped drinking: " + TimeSinceStoppedDrinking.Hours + ":" + TimeSinceStoppedDrinking.Minutes + "raw:" + (TimeSinceStoppedDrinkingRaw / 3600f));

            float BACMetalobised = (TimeSinceStoppedDrinkingRaw / 3600f) * 0.01f;
            CurrentBAC -= BACMetalobised;
        }

        return 0f;
    }

    void CalculateDrinkingPeriod()
    {

    }

    void CalculateStandardDrinks()
    {

    }

    public void StartNewDrink(float StandardDrinkEqv, float DrinkingPeriod)
    {
        DrinkConsumed NewDrink;

        NewDrink.TimeDrinkStarted = timeManager.GetInGameTime();
        NewDrink.StandardDrinkEquivalent = StandardDrinkEqv;
        NewDrink.DrinkingPeriodInHours = DrinkingPeriod;
        NewDrink.PeakBAC = BACCalculator.CalculateEstimatedBAC(StandardDrinkEqv, PlayerStats.PlayerGender.MALE, 60, DrinkingPeriod);

        Debug.Log("BAC CALCULATION: " + BACCalculator.CalculateEstimatedBAC(2, PlayerStats.PlayerGender.MALE, 60, 2));

        DrinksConsumed.Add(NewDrink);
    }

    public IEnumerator ChartBAC()
    {
        while (true)
        {
            GameObject InstantiatedPoint = (GameObject)Instantiate(GraphPointPrefab);
            InstantiatedPoint.transform.parent = GraphParent;

            RectTransform RectTrans = InstantiatedPoint.GetComponent<RectTransform>();

            float PositionTime;
            GameTime CurrentTime = timeManager.GetInGameTime();

            PositionTime = (CurrentTime.Hours * 100f) + ( (Mathf.InverseLerp (0f, 59f, CurrentTime.Minutes)) * 100f );

            //Debug.Log(PositionTime);

            float PositionBAC;

            PositionBAC = 100f * (CurrentBAC * 100f);

            RectTrans.anchoredPosition = new Vector2(PositionTime, PositionBAC);

            yield return new WaitForSeconds(1f);
        }
    }

    void UpdateCurrentBAC()
    {
        float DrinkingPeriod = timeManager.GameTimeToFloatTime(timeManager.GetElapsedGameTime()) + timeManager.GameTimeToFloatTime(PersistentData.GetPlayerStats().GetSlotMachineDrinkingPeriod()) ;

        float StandardDrinks = 0;

        SlotMachineDrink[] Drinks = PersistentData.GetPlayerStats().GetSlotMachineDrinks();


        foreach (SlotMachineDrink drink in Drinks)
        {
            StandardDrinks += drink.StandardDrinkEquivalence;
        }

        float BAC = BACCalculator.CalculateEstimatedBACWidmark(StandardDrinks, PersistentData.GetPlayerStats().GetPlayerGender(), PersistentData.GetPlayerStats().GetPlayerWeight(), DrinkingPeriod);

        PersistentData.GetPlayerStats().SetCurrentBAC(BAC);
        //Debug.Log("BAC after: " + PersistentData.GetPlayerStats().GetCurrentBAC());
    }
}

public struct DrinkConsumed
{
    public GameTime TimeDrinkStarted;
    public float StandardDrinkEquivalent;
    public float DrinkingPeriodInHours;
    public float PeakBAC;
}