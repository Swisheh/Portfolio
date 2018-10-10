using UnityEngine;
using System.Collections;

public class cameraOccluder : MonoBehaviour
{
    private bool DontCull;
    private bool Culled;
    private MeshRenderer RenderComponent;

    private bool CulledThisFrame;
    private bool CulledLastFrame;

    // Use this for initialization
    void Start ()
    {
        
        if (CompareTag("DontCull"))
        {
            DontCull = true;
        }
        
        RenderComponent = gameObject.GetComponent<MeshRenderer>();
    }
	
    void OnEnable()
    {
        if (CompareTag("DontCull"))
        {
            DontCull = true;
        }

        RenderComponent = gameObject.GetComponent<MeshRenderer>();
    }

	// Update is called once per frame
	void Update ()
    {
        CulledLastFrame = CulledThisFrame;
        CulledThisFrame = false;
        if (CulledLastFrame == false)
        {
            UnCull();
        }
	}

    public void Cull()
    {
        if (DontCull) { return; }
        if (Culled) { return; }

        Culled = true;

        RenderComponent.enabled = false;

        CulledThisFrame = true;
    }

    public void UnCull()
    {
        if (DontCull) { return; }
        if (!Culled) { return; }

        Culled = false;

        RenderComponent.enabled = true;


    }

}
