using UnityEngine;
using System.Collections;

public class mouseLook : MonoBehaviour
{

    public int scrollDistance = 20;
    public float scrollSpeed = 70;

    //mouseZoom
    public float minFov = 15f;
    public float maxFov = 90f;
    public float sensitivity = 10f;

    float minX = -500;
    float maxX = 500;

    private GameObject pannerParentObject; 

    // Use this for initialization
    void Start()
    {
        //To make camera panning a bit easer, the camera is parented to another game object that isn't rotated
        //this is the object that we move when we're panning
        pannerParentObject = this.gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        mouseZoom();
        panCamera();
        keyboardScroll();
    }

    private void mouseZoom()
    {
        float fov = Camera.main.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }

    private void panCamera()
    {
        Vector3 cameraPanDirection = getPanDirectionFromMousePosition();
        pannerParentObject.transform.Translate(cameraPanDirection * scrollSpeed * Time.deltaTime);
    }

    private Vector3 getPanDirectionFromMousePosition()
    {
        float mousePosX = Input.mousePosition.x;
        float mousePosY = Input.mousePosition.y;

        Vector3 cameraPanDirection = Vector3.zero;

        Mathf.Clamp(transform.position.y, minX, maxX);

        //Left screen edge
        if (mousePosX < scrollDistance)
        {
            //transform.Translate(Vector3.right * -scrollSpeed * Time.deltaTime);
            cameraPanDirection += Vector3.left;
        }

        //Right screen edge
        if (mousePosX >= Screen.width - scrollDistance)
        {
            //transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
            cameraPanDirection += Vector3.right;
        }

        //bottom screen edge
        if (mousePosY > scrollDistance)
        {
            //transform.Translate(transform.forward * -scrollSpeed * Time.deltaTime);
            cameraPanDirection += Vector3.forward;
        }

        //top screen edge
        if (mousePosY <= Screen.height - scrollDistance)
        {
            //transform.Translate(transform.forward * scrollSpeed * Time.deltaTime);
            cameraPanDirection += Vector3.back;
        }

        cameraPanDirection.Normalize();

        return cameraPanDirection;
    }


    private void keyboardScroll()
    {
        float scrollForwards = Input.GetAxis("Vertical");
        float scrollRight = Input.GetAxis("Horizontal");

        Vector3 cameraPanDirection = new Vector3(scrollRight, 0, scrollForwards);
        cameraPanDirection.Normalize();
        pannerParentObject.transform.Translate(cameraPanDirection * scrollSpeed * Time.deltaTime);
    }

}



