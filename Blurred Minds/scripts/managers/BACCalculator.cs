using UnityEngine;
using System.Collections;

public class BACCalculator : MonoBehaviour
{

    public const float  ALCOHOL_METABOLISM_RATE_WIDMARK = 0.01f; //This was 0.017 but I'm bringing it down to 0.01 to be more conservative

    //Calculate estimated peak BAC according to wikipedia
    //_Standard drinks - The number of standard drinks containing 10 grams of ethanol
	public static float CalculateEstimatedBAC(float _StandardDrinks, PlayerStats.PlayerGender _Gender, float _BodyWeight, float _DrinkingPeriod)
    {
        float BodyWaterConstant = 0.806f;
        float StandardDrinks = _StandardDrinks;
        float ConversionFactor = 1.2f;
        float BodyWaterConstantGender = (_Gender == PlayerStats.PlayerGender.MALE) ? 0.58f:0.49f;
        float BodyWeight = _BodyWeight;
        float MetabolismConstant = (_Gender == PlayerStats.PlayerGender.MALE) ? 0.015f:0.017f;
        float DrinkingPeriod = _DrinkingPeriod;

        float EstimatedPeakBAC = 0f;


        EstimatedPeakBAC = ((BodyWaterConstant * StandardDrinks * ConversionFactor) / (BodyWaterConstantGender * BodyWeight)) - MetabolismConstant * DrinkingPeriod;

        if (EstimatedPeakBAC < 0f)
            EstimatedPeakBAC = 0f;

        return EstimatedPeakBAC;
    }

    /// <summary>
    /// use the widmark formula to calculate BAC
    /// </summary>
    /// <param name="_StandardDrinks">How many standard drinks were consumed in the drinking period.</param>
    /// <param name="_Gender"></param>
    /// <param name="_BodyWeight">Bodyweight in kilograms</param>
    /// <param name="_DrinkingPeriod">The drinking period in hours</param>
    /// <returns></returns>
    public static float CalculateEstimatedBACWidmark(
                                                        float _StandardDrinks, 
                                                        PlayerStats.PlayerGender _Gender, 
                                                        float _BodyWeight, 
                                                        float _DrinkingPeriod )
    {
        float EstimatedBac = 0.0f;

        float AlcoholConsumedInGrams = _StandardDrinks * 10f;
        float GenderConstant = (_Gender == PlayerStats.PlayerGender.MALE) ? 0.68f : 0.55f;
        float BodyWeightInGrams = _BodyWeight * 1000f;

        float RawNumber = AlcoholConsumedInGrams / (BodyWeightInGrams * GenderConstant);
        float PeakBac = RawNumber * 100f;

        EstimatedBac = PeakBac - (_DrinkingPeriod * ALCOHOL_METABOLISM_RATE_WIDMARK);

        EstimatedBac = Mathf.Clamp(EstimatedBac, 0, EstimatedBac);

        return EstimatedBac;
    }

    public static GameTime CalculateMetabolismTime(float BAC)
    {
        GameTime MetabolismTime;

        MetabolismTime.Hours = (int)(BAC / ALCOHOL_METABOLISM_RATE_WIDMARK);

        float TimeMinutes = ((BAC / ALCOHOL_METABOLISM_RATE_WIDMARK) - MetabolismTime.Hours) * 60;

        MetabolismTime.Minutes = (int)TimeMinutes;

        return MetabolismTime;
    }

    void Start()
    {
        //Debug.Log(CalculateEstimatedBAC(3, PlayerGender.MALE, 80, 2));
        //Debug.Log(CalculateEstimatedBAC(2.5f, PlayerGender.FEMALE, 70, 2));

        Debug.Log(CalculateEstimatedBAC(2f, PlayerStats.PlayerGender.MALE, 90, 1));
        Debug.Log(CalculateEstimatedBAC(4f, PlayerStats.PlayerGender.MALE, 90, 1));
        Debug.Log(CalculateEstimatedBAC(6f, PlayerStats.PlayerGender.MALE, 90, 1));
        //Debug.Log(CalculateEstimatedBAC(2.5f, PlayerGender.FEMALE, 70, 2));

    }

}
