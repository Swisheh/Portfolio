using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuBAC : MonoBehaviour
{

    //this class handles the menu it is attached to and fades it out when the x is ticked.

    public bool isOn = true;
    public bool needsOn = true;

   // public GameObject bacMenu;
    public GameObject needsMenu;
    public GameObject endGameMenu;

  

    public void turnOff(int state)
    {
       if(state > 0)
        {
            Debug.Log("poop");
            isOn = false;
        }
       if(state <= 0)
        {
            isOn = true;
        }

    }

    public void menuScreen(bool menu)
    {
       if(menu==true)
        {
            SceneManager.LoadScene("startMenu");
            MainMenu.MenuState = MainMenu.menuState.menu;
        }
    }

    public void ExitGame(bool exit)
    {
        if(exit==true)
        { Application.Quit(); }  
    }

    public void turnOffNeeds(int stateNeeds)
    {
        if(stateNeeds > 0)
        {
            needsOn = false;
        }
        if(stateNeeds <= 0)
        {
            needsOn = true;
        }
    }

    void start()
    {
        endGameMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
     

        if (isOn == false)
        {
            //Debug.Log("menu is off");
            //bacMenu.SetActive(false);

        }

        if(needsOn == false)
        {
            needsMenu.SetActive(false);
        }

        if(isOn == true)
        {
            //Debug.Log("menu is on");
            //bacMenu.SetActive(true);
        }

        if(needsOn == true)
        {
            needsMenu.SetActive(true);
        }

	}
}
