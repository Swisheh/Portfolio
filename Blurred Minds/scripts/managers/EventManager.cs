using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{


    //Called when level loading has started
    public delegate void LevelLoadStarted();
    public static event LevelLoadStarted OnLevelLoadStarted;
    public static void CallLevelLoadStarted()
    {
        if (OnLevelLoadStarted != null)
            OnLevelLoadStarted();
    }


    //Called when level loading has finished
    public delegate void LevelLoadFinished(bool LoadSuccess);
    public static event LevelLoadFinished OnLevelLoadFinished;
    public void CallLevelLoadFinished(bool LoadSuccess)
    {
        if (OnLevelLoadFinished != null)
            OnLevelLoadFinished(LoadSuccess);
    }


    //Called when the slot machine has started
    public delegate void SlotMachineStarted();
    public static event SlotMachineStarted OnSlotMachineStarted;
    public void CallOnSlotMachineStarted()
    {
        if (OnSlotMachineStarted != null)
            OnSlotMachineStarted();
    }


    //Called when the slot machine has finished
    public delegate void SlotMachineFinished();
    public static event SlotMachineFinished OnSlotMachineFinished;
    public void CallOnSlotMachineFinished()
    {
        if (OnSlotMachineFinished!= null)
            CallOnSlotMachineFinished();
    }


    //Called when the main game has started
    public delegate void MainGameStarted();
    public static event MainGameStarted OnMainGameStarted;
    public void CallOnMainGameStarted()
    {
        if (OnMainGameStarted != null)
            OnMainGameStarted();
    }


    //Called when the main game has finished
    public delegate void MainGameFinished();
    public static event MainGameFinished OnMainGameFinished;
    public void CallOnMainGameFinished()
    {
        if (OnMainGameFinished != null)
            OnMainGameFinished();
    }

    public delegate void MainGameInitialised();
    public static event MainGameInitialised OnMainGameInitialised;
    public void CallOnMainGameInitialised()
    {
        if (OnMainGameInitialised != null)
        {
            OnMainGameInitialised();
        }
    }

}
