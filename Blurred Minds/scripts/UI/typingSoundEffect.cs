using UnityEngine;
using System.Collections;

public class typingSoundEffect : MonoBehaviour {
   
    public StartMenu_Sounds startSounds;

   public void typing()
    {
        if (Input.anyKey)
            startSounds.Select();
    }
}
