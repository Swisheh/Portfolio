using UnityEngine;
using System.Collections;

//public interface IInteractable<T>
public interface IInteractable
{
    //void DoAction(T ActionToPerform);

    

    void SetInteractableObject(InteractableObject Object);

    void PassActionList(string[] Actions);
}
