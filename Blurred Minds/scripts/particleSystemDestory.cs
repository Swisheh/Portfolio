using UnityEngine;
using System.Collections;

public class particleSystemDestory : MonoBehaviour {

    public float timer;

 void Start()
    {

        StartCoroutine(AutoDestruct());
    }

    IEnumerator AutoDestruct()
    {
        yield return new WaitForSeconds(timer);
        Destroy(this.gameObject);
    }
}
