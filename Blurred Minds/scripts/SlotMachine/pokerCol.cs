using UnityEngine;
using System.Collections;

public class pokerCol : MonoBehaviour
{

    public bool startCheck = false;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (startCheck == true)
        {
            //Debug.Log("start Checking");
           
        }
	}

    void OnTriggerEnter(Collider trigger)
    {
        if(startCheck==true)
        {
            if (trigger.gameObject.name == "Beer(FullStrength)")
            {
                Debug.Log("Beer drunk");
               
            }

/*
            if (trigger.gameObject.name == "spiritshot(40%)")
            {
                Debug.Log("spiritshot(40%)");
              
            }


            if (trigger.gameObject.name == "Red Wine")
            {
                Debug.Log("Red Wine");
               
            }


            if(trigger.gameObject.name == "PreMixedDrink(5%)")
            {
                Debug.Log("PreMixedDrink(5%)");
                
            }


            if (trigger.gameObject.name == "WhiteWine")
            {
                Debug.Log("WhiteWine");
         
            }


            if (trigger.gameObject.name == "Beer(LowStrength)")
            {
                Debug.Log("Beer(LowStrength)");
               
            }


            if (trigger.gameObject.name == "premixedDrink(7%)")
            {
                Debug.Log("premixedDrink(7%) ");
               
            }


            if (trigger.gameObject.name == "Beer(MidStrength)")
            {
                Debug.Log("Beer(MidStrength)");
               
            }

            if (trigger.gameObject.name == "BeerCan(FullStrength)")
            {
                Debug.Log("BeerCan(FullStrength)");
              

            }

            if (trigger.gameObject.name == "BeerCan(MediumStrength)")
            {
                Debug.Log("BeerCan(MediumStrength)");
                
            }

            if (trigger.gameObject.name == "Water")
            {
                Debug.Log("Water");
               
            }

            if (trigger.gameObject.name == "soft Drink")
            {
                Debug.Log("soft Drink");
                
            }

            if (trigger.gameObject.name == "BeerCan(LowStrength)")
            {
                Debug.Log("BeerCan(LowStrength)");
                
            }

            if (trigger.gameObject.name == "premixedDrink(7%)")
            {
                Debug.Log("premixedDrink(7%)");
               
            }

            if (trigger.gameObject.name == "premixedDrinkCan(5%)")
            {
                Debug.Log("premixedDrinkCan(5%)");
               
            }
            */

            Debug.Log("CollisionNotFound");
        }
        
    }
}
