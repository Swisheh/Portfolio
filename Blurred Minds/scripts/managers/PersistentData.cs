using UnityEngine;
using System.Collections;

public class PersistentData : MonoBehaviour
{

    public static PersistentData instance = null;

    private PlayerStats playerStats = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);

        playerStats = GetComponent<PlayerStats>();
    }

    public static PlayerStats GetPlayerStats()
    {
        if (instance)
        {
            return instance.playerStats;
        }
        else
        {
            return null;
        }
    }

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    
}
