using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ToolTipShower : ToolTips
{

    Renderer renderObject;
    public Material[] mat;
    Color finalColor;

    void Start()
    {
        renderObject = GetComponent<Renderer>();
        mat = renderObject.materials;
        finalColor = (Color.yellow);
    }

    void OnMouseOver()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        toolShowerHover();
        finalColor = Color.Lerp(Color.black, Color.yellow, Mathf.PingPong(Time.time, 1));
        for(var i = 0; i < renderObject.materials.Length; i++)
        {
            renderObject.materials[i].SetColor("_EmissionColor", finalColor);
        }
       // mat.SetColor("_EmissionColor", finalColor);
    }

    void OnMouseExit()
    {
        toolShowerOff();
        for (var i = 0; i < renderObject.materials.Length; i++)
        {
            renderObject.materials[i].SetColor("_EmissionColor", Color.black);
        }
      //  mat.SetColor("_EmissionColor", Color.black);
    }
}
