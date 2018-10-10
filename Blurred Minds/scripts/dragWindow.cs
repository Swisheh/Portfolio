using UnityEngine;
using System.Collections;

public class dragWindow : MonoBehaviour {

    void start()
    {

    }

    public void OnDrag()
    { transform.position = Input.mousePosition; }


}
