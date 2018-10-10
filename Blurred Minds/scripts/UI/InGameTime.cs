using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGameTime : MonoBehaviour
{
    bool IsActive = false;

	// Use this for initialization
	void Start ()
    {
        IsActive = false;

        //subscribe to the event manager. When OnMainGameStarted() is called, StartClock() will be called too
        EventManager.OnMainGameStarted += StartClock; 
	}
	
    void OnDestroy()
    {
        //Make sure we unbind from the event if this script is being destroyed
        EventManager.OnMainGameStarted -= StartClock;
    }

    void StartClock()
    {
        IsActive = true;
    }

	// Update is called once per frame
	void Update ()
    {
        Text TimeText = GetComponent<Text>();

        if (!IsActive)
        {
            TimeText.text = "--:--";
        }
        else
        {
            string TextHours;
            string TextMinutes;

            TextHours = timeManager.GetInGameTime().Hours.ToString();

            if (timeManager.GetInGameTime().Minutes < 10)
            {
                TextMinutes = "0" + timeManager.GetInGameTime().Minutes.ToString();
            }
            else
            {
                TextMinutes = timeManager.GetInGameTime().Minutes.ToString();
            }

            TimeText.text = TextHours + ":" + TextMinutes;
        }
	}
}
