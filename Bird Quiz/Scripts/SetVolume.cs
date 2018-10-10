using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour {

    public AudioSource audioV;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetLevel(float sliderValue)
    {
        //mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        audioV.volume = sliderValue;
        Debug.Log(sliderValue);
    }
}
