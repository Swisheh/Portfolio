using UnityEngine;
using System.Collections;

public class ReturnToMainMenu : MonoBehaviour {

    public static bool gamePlayed = false;

    public void returnToMainMenu()
    {
        gamePlayed = true;
        GameFlowManager GameFlowManager = GameObject.Find("GameFlowManager").GetComponent<GameFlowManager>();

        GameFlowManager.MoveFromPostGameToMainMenu();
        MainMenu.MenuState = MainMenu.menuState.menu;
    }
}
