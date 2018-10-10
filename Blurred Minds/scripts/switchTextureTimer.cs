using UnityEngine;
using System.Collections;

public class switchTextureTimer : MonoBehaviour
{
    public Texture[] danceFloorTex = new Texture[2];
    public float DanceFloorTimer = 1F;

	// Use this for initialization
	void Start () {
        StartCoroutine(danceFloorAnim());
    }

    IEnumerator danceFloorAnim()
    {
        while(true)
        {
            Material floorMat = gameObject.GetComponent<Renderer>().material;
            yield return new WaitForSeconds(DanceFloorTimer);
            floorMat.mainTexture = danceFloorTex[0];
            yield return new WaitForSeconds(DanceFloorTimer);
            floorMat.mainTexture = danceFloorTex[1];
            //yield return new WaitForSeconds(DanceFloorTimer);
            //floorMat.mainTexture = danceFloorTex[2];
            //yield return new WaitForSeconds(DanceFloorTimer);
            //floorMat.mainTexture = danceFloorTex[3];
            //yield return new WaitForSeconds(DanceFloorTimer);
            //floorMat.mainTexture = danceFloorTex[4];
            //yield return new WaitForSeconds(DanceFloorTimer);
            //floorMat.mainTexture = danceFloorTex[5];
        }
    
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
