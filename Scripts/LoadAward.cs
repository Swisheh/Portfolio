using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAward : MonoBehaviour {

    public string url = "";

    void Start()
    {
        url = Application.streamingAssetsPath + "/award.pdf";
    }

    public void OpenURL()
    {
        //Debug.Log(Application.streamingAssetsPath);
        Application.OpenURL(url);
        //Debug.Log("Test");
    }

}
