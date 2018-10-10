using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizController : MonoBehaviour {

    //public GameObject pelican;
    //public GameObject raptor;
    //public GameObject flamingo;
    //public GameObject honeyeater;
    //public GameObject emu;
    //public GameObject owl;
    //public GameObject parrot;
    //public GameObject vulture;
    //public GameObject ibis;
    //public GameObject kiwi;
    //public GameObject penguin;
    //public GameObject oystercatcher;
    //public GameObject cockatoo;
    //public GameObject snowyowl;

    public GameObject start;
    public GameObject next;
    public GameObject end;
    public GameObject finalTestActive;
    public GameObject[] list;
    GameObject currentBird;
    GameObject question;
    int listNum = 0;
    public int mistakes = 0;
    public Text fraction;
    public GameObject counter;

    private System.Random _random = new System.Random();

    // Use this for initialization
    void Start () {
        currentBird = list[listNum];
        
	}
	
	// Update is called once per frame
	void Update () {
		if (mistakes > 3 && finalTestActive.activeSelf)
        {
            end.SetActive(true);
            currentBird.SetActive(false);
        }

        fraction.text = (listNum + 1) + " " + list.Length;
	}

    public void BirdQuestions()
    {

    }

    public void Correct()
    {

        next.SetActive(false);
        if (question.name == "QuestionTwo")
        {        
            if (currentBird == list[list.Length-1])
            {
                end.SetActive(true);
                currentBird.SetActive(false);
                counter.SetActive(false);
            } else
            {
                NextBird();
            }
            
        } else
        {           
            question.SetActive(false);
            question = currentBird.transform.GetChild(3).gameObject;
            //Debug.Log(question.name);
            question.SetActive(true);            
        }     
    }

    void NextBird()
    {
        currentBird.SetActive(false);
        listNum += 1;
        currentBird = list[listNum];
        Debug.Log(currentBird.name);
        currentBird.SetActive(true);
        question = currentBird.transform.GetChild(2).gameObject;
        //Debug.Log(question.name);
    }

    public void Next()
    {
        next.SetActive(true);
        currentBird.transform.GetChild(4).gameObject.SetActive(true);
    }

    public void Wrong()
    {
        next.SetActive(false);
        // make hint highlight / get larger + bold
        question.transform.GetChild(4).gameObject.SetActive(true);
        question.transform.GetChild(4).gameObject.GetComponent<Text>().fontSize += 2;
        question.transform.GetChild(4).gameObject.GetComponent<Text>().fontStyle = FontStyle.Bold;
        mistakes++;
    }

    public void Reset()
    {
        currentBird = list[0];
        currentBird.SetActive(true);
        end.SetActive(false);
    }

    public void StartTest()
    {
        currentBird.SetActive(true);
        question = currentBird.transform.GetChild(2).gameObject;
        start.SetActive(false);
        

        foreach(GameObject bird in list)
        {
            Debug.Log(bird.name);
        }
        
    }

    public void ShowCounter()
    {
        counter.SetActive(true);
    }

    public void Shuffle()
    {
        int p = list.Length;
        for (int n = p - 1; n > 0; n--)
        {
            int r = _random.Next(0, n);
            GameObject t = list[r];
            list[r] = list[n];
            list[n] = t;
        }

        currentBird = list[listNum];       
        StartTest();
    }
}
