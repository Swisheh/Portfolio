using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ToolTipCoffee : ToolTips
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

        toolCoffeeHover();
        finalColor = Color.Lerp(Color.black, Color.yellow, Mathf.PingPong(Time.time, 1));
        mat.SetColor("_EmissionColor", finalColor);
    }

    void OnMouseDown()
    {
        grabObject();
    }

    void OnMouseExit()
    {
        toolCoffeeOff();
        mat.SetColor("_EmissionColor", Color.black);
    }
}
