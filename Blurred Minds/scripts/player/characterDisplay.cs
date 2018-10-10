using UnityEngine;
using System.Collections;

public class characterDisplay : MonoBehaviour {

   // float angle = 360.0f;
    float time = 20.0f;

    //Vector3 axis = Vector3.up;

    Transform objectRotate;
	// Use this for initialization
	void Start ()
    {
        objectRotate = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        objectRotate.Rotate(Vector3.up * Time.deltaTime * time);


    }
}
