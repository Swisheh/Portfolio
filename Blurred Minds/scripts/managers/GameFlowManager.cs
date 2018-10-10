using UnityEngine;
using System.Collections;
using UnityEditor;

public class GameFlowManager : MonoBehaviour
{
    
    public GameObject Scene_MainMenu;
    public GameObject Scene_Game;
    public GameObject Scene_Scene;
    public GameObject Scene_Objects;
    public GameObject Scene_GameOver;
    public GameObject Scene_DrinkToss;
    public GameObject Scene_MFDancer;
    public GameObject Scene_RodrigoRacer;
    public GameObject Scene_HTV;

    private GameObject clone;
    //public SceneController sceneController;
    //public GriffithAnalyticsSession sessionObject;

    public void MoveFromStartMenuToGame()
    {
        Scene_Game.SetActive(true);
        Scene_Objects.SetActive(true);
        Scene_Scene.SetActive(true);
        Scene_MainMenu.SetActive(false);

        if (OnMenuToGame != null)
        {
            OnMenuToGame();
        }

    }

    public void MoveFromPostGameToMainMenu()
    {
        Scene_Game.SetActive(false);
        Scene_Objects.SetActive(false);
        Scene_Scene.SetActive(false);
        Scene_GameOver.SetActive(false);
        Scene_MainMenu.SetActive(true);
    }

    public void MoveFromGameToPostGameScreen()
    {
        Scene_Game.SetActive(false);
        Scene_Objects.SetActive(false);
        Scene_Scene.SetActive(false);
        Scene_GameOver.SetActive(true);
        //sceneController.TriggerGameOver("your BAC was", sessionObject);
    }

    public void MoveFromGameToDrinkToss()
    {
        Scene_Game.SetActive(false);
        Scene_Objects.SetActive(false);
        clone = Instantiate(Scene_DrinkToss);
        clone.SetActive(true);
    }

    public void MoveFromDrinkTossToGame()
    {
        Scene_Game.SetActive(true);
        Scene_Objects.SetActive(true);
        clone.SetActive(false);
        Destroy(clone);
    }

    public void MoveFromGameToMFDancer()
    {
        Scene_Game.SetActive(false);
        Scene_Objects.SetActive(false);
        clone = Instantiate(Scene_MFDancer);
        clone.SetActive(true);
    }

    public void MoveFromMFDancerToGame()
    {
        Scene_Game.SetActive(true);
        Scene_Objects.SetActive(true);
        clone.SetActive(false);
        Destroy(clone);
    }

    public void MoveFromGameToRRacer()
    {
        Scene_Game.SetActive(false);
        Scene_Objects.SetActive(false);
        clone = Instantiate(Scene_RodrigoRacer);
        clone.SetActive(true);
    }

    public void MoveFromRRacerToGame()
    {
        Scene_Game.SetActive(true);
        Scene_Objects.SetActive(true);
        clone.SetActive(false);
        Destroy(clone);
    }

    public void MoveFromGameToHTV()
    {
        Scene_Game.SetActive(false);
        Scene_Objects.SetActive(false);
        clone = Instantiate(Scene_HTV);
        clone.SetActive(true);
    }

    public void MoveFromHTVToGame()
    {
        Scene_Game.SetActive(true);
        Scene_Objects.SetActive(true);
        clone.SetActive(false);
        Destroy(clone);
    }

    public delegate void GameFloat_MenuToGame();
    public event GameFloat_MenuToGame OnMenuToGame;
    
            

}
