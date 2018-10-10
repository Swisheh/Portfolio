using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ToolTipDoor : ToolTips
{

    Renderer renderObject;
    Material mat;
    Color finalColor;
   public GameObject door;

    void Start()
    {
        renderObject = door.GetComponent<Renderer>();
        mat = renderObject.sharedMaterial;
        finalColor = (Color.yellow);
    }

    void OnMouseOver()
    { 
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        toolDoorHover();
        finalColor = Color.Lerp(Color.black, Color.yellow, Mathf.PingPong(Time.time, 1));
        mat.SetColor("_EmissionColor", finalColor);
    }

    void OnMouseExit()
    {
        toolDoorOff();
        mat.SetColor("_EmissionColor", Color.black);
    }
}
