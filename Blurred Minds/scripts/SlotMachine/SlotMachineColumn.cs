using UnityEngine;
using System.Collections;

public class SlotMachineColumn : MonoBehaviour
{

    public RectTransform[] SlotIcons;
    public float SlotHeight;
    public float SlotPadding;

    public float ScrollDuration;
    public float ScrollSpeed;
    public int StopIndex;

	// Use this for initialization
	void Start ()
    {
        //StartColumnScrolling(ScrollDuration, ScrollSpeed, StopIndex);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void StartColumnScrolling(float _ScrollDuration, float _ScrollSpeed, int _StopIndex)
    {
        ScrollDuration = _ScrollDuration;
        ScrollSpeed = _ScrollSpeed;

        StartCoroutine("DoSpin");
        StartCoroutine(SpinTimer());
        StopIndex = _StopIndex;
    }

    public IEnumerator DoSpin()
    {
        while (true)
        {
            MoveTiles();
            WrapTiles();
            yield return new WaitForEndOfFrame();
        }
        
    }

    public IEnumerator SpinTimer()
    {
        yield return new WaitForSeconds(ScrollDuration);
        StopCoroutine("DoSpin");
        StopOnIndex(StopIndex);
        yield return new WaitForEndOfFrame();
        StopOnIndex(StopIndex);
    }

    private void MoveTiles()
    {
        for (int i = SlotIcons.Length - 1; i > -1; i--)
        {
            Vector3 Translation = new Vector3(0, -ScrollSpeed) * Time.deltaTime;

            SlotIcons[i].transform.Translate(Translation);
        }
    }

    private void WrapTiles()
    {
        for (int i = SlotIcons.Length - 1; i > -1; i--)
        {
            //Wrap the last one to a set location, wrap the rest to the one before them plus padding
            if (SlotIcons[i].localPosition.y < -700)
            {
                if (i == SlotIcons.Length -1)
                {
                    Vector3 NewPosition = SlotIcons[i].localPosition;
                    NewPosition.x = 0;
                    NewPosition.y = 800;

                    SlotIcons[i].localPosition = NewPosition;
                }

                else
                {
                    Vector3 NewPosition = SlotIcons[i + 1].localPosition;
                    NewPosition.x = 0;
                    NewPosition.y += (SlotHeight + SlotPadding);

                    SlotIcons[i].localPosition = NewPosition;
                }
            }

        }
    }

    private void StopOnIndex(int index)
    {
        Vector3 NewPosition = new Vector3();// = SlotIcons[index].localPosition;
        NewPosition.y = 0;
        SlotIcons[index].localPosition = NewPosition;
        //Debug.Log("Index set at " + index);
        //Debug.Log("New position:" + NewPosition);
        //Debug.Log("Actual position:" + SlotIcons[index].position);
        
        for (int i = index; i > -1; i--)
        {
            float YOffset = (index - i) * 100;
            NewPosition.x = 0;// = SlotIcons[index].localPosition;
            NewPosition.y = -YOffset;
            SlotIcons[i].localPosition = NewPosition;
        }

        for (int i = index; i < SlotIcons.Length; i++)
        {
            float YOffset = (index - i) * 100;
            NewPosition.x = 0;// = SlotIcons[index].localPosition;
            NewPosition.y = -YOffset;
            SlotIcons[i].localPosition = NewPosition;
        }
        
    }
}
