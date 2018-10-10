using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class toolTipNPC : ToolTips
{
   // Renderer renderObject;
   // public Material[] mat;
    Color finalColor;
    Color hoverOverColor;

    void Start()
    {
        //renderObject = gameObject.GetComponent<Renderer>();
       // mat = renderObject.materials;
        finalColor = (Color.yellow);
    }

    void OnMouseOver()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        toolNPCHover();
        finalColor = Color.Lerp(Color.black, Color.yellow, Mathf.PingPong(Time.time, 1));
        Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.material.SetColor("_EmissionColor", finalColor);
        }

    }

    void OnMouseExit()
    {
        toolNPCOff();
        Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers)
        {
            r.material.SetColor("_EmissionColor", Color.black);
        }

    }

}
