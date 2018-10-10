using UnityEngine;
using System.Collections;

public class InteractableObject_Stereo : InteractableObject
{

    public StartMenu_Sounds startSounds;
    public GameObject musicNotes;

    bool playMusic = true;
    bool stopMusic;


    public override void DoAction(string ActionToPerform)
    {
        if (ActionsMatch("Turn On", ActionToPerform))
        {
           // Debug.Log("Turn Stereo On");
         
            RemoveUI();
            playMusic = true;
            startSounds.Select();
        }

        else if (ActionsMatch("Turn Off", ActionToPerform))
        {
           // Debug.Log("Turn Stereo Off");
            musicNotes.SetActive(false);
            RemoveUI();
            stopMusic = true;
            startSounds.Select();
        }

        else
        {
          //  Debug.Log("Cancel");
            RemoveUI();
        }
    }

    void Update()
    {
        if (playMusic == true)
        {
            if(!startSounds.ambientSource.isPlaying)
            {
                startSounds.Music();
                musicNotes.SetActive(true);
                //playMusic = false;
            }
         
        }

        if(stopMusic == true)
        {
            if(startSounds.ambientSource.isPlaying)
            {
                startSounds.MusicStop();
                stopMusic = false;
            }
        }

        if(!startSounds.ambientSource.isPlaying)
        {
            musicNotes.SetActive(false);
        }

       // else
          // startSounds.MusicStop();
    }


}
