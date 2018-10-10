using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTalk : MonoBehaviour {

    public GameObject talkObj;
    GameObject canvas;
    Camera camera2;

	// Use this for initialization
	void Start () {
        canvas = talkObj.GetComponentInChildren<Canvas>().gameObject;
        camera2 = Camera.main;
        canvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        camera2 = Camera.main;
        if (canvas.activeSelf)
        {
            canvas.transform.LookAt(canvas.transform.position + camera2.transform.rotation * Vector3.forward);
        }
        

        //if (Input.GetKey(KeyCode.Mouse0))
        //{
        //    canvas.SetActive(false);
        //}
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Player")
        {
            //Debug.Log("nerdboy collided with: " + coll.name);
            canvas.SetActive(true);
        }    
    }

    void OnTriggerExit(Collider coll)
    {
        //Debug.Log("die gameobject");
        if (coll.tag == "Player")
        {
            canvas.SetActive(false);
            
        }    
    }

}
