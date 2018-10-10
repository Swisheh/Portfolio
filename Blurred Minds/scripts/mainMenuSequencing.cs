using UnityEngine;
using System.Collections;

public class mainMenuSequencing : MonoBehaviour {

    public GameObject mainMenuGraph;
    public GameObject mainMenuEvaluation;

    public enum mainMenuState { graph, evaluation };
    mainMenuState menuState;

	// Use this for initialization
	void Start ()
    {
       menuState = mainMenuState.graph;
        mainMenuEvaluation.SetActive(true);     
        mainMenuGraph.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    { 
        if (menuState == mainMenuState.graph)
        {
            mainMenuGraph.SetActive(false);
            mainMenuEvaluation.SetActive(true);
        }
        if (menuState == mainMenuState.evaluation)
        {
            mainMenuGraph.SetActive(false);
            mainMenuEvaluation.SetActive(true);
        }
        
    }
    /*
    public void goToEvaluation()
    {
        menuState = mainMenuState.evaluation;
    }
    */
    public void goToGraph()
    {
        menuState = mainMenuState.graph;
    }
       
    
}
