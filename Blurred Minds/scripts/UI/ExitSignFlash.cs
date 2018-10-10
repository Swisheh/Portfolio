using UnityEngine;
using System.Collections;

public class ExitSignFlash : MonoBehaviour {

    public Renderer thisObject;
    public float flashTime = 1F;

	// Use this for initialization
	void Start ()
    {
        thisObject = gameObject.GetComponent<Renderer>();
        StartCoroutine(signFlash());

	}
	
    IEnumerator signFlash()
    {
        while(true)
        {
            thisObject.enabled = false;
            yield return new WaitForSeconds(flashTime);
            thisObject.enabled = true;
            yield return new WaitForSeconds(flashTime);
        }
    }

	// Up is called once per frame
	void Update () {
	
	}
}
