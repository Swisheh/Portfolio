using UnityEngine;
using System.Collections;

public class slotMachineSpin : MonoBehaviour {

    //public GameObject checkColCollider;
    public pokerCol pokerMachineCol;

    public GameObject spinMaster;
    public Transform spinTransform;
    public Transform startPoint;

    bool scrollActive = false;
    bool scrolling = false;

    float randomTime;
    float speed;
    public static float velocity;

	// Use this for initialization
	void Start ()
    {
      
        spinTransform = spinMaster.GetComponent <Transform>();
        randomTime = 10;
        speed = 1000;
	}

    public void startScroll()
    {
        scrolling = true;
        StartCoroutine(spinWheel());
        StartCoroutine(WheelTimer());
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	
	}

    IEnumerator spinWheel()
    {
        while (scrolling)
        {
            spinTransform.transform.Translate(Vector3.down * speed * Time.deltaTime, 0);
            yield return new WaitForEndOfFrame();
        
        }
        //yield return new WaitForSeconds(randomTime);
       
    }

    
    IEnumerator WheelTimer()
    {
        while(true)
        {
        yield return new WaitForSeconds(randomTime);

        scrolling = false;
        }
    }

}
