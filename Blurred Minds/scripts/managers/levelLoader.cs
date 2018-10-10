using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{

    public string[] LevelsToLoad;
    public GameObject LoadingScreenUIObject;
    private string LevelBeingLoaded;

    public void BeginLoad()
    {
        EnableLoadScreen();
        StartCoroutine("LoadLevels");
        Debug.Log("Load started");
    }

    private int NumLevelsLoaded = 0;
    private bool IsLoadingLevel = false;

    IEnumerator LoadLevels()
    {
        NumLevelsLoaded = 0;
        IsLoadingLevel = false;

        while (NumLevelsLoaded < LevelsToLoad.Length)
        {
            if (!IsLoadingLevel)
            {
                if (NumLevelsLoaded <= LevelsToLoad.Length - 1)
                {
                    LoadALevel(LevelsToLoad[NumLevelsLoaded]);
                }
            }
            yield return null;
        }

        LoadCompleted();
    }

    private void LoadALevel(string LevelToLoad)
    {
        IsLoadingLevel = true;

        //Don't load the level if it is already loaded
        if (SceneManager.GetSceneByName(LevelToLoad).isLoaded)
        {
            LevelFinishedLoading();
        }
        else
        {
            //Listen for load finished
            //SceneManager.sceneLoaded += LevelFinishedLoading;
            LevelBeingLoaded = LevelToLoad;
            StartCoroutine("CheckLevelLoaded");
            SceneManager.LoadSceneAsync(LevelToLoad, LoadSceneMode.Additive);
        }
    }

    private IEnumerator CheckLevelLoaded()
    {
        while (IsLoadingLevel)
        {
            if (SceneManager.GetSceneByName(LevelBeingLoaded).isLoaded)
            {
                LevelFinishedLoading();
                yield return null;
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }
        }
        yield return null;
    }

    private void LevelFinishedLoading()
    {
        IsLoadingLevel = false;
        NumLevelsLoaded++;
    }

    private void LevelFinishedLoading(Scene LoadedScene, LoadSceneMode SceneMode)
    {
        IsLoadingLevel = false;
        NumLevelsLoaded++;
    }

    private void LoadCompleted()
    {
        StopCoroutine("LoadLevels");
        Debug.Log("Load finished");
        DisableLoadScreen();

        gameManager manager = GetComponent<gameManager>();
        if (manager)
        {
            manager.PostLoadInitialiseGame();
        }
    }

    private void EnableLoadScreen()
    {
        LoadingScreenUIObject.SetActive(true);
    }

    private void DisableLoadScreen()
    {
        LoadingScreenUIObject.SetActive(false);
    }
}
