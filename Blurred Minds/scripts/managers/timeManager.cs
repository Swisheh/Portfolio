using UnityEngine;
using System.Collections;

public class timeManager : MonoBehaviour
{
    public static timeManager instance = null;


    float StartTime;
    public float TimeScale;
    public float CurrentSimulationTime;
    public float CurrentGameTimeScaled;

    public float AddedTime;

    public int GameStartingTimeHours;
    public int GameStartingTimeMinutes;

    public int DisplayTimeHours;
    public int DisplayTimeMinutes;

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
    }

	// Use this for initialization
	void Start ()
    {
        //StartGameTime();
	}
	
    public void StartGameTime()
    {
        StartTime = Time.time;

        UpdateTime();

        PersistentData.GetPlayerStats().SetTimeAtGameStart(GetCurrentGameTimeScaled());

        //Debug.Log("Game start time set");
    }

	// Update is called once per frame
	void Update ()
    {
        UpdateTime();
	}

    void UpdateTime()
    {
        CurrentSimulationTime = Time.time;

        CurrentGameTimeScaled = ((CurrentSimulationTime - StartTime) * TimeScale) + (GameStartingTimeHours * 3600) + (GameStartingTimeMinutes * 60) + (AddedTime * 60);

        DisplayTimeHours = ((int)CurrentGameTimeScaled / 3600);
        //Cap display time to 23 hours
        DisplayTimeHours -= ((DisplayTimeHours / 24) * 24);

        float temp = (((CurrentGameTimeScaled) / 3600.0f) - (((int)CurrentGameTimeScaled / 3600))) * 60f;
        DisplayTimeMinutes = (int)temp;
    }

    public static GameTime GetInGameTime()
    {
        GameTime time;
        time.Hours = timeManager.instance.DisplayTimeHours;
        time.Minutes = timeManager.instance.DisplayTimeMinutes;
        return time;
    }

    public static float GameTimeToRawTime(GameTime time)
    {
        float RawTime = 240;

        RawTime = ( (time.Hours * 3600) + (time.Minutes * 60) );

        return RawTime;
    }

    public static GameTime RawTimeToGameTime(float RawTime)
    {
        GameTime gameTime;

        gameTime.Hours = (int)RawTime / 3600;
        gameTime.Minutes = (((int)(RawTime - ((int)RawTime / 3600)) / 60)) - (gameTime.Hours * 60);

        return gameTime;
    }

    public static void SetGameTime(GameTime NewTime)
    {
        /*
         
        CurrentSimulationTime = Time.time;

        CurrentGameTimeScaled = ((CurrentSimulationTime - StartTime) * TimeScale) + (GameStartingTimeHours * 3600) + (GameStartingTimeMinutes * 60);

        DisplayTimeHours = ((int)CurrentGameTimeScaled / 3600);
        float temp = ( ( ( CurrentGameTimeScaled) / 3600.0f) - ( DisplayTimeHours ) ) * 60f;
        DisplayTimeMinutes = (int)temp;
         
         */

        //Time is determined by the elapsed simulation time
    }

    public static void SetGameStartingTime(GameTime StartingTime)
    {
        if (instance)
        {
            instance.GameStartingTimeHours = StartingTime.Hours;
            instance.GameStartingTimeMinutes = StartingTime.Minutes;
        }
    }

    public static GameTime GetElapsedGameTime()
    {
        int CurrentTimeHours = ((int)instance.CurrentGameTimeScaled / 3600); //instance.DisplayTimeHours;

        float temp = (((instance.CurrentGameTimeScaled) / 3600.0f) - (((int)instance.CurrentGameTimeScaled / 3600))) * 60f;

        int CurrentTimeMinutes = (int)temp; //instance.DisplayTimeMinutes;
        int CurrentTimeRaw = (CurrentTimeHours * 60) + CurrentTimeMinutes;

        int StartTimeRaw = (instance.GameStartingTimeHours * 60) + instance.GameStartingTimeMinutes;

        int DifferenceRaw = CurrentTimeRaw - StartTimeRaw;

        GameTime Difference;
        Difference.Hours = DifferenceRaw / 60;
        Difference.Minutes = DifferenceRaw % 60;

        return Difference;



    }

    public static float GameTimeToFloatTime(GameTime Time)
    {
        float FloatTime;

        FloatTime = Time.Hours + (Time.Minutes / 60f);

        return FloatTime;
    }

    public static GameTime FloatTimeToGameTime(float Time)
    {
        int TimeHours;
        int TimeMinutes;

        int TempTime = (int)Time * 60;

        TimeHours = TempTime / 60;
        TimeMinutes = TempTime % 60;

        return new GameTime(TimeHours, TimeMinutes);
    }

    public static float GetCurrentGameTimeScaled()
    {
        return instance.CurrentGameTimeScaled;
    }

    public void AddGameTime()
    {
       AddedTime += 30;
    }

}

public struct GameTime
{
    public int Hours;
    public int Minutes;

    public GameTime(int Hours, int Minutes)
    {
        this.Hours = Hours;
        this.Minutes = Minutes;
    }

    public static GameTime operator +(GameTime T1, GameTime T2)
    {
        GameTime Result;
        Result.Hours = T1.Hours + T2.Hours;

        int MinutesTemp = T1.Minutes + T2.Minutes;

        int HourOverflow = MinutesTemp / 60;

        Result.Hours += HourOverflow;

        Result.Minutes = MinutesTemp % 60;

        return Result;
    }


}