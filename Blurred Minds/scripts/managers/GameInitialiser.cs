using UnityEngine;
using System.Collections;

public class GameInitialiser : MonoBehaviour
{

    //We have to force initialise disabled objects because getting a technical outline
    //after weeks of development means we now get the pleasure of a hacked restructure

    [Header("Player Variables")]
    public GameObject PlayerGameObjectMale;
    public GameObject PlayerGameObjectFemale;
    private checkWallBehind MaleWallScript;
    private checkWallBehind FemaleWallScript;

    void MenuToGameInit()
    {
        MaleWallScript = PlayerGameObjectMale.GetComponent<checkWallBehind>();
        FemaleWallScript = PlayerGameObjectFemale.GetComponent<checkWallBehind>();

        MaleWallScript.Init();
        FemaleWallScript.Init();
    }


    void Start()
    {
        MenuToGameInit();
    }
}
