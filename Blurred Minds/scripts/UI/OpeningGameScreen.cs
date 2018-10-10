using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpeningGameScreen : MonoBehaviour
{

    public Text OpeningMenuText;



    public GameObject openingMenuText;
    public GameObject Instructions;
    public GameObject Button;

	// Use this for initialization
	void Start ()
    {
        EventManager.OnMainGameInitialised += OpenScreen;

        //Debug.Log("Opening game screen bound to event");
	}
	

    public void CloseScreen()
    {
        gameManager.instance.StartMainGame();
        EventManager.OnMainGameInitialised -= OpenScreen; //Unbind from the event so the object can be completely destroyed
        Destroy(gameObject);
    }

    public void StartInstructions()
    {
        Instructions.SetActive(true);
        openingMenuText.SetActive(false);
        Button.SetActive(false);
    }

    private void OpenScreen()
    {
        GetComponent<Canvas>().enabled = true;

        


        if (OpeningMenuText)
        {
            string PanelText = OpeningMenuText.text;

            SlotMachineDrink[] Drinks = PersistentData.GetPlayerStats().GetSlotMachineDrinks();

            PanelText = PanelText.Replace("DRINK01", Drinks[0].DrinkName);
            PanelText = PanelText.Replace("DRINK02", Drinks[1].DrinkName);
            PanelText = PanelText.Replace("DRINK03", Drinks[2].DrinkName);

            float Duration = PersistentData.GetPlayerStats().GetSlotMachineDrinkingPeriod().Hours;
            if (PersistentData.GetPlayerStats().GetSlotMachineDrinkingPeriod().Minutes > 0)
            {
                Duration += 0.5f;
            }
             
            PanelText = PanelText.Replace("DURATION", Duration.ToString());

            float StandardDrinks = Drinks[0].StandardDrinkEquivalence + Drinks[1].StandardDrinkEquivalence + Drinks[2].StandardDrinkEquivalence;
            PanelText = PanelText.Replace("STANDARDDRINKS", StandardDrinks.ToString());

            PanelText = PanelText.Replace("CURRENTBAC", PersistentData.GetPlayerStats().GetStartingBAC().ToString("F3"));
            PanelText = PanelText.Replace("TRANSPORTMETHOD", "drive");

            OpeningMenuText.text = PanelText;
            
        }

    }
}
