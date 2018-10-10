using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDeathScript : MonoBehaviour {

    public GameObject RoadDeath;
    public GameObject GameScene;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            RoadDeath.SetActive(true);
            GameScene.SetActive(false);
            //SceneManager.LoadScene("BACToZeroMain");
            Debug.Log("collided");
        }
    }
}

