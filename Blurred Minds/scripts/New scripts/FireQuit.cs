using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireQuit : MonoBehaviour {


    public GameObject FireDeath;
    public GameObject GameScene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FireDeath.SetActive(true);
            GameScene.SetActive(false);
            //SceneManager.LoadScene("BACToZeroMain");
            Debug.Log("collided");
        }
    }
}
