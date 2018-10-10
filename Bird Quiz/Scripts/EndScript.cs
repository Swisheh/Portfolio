using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour {


    public GameObject quizControl;
    private QuizController script;

    public GameObject win;
    public GameObject lose;

	// Use this for initialization
	void Awake () {
        script = quizControl.GetComponent<QuizController>();

        if(script.mistakes > 3)
        {
            lose.SetActive(true);
        } else
        {
            win.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
