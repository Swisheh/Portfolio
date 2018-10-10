using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //login Menu
    public GameObject LoginMenu;
    //CanvasRenderer loginRender;
    //Character Customisation Menu
    public GameObject CharacterCustomisationMenu;
    Renderer charSetupRender;
    //main menu
    public GameObject menu;
    Renderer menuRender;
    public GameObject credits;
    Renderer CreditsRender;

    public StartMenu_Sounds music;

    public GameObject characters;

    //messages
    public GameObject message_1;
    public GameObject message_2;

    public GameObject openingStatement;

    public enum menuState { login, menu, credits, opening, customisation, game };
    public static menuState MenuState;

    // Use this for initialization
    void Start ()
    {
        MenuState = menuState.menu;
        //set initial state of menu
        //loginRender = LoginMenu.GetComponent<CanvasRenderer>();
        menu.SetActive(true);
        message_1.SetActive(false);
        message_2.SetActive(false);
        PlayerStats.weightSet = false;
        PlayerStats.genderSet = false;
        music.MenuMusicPlay();
    }

    public void changeState(int State)
    {
        if(State>=1)
        {
            MenuState = menuState.menu;
       
        }
        if(State>=2)
        {
            MenuState = menuState.customisation;
        }
        if(State>=3)
        {
            if (PlayerStats.weightSet == true)
            {
                if (PlayerStats.genderSet == true)
                {
                    MenuState = menuState.game;
                }
            
            }
        if(State>=4)
            {
                MenuState = menuState.credits;
            }

            if(PlayerStats.weightSet == false)
            {
                StartCoroutine(message1());
            }

            if(PlayerStats.genderSet == false)
            {
                StartCoroutine(message2());
               
            }
         
           
        }
    }

    public void changeMystate(menuState menu)
    {
        MenuState = menu;
    }
	
    IEnumerator message1()
    {
        message_1.SetActive(true);
        yield return new WaitForSeconds(2);
        message_1.SetActive(false);
    }

    IEnumerator message2()
    {
        message_2.SetActive(true);
        yield return new WaitForSeconds(2);
        message_2.SetActive(false);
    }


	// Update is called once per frame
	void Update ()
    {
        if(MenuState == menuState.login)
        {
            LoginMenu.SetActive(true);
            menu.SetActive(false);
            CharacterCustomisationMenu.SetActive(false);
            credits.SetActive(false);
        }
        if(MenuState == menuState.menu)
        {
            LoginMenu.SetActive(false);
            menu.SetActive(true);
            CharacterCustomisationMenu.SetActive(false);
            characters.SetActive(false);
            credits.SetActive(false);
        }
        if(MenuState == menuState.customisation)
        {
            LoginMenu.SetActive(false);
            menu.SetActive(false);
            CharacterCustomisationMenu.SetActive(true);
            characters.SetActive(true);
            credits.SetActive(false);
        }
        if (MenuState == menuState.credits)
        {
            LoginMenu.SetActive(false);
            menu.SetActive(false);
            CharacterCustomisationMenu.SetActive(false);
            characters.SetActive(false);
            credits.SetActive(true);

        }
        if(MenuState == menuState.opening)
        {
            openingStatement.SetActive(true);
            LoginMenu.SetActive(false);
            CharacterCustomisationMenu.SetActive(false);
            characters.SetActive(false);
            credits.SetActive(false);
        }
        /*
        if(MenuState == menuState.game)
        {
            SceneManager.LoadScene("blurredMindsGame");
        }
        */
    }

    public void startMainGame()
    {
        MenuState = menuState.game;
        GameFlowManager GameFlowManager = GameObject.Find("GameFlowManager").GetComponent<GameFlowManager>();
        music.MusicStop();
        GameFlowManager.MoveFromStartMenuToGame();
    }

    public void StartGame()
    {
       
        if (PlayerStats.weightSet == true)
        {
            if (PlayerStats.genderSet == true)
            {
                /*
                MenuState = menuState.game;
                GameFlowManager GameFlowManager = GameObject.Find("GameFlowManager").GetComponent<GameFlowManager>();
                music.MusicStop();
                GameFlowManager.MoveFromStartMenuToGame();
                */
                MenuState = menuState.opening;
            }

        }

        if (PlayerStats.weightSet == false)
        {
            StartCoroutine(message1());
        }

        if (PlayerStats.genderSet == false)
        {
            StartCoroutine(message2());

        }



    }
}
