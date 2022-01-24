using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // a day is 24h, 1h = 2min
    // a "day" = 6h( 12 min )
    // color/light changes during the day?
    // at the end of the day get a summary of what happened

    private float _inGameHourInSeconds = 120f;
    private float _debugTime = 2f; // debug
    private int _hoursInDay = 0;
    private int _dayTimeEnds;
    private int _nightTimeStarts;
    private int _day = 1;
    [SerializeField] private bool _timePaused; // debug
    private void Awake()
    {
        StartCoroutine(HourlyTimer());
    }

    private IEnumerator HourlyTimer()
    {
        while (_timePaused)
        {
            yield return null;
        }
        HourManager();
        _hoursInDay++;
    
        DayTime();
        NightTime();
    
        yield return new WaitForSeconds(1);
        StartCoroutine(HourlyTimer());
    }

    private void DayTime()
    {
        if (_hoursInDay <= _dayTimeEnds)
        {
            Debug.Log(HourManager());
        }
    }

    private void NightTime()
    {
        if (_hoursInDay >= _nightTimeStarts)
        {
            Debug.Log(HourManager());
        }
    }

    private int HourManager()
    {
        if (_hoursInDay >= 7)
        {
            _hoursInDay = 0;
            DayManager();
            return _hoursInDay;
        }
        return _hoursInDay;
    }
    private int DayManager()
    {
        ActionEventSystem.current.endDaySummaryTrigger();
        if (_day >= 7)
        {
            _day = 1;
            return _day;
        }
        _day++;
        return _day;
    } // has event
}
