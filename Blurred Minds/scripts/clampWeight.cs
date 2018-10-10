using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class clampWeight : MonoBehaviour
{
    private float playerWeight;
    public InputField changeWeight;
    public static bool allowWeightChange = false;
    public Text weightChanged;

    public void checkWeight(string weight)
    {
        //Debug.Log("Boom");
        playerWeight = int.Parse(weight);
        if(playerWeight > 200)
        {
            changeWeight.text = "200";
            PersistentData.GetPlayerStats().SetPlayerWeight("200");
            PlayerStats.weightSet = true;
        }
        else if (playerWeight < 30)
        {
            changeWeight.text = "30";
            PersistentData.GetPlayerStats().SetPlayerWeight("30");
            PlayerStats.weightSet = true;
        }
        else
        {
            changeWeight.text = weight;
            PersistentData.GetPlayerStats().SetPlayerWeight(weight);
            PlayerStats.weightSet = true;
        }

    }

    public void CheckWeight(float weight)
    {
        playerWeight = weight;
    }

    public void CheckFinalWeight(string weight)
    {
        playerWeight = int.Parse(weight);
        if (playerWeight < 30)
        {
            changeWeight.text = "30";
            allowWeightChange = true;
        }
        else if(playerWeight > 30)
        {
            allowWeightChange = true;
        }
        
    }

    
}
