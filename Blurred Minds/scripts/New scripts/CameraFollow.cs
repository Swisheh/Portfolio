using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public GameObject playerF;      // Female character
    public GameObject playerM;      // Male character

    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        if (playerF.active) { 
            offset = transform.position - playerF.transform.position;
        } else {
            offset = transform.position - playerM.transform.position;
        }       
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (playerF.active)
        {
            transform.position = playerF.transform.position + offset;
        } else {
            transform.position = playerM.transform.position + offset;
        }        
    }
}