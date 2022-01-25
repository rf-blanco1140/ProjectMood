using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private GameEvent onEndOfDay;
    [SerializeField] private bool _timePaused; // debug
    [SerializeField] private FloatVariable elapsedTime;
    [SerializeField] private BoolVariable nightTime;
    
    private float _inGameHourInSeconds = 40;
    private int _hoursInDay = 0;
    private int _dayTimeEnds = 3;
    private int _nightTimeStarts = 4;
    private int _day = 1;

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
    
        yield return new WaitForSeconds(_inGameHourInSeconds);
        StartCoroutine(HourlyTimer());
    }

    private void DayTime()
    {
        if (_hoursInDay <= _dayTimeEnds)
        {
        }

        if (_hoursInDay == 1)
        {
            nightTime.boolValue = false;
        }
    }

    private void NightTime()
    {
        if (_hoursInDay >= _nightTimeStarts)
        {
        }

        if (_hoursInDay == _nightTimeStarts)
        {
            nightTime.boolValue = true;
            elapsedTime.Value = 0;
        }
    }

    private int HourManager()
    {
        if (_hoursInDay >= 7)
        {
            _hoursInDay = 1;
            DayManager();
            return _hoursInDay;
        }
        return _hoursInDay;
    }
    private int DayManager()
    {
        onEndOfDay.Raise();
        if (_day >= 7)
        {
            _day = 1;
            return _day;
        }
        _day++;
        return _day;
    }
}