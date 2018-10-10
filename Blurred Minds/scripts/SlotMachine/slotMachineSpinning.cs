using UnityEngine;
using System.Collections;

public class slotMachineSpinning : MonoBehaviour
{
    public float speed = 5f;

   public  Renderer slot1Rend;
   public  Renderer slot2Rend;
   public  Renderer slot3Rend;

    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;

    float slotDuration;
    float slot2Duration;
    float slot3Duration;

    bool started = false;
    bool slot2Start = false;
    bool slot3Start = false;
    bool finished = false;

    public void startMachine(bool startMachine)
    {
        started = true;
    }


	// Use this for initialization
	void Start ()
    {
        

        slotDuration = 10;
        slot2Duration = Random.Range(2, 7);
        slot3Duration = Random.Range(2, 7);



    }
	
	// Update is called once per frame
	void Update ()
    {
        if(started==true)
        {
            StartCoroutine(startFirstMachine());
       
        }
        
        if(slot2Start==true)
        {
            StartCoroutine(startSecondMachine());
        }

        
        if(slot3Start==true)
        {
            StartCoroutine(startThirdMachine());
        }

        if(finished==true)
        {
            //Raycast to check what the poker machine has landed on (what images are facing the camera?) This could probably be done hard coded by
            //checking the offset of the poker machine's texture on material. 
           // Debug.Log("Poker Machine is done");
        }
        
        

	
	}

    IEnumerator startFirstMachine()
    {
        float offset = Time.time * speed;
        slot1Rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
        yield return new WaitForSeconds(slotDuration);
        //Debug.Log("finished");
        started = false;
        slot2Start = true;
      
    }

    IEnumerator startSecondMachine()
    {
        float offset = Time.time * speed;
        slot2Rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
        yield return new WaitForSeconds(slot2Duration);
        //Debug.Log("finished2");
        slot2Start = false;
        StartCoroutine(startThirdMachine());
    }

    IEnumerator startThirdMachine()
    {
        float offset = Time.time * speed;
        slot3Rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
        yield return new WaitForSeconds(slot3Duration);
        slot3Start = false;
        finished = true;
        yield break;
    }



}
