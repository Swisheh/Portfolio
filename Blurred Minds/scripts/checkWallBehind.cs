using UnityEngine;
using System.Collections;

public class checkWallBehind : MonoBehaviour
{
    //this script will check if the player is obscured by a wall and if he/she is, it will lerp the material on the wall
    //and set it to transparent.

    public float length = 30f;
    public Transform playerTransform;
    public Transform cameraTransform;
    Vector3 playerOffset;
    //public GameObject[] wall;
    //public Material[] wallMat;
    //public Color[] wallColor;

    //public Material TransparentWall;

    //public float fadeLerpConstant = 0.01F;
    
    public void Init()
    {
        //BindEvent();
    }

    void BindEvent()
    {
        GameFlowManager GameFlowMan = GameObject.Find("GameFlowManager").GetComponent<GameFlowManager>();
        if (GameFlowMan)
        {
            //Debug.Log("manager found");
        }
        else
        {
            Debug.Log("Manager not found");
        }

        GameFlowMan.OnMenuToGame += GetTransforms;

        //Debug.Log("Event successfully bound");
    }

    void UnbindEvent()
    {
        GameFlowManager GameFlowMan = GameObject.Find("GameFlowManager").GetComponent<GameFlowManager>();

        if (GameFlowMan)
        {
            GameFlowMan.OnMenuToGame -= GetTransforms;
        }
    }

    void OnEnable()
    {
        BindEvent();
    }
    
    void GetTransforms()
    {
        playerTransform = GameObject.FindWithTag("playerHead").transform;
        //cameraTransform = Camera.current.transform;
        //Debug.Log("transforms found");
    }

    void OnDestroy()
    {
        UnbindEvent();
    }

    void OnDisable()
    {
        //UnbindEvent();
    }

    void Update()
    {

        RaycastHit[] hits;
        Vector3 rayDirection = Vector3.Normalize(playerTransform.position - cameraTransform.transform.position);
        Vector3 rayStart = cameraTransform.transform.position;     // Start the ray away from the player to avoid hitting itself
        Debug.DrawRay(rayStart, rayDirection * length, Color.green);

        hits = Physics.SphereCastAll(rayStart, 0.75f, rayDirection, length);

        if (hits.Length > 0)
        {

            foreach (RaycastHit hit in hits)
            {
                cameraOccluder occluder = hit.collider.gameObject.GetComponent<cameraOccluder>();
                if (occluder)
                {
                    occluder.Cull();
                }
            }
        }






        //Material wallMat = wall.GetComponent<Renderer>().material;
        //wallMat = new Material[wall.Length];
        /*
        for (int i = 0; i < wall.Length; i++)
        {
            wallMat[i] = wall[i].GetComponent<Renderer>().sharedMaterial;
        }

     
        wallColor = new Color[wall.Length];
        for(int i = 0; i <wall.Length; i++)
        {
            wallColor[i] = wall[i].GetComponent<Renderer>().sharedMaterial.color;
        }
        */
    }
}