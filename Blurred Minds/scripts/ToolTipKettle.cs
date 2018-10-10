using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ToolTipKettle : ToolTips
{
    Renderer renderObject;
    Material mat;
    Color finalColor;

    void Start()
    {
        renderObject = GetComponent<Renderer>();
        mat = renderObject.material;
        finalColor = (Color.yellow);
    }

    void OnMouseOver()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        toolKettleHover();
        finalColor = Color.Lerp(Color.black, Color.yellow, Mathf.PingPong(Time.time, 1));
        mat.SetColor("_EmissionColor", finalColor);
        //hoverObject();
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        grabObject();
    }

    void OnMouseUp()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        grabOffObject();
    }

    void OnMouseExit()
    {
        toolKettleOff();
        mat.SetColor("_EmissionColor", Color.black);
    }
}
