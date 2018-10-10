using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{

    public static bool weightSet = false;
    public static bool genderSet = true;

    #region Weight
    public void SetPlayerWeight(float NewWeight)
    {

        PlayerWeight = NewWeight;
       
    }

    public void SetPlayerWeight(string NewWeight)
    {
            PlayerWeight = float.Parse(NewWeight);
            //Debug.Log("Player weight set to " + PlayerWeight + "kg.");
    }

    public float GetPlayerWeight()
    {
        return PlayerWeight;
    }

    private float PlayerWeight; 
    #endregion

    #region Gender
    public enum PlayerGender
    {
        MALE,
        FEMALE
    };

    
    private PlayerGender gender;

    public void SetPlayerGenderMale()
    {
        gender = PlayerGender.MALE;
        genderSet = true;
        //Debug.Log("Player gender set to male.");
    }

    public void SetPlayerGenderFemale()
    {
        gender = PlayerGender.FEMALE;
        genderSet = true;
        //Debug.Log("Player gender set to female.");
    }

    public PlayerGender GetPlayerGender()
    {
        return gender;
    }
    #endregion

    #region PlayerSkin
    private int PlayerSkinIndex;

    public void SetPlayerSkinIndex(int NewIndex)
    {
        PlayerSkinIndex = NewIndex;
    }

    public int GetPlayerSkinIndex()
    {
        return PlayerSkinIndex;
    } 
    #endregion

    private SlotMachineDrink[] SlotMachineDrinks; 

    public void SetSlotMachineDrinks(SlotMachineDrink[] _SlotMachineDrinks)
    {
        SlotMachineDrinks = _SlotMachineDrinks;
    }

    public SlotMachineDrink[] GetSlotMachineDrinks()
    {
        return SlotMachineDrinks;
    }

    private GameTime SlotMachineDrinkingingPeriod;

    public void SetSlotMachineDrinkingPeriod(GameTime DrinkingPeriod)
    {
        SlotMachineDrinkingingPeriod = DrinkingPeriod;
    }

    public GameTime GetSlotMachineDrinkingPeriod()
    {
        return SlotMachineDrinkingingPeriod;
    }

    private float StartingBAC;

    public void SetStartingBAC(float BAC)
    {
        StartingBAC = BAC;
    }

    public float GetStartingBAC()
    {
        return StartingBAC;
    }

    private float CurrentBAC;

    public float GetCurrentBAC()
    {
        return CurrentBAC;
    }

    public void SetCurrentBAC(float BAC)
    {
        CurrentBAC = BAC;
    }

    private float BACAtGameEnd;

    public float GetBACAtGameEnd()
    {
        return BACAtGameEnd;
    }

    public void SetBACAtGameEnd(float BAC)
    {
        BACAtGameEnd = BAC;
    }

    private float TimeAtGameStartScaled;

    public float GetTimeAtGameStart()
    {
        return TimeAtGameStartScaled;
    }

    public void SetTimeAtGameStart(float Time)
    {
        TimeAtGameStartScaled = Time;
    }

    private float TimeAtGameEndScaled;

    public float GetTimeAtGameEnd()
    {
        return TimeAtGameEndScaled;
    }

    public void SetTimeAtGameEnd(float Time)
    {
        TimeAtGameEndScaled = Time;
    }
}
