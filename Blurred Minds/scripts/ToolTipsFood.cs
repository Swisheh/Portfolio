using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ToolTipsFood : ToolTips {


    Renderer[] renderObject;
    public GameObject fruitBowl;
    Material mat;
    Color finalColor;


    void Start()
    {

        mat = fruitBowl.GetComponent<Renderer>().material;
        finalColor = (Color.yellow);
    }

    void OnMouseOver()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        toolFoodHover();
        finalColor = Color.Lerp(Color.black, Color.yellow, Mathf.PingPong(Time.time, 1));
        mat.SetColor("_EmissionColor", finalColor);

    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        grabObject();
    }

    void OnMouseExit()
    {
        toolFoodOff();
        mat.SetColor("_EmissionColor", Color.black);

    }
}
