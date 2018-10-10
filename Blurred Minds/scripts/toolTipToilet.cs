using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class toolTipToilet : ToolTips {


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

        toolToiletHover();
        finalColor = Color.Lerp(Color.black, Color.yellow, Mathf.PingPong(Time.time, 1));
        mat.SetColor("_EmissionColor", finalColor);
    }

   

    void OnMouseExit()
    {
        toolToiletOff();
        mat.SetColor("_EmissionColor", Color.black);
    }
}
