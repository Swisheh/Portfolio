using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenu_Sounds : MonoBehaviour
{
    #region sound effects
    //Sound effects
    public AudioClip select;
    public AudioClip cancel;
    public AudioClip drink;
    public AudioClip Eat;
    public AudioClip flush;
    public AudioClip kettle;
    public AudioClip textInput;
    public AudioClip select2;
    public AudioClip talking;
    #endregion sound effects

    #region music
    //Background music
    public AudioClip GameMusic;
    public AudioClip ambientSoundMusic;
    public AudioClip MenuMusic;

    public AudioSource source;
    public AudioSource musicSource;
    public AudioSource ambientSource;
    #endregion music


    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "startMenu")
        {
            if (!musicSource.isPlaying)
            {
                musicSource.PlayOneShot(MenuMusic);
            }
        }

        else if(sceneName == "blurredMindsGame")
        {
            if(!musicSource.isPlaying)
            {
                musicSource.PlayOneShot(GameMusic);
                //Debug.Log("is this playing?");
            }
        }
         

    }


    
	public void Select()
    {
        source.PlayOneShot(select);
    }

    public void Cancel()
    {
        source.PlayOneShot(cancel);
    }

    public void Flush()
    {
        source.PlayOneShot(flush);
    }

    public void Drink()
    {
        source.PlayOneShot(drink);
    }

    public void Kettle()
    {
        source.PlayOneShot(kettle);
    }

    public void talk()
    {
        source.PlayOneShot(talking);
    }

    public void Music()
    {
        ambientSource.PlayOneShot(ambientSoundMusic);
    }

    public void MenuMusicPlay()
    {
        ambientSource.Play();
    }

    public void MusicStop()
    {
        ambientSource.Stop();
    }

    public void textInputEnter()
    {
        source.PlayOneShot(textInput);
    }

    public void select02()
    {
        source.PlayOneShot(select2);
    }

}
