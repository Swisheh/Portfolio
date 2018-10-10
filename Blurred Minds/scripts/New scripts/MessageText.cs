using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageText : MonoBehaviour {

    public GameObject canvas;
    public Text messageText;
    public timeManager timeManager;

    private float startTime;
    private float messageTime;
    private bool displayed = true;
    private bool gameStarted = true;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (gameStarted == false && timeManager.GameTimeToRawTime(timeManager.GetInGameTime()) > 60000)
        {
            gameStarted = true;
            canvas.SetActive(true);
            startTime = timeManager.GameTimeToRawTime(timeManager.GetInGameTime());
            messageTime = startTime + (90 * 60); // 1 hour 30 min after start     
            displayed = false;
            //Debug.Log("initiated");
            //Debug.Log(startTime + " : " + messageTime);
            
        }

        if((timeManager.GameTimeToRawTime(timeManager.GetInGameTime()) > messageTime) && displayed == false)
        {
            canvas.SetActive(true);
            displayed = true;
            messageText.text = "Mum: \nYour flight was changed to 4am! You will need to get home ASAP!";
            
        }
        //Debug.Log(timeManager.GameTimeToRawTime(timeManager.GetInGameTime()));
    }

    public void hideText()
    {
        canvas.SetActive(false);
    }

    public void showText()
    {
        canvas.SetActive(true);
        gameStarted = false;
    }
}
