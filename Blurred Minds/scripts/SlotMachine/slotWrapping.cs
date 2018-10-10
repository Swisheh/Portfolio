using UnityEngine;
using System.Collections;

public class slotWrapping : MonoBehaviour {

    public Transform slot1;
    public Transform SavedPos;

    public Transform StartPos;
    Transform currentPos;
	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    { 
	    if(slot1.transform.position.y < -1100)
        {
            //Debug.Log("Greater");
            //slot1.transform.position = StartPos.transform.position;
            Vector3 Position = slot1.transform.position;
            Position.y = 500;
            slot1.transform.position = Position;


        }
    }
}
