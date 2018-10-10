using UnityEngine;
using System.Collections;

public class ToolTips : MonoBehaviour
{

    #region variables

    public GameObject ToolTipTelevision;
    public GameObject ToolTipToilet;
    public GameObject ToolTipCoffee;
    public GameObject ToolTipNPC;
    public GameObject ToolTipStereo;
    public GameObject ToolTipDoor;
    public GameObject ToolTipKettle;
    public GameObject ToolTipFood;
    public GameObject ToolTipFridge;
    public GameObject ToolTipDance;
    public GameObject ToolTipShower;
    public GameObject ToolTipBeerPong;

    public Texture2D mouse;
    public Texture2D hand;
    public Texture2D grab;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;

    #endregion variables

    #region toolTips

    public void hoverObject()
    {
        Cursor.SetCursor(hand, hotspot, cursorMode);
    }

    public void grabObject()
    {
        Cursor.SetCursor(grab, hotspot, cursorMode);
    }

    public void grabOffObject()
    {
        Cursor.SetCursor(mouse, hotspot, cursorMode);
    }

    //television
    public void toolTelevisionHover()
    {
        ToolTipTelevision.transform.position = Input.mousePosition;
        ToolTipTelevision.SetActive(true);
        Cursor.SetCursor(hand, hotspot, cursorMode);


    }
    public void toolTelevisionOff()
    {
        ToolTipTelevision.SetActive(false);
        Cursor.SetCursor(mouse, hotspot, cursorMode);

    }

    //beer pong
    public void toolBeerPongHover()
    {
        ToolTipBeerPong.transform.position = Input.mousePosition;
        ToolTipBeerPong.SetActive(true);
        Cursor.SetCursor(hand, hotspot, cursorMode);
    }
    public void toolBeerPongOff()
    {
        ToolTipBeerPong.SetActive(false);
        Cursor.SetCursor(mouse, hotspot, cursorMode);
    }

    //toilet
    public void toolToiletHover()
    {
        ToolTipToilet.transform.position = Input.mousePosition;
        ToolTipToilet.SetActive(true);
        Cursor.SetCursor(hand, hotspot, cursorMode);
    }

  
    public void toolToiletOff()
    {
        ToolTipToilet.SetActive(false);
        Cursor.SetCursor(mouse, hotspot, cursorMode);
    }

    //Coffee
    public void toolCoffeeHover()
    {
        ToolTipCoffee.transform.position = Input.mousePosition;
        ToolTipCoffee.SetActive(true);
        Cursor.SetCursor(hand, hotspot, cursorMode);
    }
    public void toolCoffeeOff()
    {
        ToolTipCoffee.SetActive(false);
        Cursor.SetCursor(mouse, hotspot, cursorMode);
    }


    //NPCs
    public void toolNPCHover()
    {
        ToolTipNPC.transform.position = Input.mousePosition;
        ToolTipNPC.SetActive(true);
        Cursor.SetCursor(hand, hotspot, cursorMode);
    }
    public void toolNPCOff()
    {
        ToolTipNPC.SetActive(false);
        Cursor.SetCursor(mouse, hotspot, cursorMode);
    }

    //Stereo
    public void toolStereoHover()
    {
        ToolTipStereo.transform.position = Input.mousePosition;
        ToolTipStereo.SetActive(true);
        Cursor.SetCursor(hand, hotspot, cursorMode);
    }
    public void toolStereoOff()
    {
        ToolTipStereo.SetActive(false);
        Cursor.SetCursor(mouse, hotspot, cursorMode);
    }


    //Door
    public void toolDoorHover()
    {
        ToolTipDoor.transform.position = Input.mousePosition;
        ToolTipDoor.SetActive(true);
        Cursor.SetCursor(hand, hotspot, cursorMode);
    }
    public void toolDoorOff()
    {
        ToolTipDoor.SetActive(false);
        Cursor.SetCursor(mouse, hotspot, cursorMode);
    }

    //Kettle
    public void toolKettleHover()
    {
        ToolTipKettle.transform.position = Input.mousePosition;
        ToolTipKettle.SetActive(true);
        Cursor.SetCursor(hand, hotspot, cursorMode);
    }
    public void toolKettleOff()
    {
        ToolTipKettle.SetActive(false);
        Cursor.SetCursor(mouse, hotspot, cursorMode);
    }

    //Food
    public void toolFoodHover()
    {
        ToolTipFood.transform.position = Input.mousePosition;
        ToolTipFood.SetActive(true);
        Cursor.SetCursor(hand, hotspot, cursorMode);
    }

    public void toolFoodOff()
    {
        ToolTipFood.SetActive(false);
        Cursor.SetCursor(mouse, hotspot, cursorMode);
    }

    //Fridge
    public void toolFridgeHover()
    {
        ToolTipFridge.transform.position = Input.mousePosition;
        ToolTipFridge.SetActive(true);
        Cursor.SetCursor(hand, hotspot, cursorMode);
    }

    public void toolFridgeOff()
    {
        ToolTipFridge.transform.position = Input.mousePosition;
        ToolTipFridge.SetActive(false);
        Cursor.SetCursor(mouse, hotspot, cursorMode);
    }

    //dance Floor
    public void toolDanceHover()
    {
        ToolTipDance.transform.position = Input.mousePosition;
        ToolTipDance.SetActive(true);
        Cursor.SetCursor(hand, hotspot, cursorMode);
    }

    public void toolDanceOff()
    {
        ToolTipDance.transform.position = Input.mousePosition;
        ToolTipDance.SetActive(false);
        Cursor.SetCursor(mouse, hotspot, cursorMode);
    }

    //shower
    public void toolShowerHover()
    {
        ToolTipShower.transform.position = Input.mousePosition;
        ToolTipShower.SetActive(true);
        Cursor.SetCursor(hand, hotspot, cursorMode);
    }

    public void toolShowerOff()
    {
        ToolTipShower.transform.position = Input.mousePosition;
        ToolTipShower.SetActive(false);
        Cursor.SetCursor(mouse, hotspot, cursorMode);
    }


    #endregion toolTips

}
