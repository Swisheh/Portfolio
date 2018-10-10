using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamesStart : MonoBehaviour {

    public GameObject startObj;
    public GameObject instructions;

    public GameObject startObj2;
    public GameObject startObj3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        startObj.SetActive(true);
        if(startObj2 != null)
        {
            startObj2.SetActive(true);
        }
        if(startObj3 != null)
        {
            startObj3.SetActive(true);
        }
        
        this.gameObject.SetActive(false);
        instructions.SetActive(false);
    }
}
