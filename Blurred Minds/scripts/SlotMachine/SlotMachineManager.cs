using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlotMachineManager : MonoBehaviour
{
    public SlotMachineColumn Slot1;
    public SlotMachineColumn Slot2;
    public SlotMachineColumn Slot3;

    private List<SlotMachineDrink> DrinksList;

    void Awake()
    {
        BuildDrinksList();
        EventManager.OnSlotMachineStarted += GenerateRandomResult;

    }

    // Use this for initialization
    void Start ()
    {
	}
	
    void BuildDrinksList()
    {
        DrinksList = new List<SlotMachineDrink>();

        //Beer
        AddDrink("Full Strength Beer(4.8 %) 375mL",   375.0f, 1.4f, SlotMachineDrink.DrinkType.BEER, 0); //stubbie
        AddDrink("Full Strength Beer(4.8 %) 285mL",   285.0f, 1.1f, SlotMachineDrink.DrinkType.BEER, 8); //pot
        AddDrink("Mid Strength Beer (3.5%) 375mL",    375.0f, 1.0f, SlotMachineDrink.DrinkType.BEER, 7); //stubbie
        AddDrink("Mid Strength Beer (3.5%) 285mL",    285.0f, 0.8f, SlotMachineDrink.DrinkType.BEER, 9); //pot
        AddDrink("Low Strength (2.7%) 375mL",         375.0f, 0.8f, SlotMachineDrink.DrinkType.BEER, 5); //stubbie
        AddDrink("Low Strength (2.7%) 285mL",         285.0f, 0.6f, SlotMachineDrink.DrinkType.BEER, 12); //pot

        //Wine
        AddDrink("Red Wine (13%) 100mL",              100.0f, 1.0f, SlotMachineDrink.DrinkType.WINE, 2); //glass
        AddDrink("White Wine (11.5%) 100mL",          100.0f, 0.9f, SlotMachineDrink.DrinkType.WINE, 4); //glass

        //Spirits
        AddDrink("Spirits (40%) 30mL",               40.0f,  1.0f, SlotMachineDrink.DrinkType.SPIRITS, 1); //shot

        //Mixed Drinks
        AddDrink("Pre-mixed drink (7%) 375mL",        375.0f, 2.1f, SlotMachineDrink.DrinkType.MIXED_DRINK, 6); //can
        AddDrink("Pre-mixed drink (7%) 275mL",        275.0f, 1.5f, SlotMachineDrink.DrinkType.MIXED_DRINK, 13); //bottle
        AddDrink("Pre-mixed drink (5%) 375mL",        375.0f, 1.5f, SlotMachineDrink.DrinkType.MIXED_DRINK, 3); //can
        AddDrink("Pre-mixed drink (5%) 275mL",        275.0f, 1.1f, SlotMachineDrink.DrinkType.MIXED_DRINK, 14); //bottle

        //Other
        AddDrink("Water 350mL",                       350.0f, 0.0f, SlotMachineDrink.DrinkType.OTHER, 10); //cup
        AddDrink("Soft Drink 375mL",                  375.0f, 0.0f, SlotMachineDrink.DrinkType.OTHER, 11); //can
    }

    private void AddDrink(  string DrinkName, 
                            float Volume, 
                            float StandardDrinkEquivalence, 
                            SlotMachineDrink.DrinkType Type,
                            int _DrinkIndex)
    {
        SlotMachineDrink Drink;

        Drink.DrinkName = DrinkName;
        Drink.Volume = Volume;
        Drink.StandardDrinkEquivalence = StandardDrinkEquivalence;
        Drink.Type = Type;
        Drink.DrinkIndex = _DrinkIndex;

        DrinksList.Add(Drink);
    }

    //Placeholder until we get something proper in
	private void GenerateRandomResult()
    {
        List<SlotMachineDrink> RandomDrinks = new List<SlotMachineDrink>();

        //just add 3 random drinks until we get something better
        RandomDrinks.Add(DrinksList[Random.Range(0, DrinksList.Count)]);
        RandomDrinks.Add(DrinksList[Random.Range(0, DrinksList.Count)]);
        RandomDrinks.Add(DrinksList[Random.Range(0, DrinksList.Count)]);

        //Debug.Log("Slot machine generated something");
        //Debug.Log(RandomDrinks[0].DrinkName);
        //Debug.Log(RandomDrinks[1].DrinkName);
        //Debug.Log(RandomDrinks[2].DrinkName);

        /*
        Debug.Log(BACCalculator.CalculateEstimatedBACWidmark(2, PlayerStats.PlayerGender.MALE, 55, 1));
        Debug.Log(BACCalculator.CalculateEstimatedBACWidmark(2, PlayerStats.PlayerGender.MALE, 55, 2));
        Debug.Log(BACCalculator.CalculateEstimatedBACWidmark(2, PlayerStats.PlayerGender.MALE, 55, 3));
        */

        //Generate a random drinking period between 1 and 3.5 hours
        int DrinkingPeriodHours = Random.Range(1, 3);
        int DrinkingPeriodHalfHour = Random.Range(0, 2);

        GameTime DrinkingPeriod;
        DrinkingPeriod.Hours = DrinkingPeriodHours;
        DrinkingPeriod.Minutes = DrinkingPeriodHalfHour * 30;

        float DrinkingPeriodBAC = (float)DrinkingPeriodHours + ((float)DrinkingPeriodHalfHour * 0.5f);

        float TotalStandardDrinksConsumed = RandomDrinks[0].StandardDrinkEquivalence + RandomDrinks[1].StandardDrinkEquivalence + RandomDrinks[2].StandardDrinkEquivalence;
        float StartingBAC = BACCalculator.CalculateEstimatedBACWidmark(TotalStandardDrinksConsumed, PersistentData.GetPlayerStats().GetPlayerGender(), PersistentData.GetPlayerStats().GetPlayerWeight(), DrinkingPeriodBAC);
        PersistentData.GetPlayerStats().SetStartingBAC(StartingBAC);

        //Pass the drinking period to the player stats.
        PersistentData.GetPlayerStats().SetSlotMachineDrinkingPeriod(DrinkingPeriod);

        Debug.Log("Starting BAC: " + StartingBAC);
        //Debug.Log("Total standard drinks consumed: " + TotalStandardDrinksConsumed);
        //Debug.Log("Drinking period: " + DrinkingPeriod.Hours + "h " + DrinkingPeriod.Minutes + "m");

        GameTime MetabolismTime = BACCalculator.CalculateMetabolismTime(StartingBAC);
        Debug.Log("Time to metabolise: " + MetabolismTime.Hours + "h " + MetabolismTime.Minutes + "m");

        //Let the game manager know that the slot machine is finished, and it can advance to the main game.
        SlotMachineFinished(RandomDrinks);
    }

    private void SlotMachineFinished(List<SlotMachineDrink> RandomDrinks)
    {
        //Pass results back to playerstats
        PersistentData.GetPlayerStats().SetSlotMachineDrinks(RandomDrinks.ToArray());

        Slot1 = GameObject.Find("SlotMachineSlot1").GetComponent<SlotMachineColumn>();
        Slot2 = GameObject.Find("SlotMachineSlot2").GetComponent<SlotMachineColumn>();
        Slot3 = GameObject.Find("SlotMachineSlot3").GetComponent<SlotMachineColumn>();

        Slot1.StartColumnScrolling(3, 2000, RandomDrinks[0].DrinkIndex);
        Slot2.StartColumnScrolling(4, 2000, RandomDrinks[1].DrinkIndex);
        Slot3.StartColumnScrolling(5, 2000, RandomDrinks[2].DrinkIndex);
    }

    public void Advance()
    {
        gameManager.instance.SlotMachineFinished();
    }
}

public struct SlotMachineDrink
{
    public string DrinkName;
    public float Volume;
    public float StandardDrinkEquivalence;

    public enum DrinkType
    {
        BEER,
        WINE,
        SPIRITS,
        MIXED_DRINK,
        OTHER
    };

    public DrinkType Type;

    public int DrinkIndex;
}
