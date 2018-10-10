using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageController : MonoBehaviour {

    public GameObject Home;
    public GameObject Learn;
    public GameObject Practice;
    public GameObject Test;
    public GameObject Credits;

    GameObject clone;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void goToHome()
    {
        Destroy(clone);
        Home.SetActive(true);
        Learn.SetActive(false);
        Practice.SetActive(false);
        Test.SetActive(false);
    }

    public void goToLearn()
    {
        Destroy(clone);
        Home.SetActive(false);
        //Learn.SetActive(true);
        clone = Instantiate(Learn);
        clone.SetActive(true);
        Practice.SetActive(false);
        Test.SetActive(false);
    }

    public void goToPractice()
    {
        Destroy(clone);
        Home.SetActive(false);
        Learn.SetActive(false);
        //Practice.SetActive(true);
        clone = Instantiate(Practice);
        clone.SetActive(true);
        Test.SetActive(false);
    }

    public void goToTest()
    {
        Destroy(clone);
        Home.SetActive(false);
        Learn.SetActive(false);
        Practice.SetActive(false);
        //Test.SetActive(true);
        clone = Instantiate(Test);
        clone.SetActive(true);
    }

    public void goToCredits()
    {
        Destroy(clone);
        Home.SetActive(false);
        Learn.SetActive(false);
        Practice.SetActive(false);
        Test.SetActive(false);
        clone = Instantiate(Credits);
        clone.SetActive(true);
    }
}
