using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private BoolVariable _timePaused;
    [SerializeField] private FloatVariable elapsedTime;
    [SerializeField] private BoolVariable nightTime;
    [SerializeField] private BoolVariable bufferNextDay;

    [SerializeField] private GameEvent onResetDay;
    [SerializeField] private VoidEvent onDropEachHour;
    [SerializeField] private VoidEvent onExhaustion;

    [SerializeField] private TextMeshProUGUI clock;

    private float _inGameHourInSeconds = 30f;
    private int _hoursInDay = 1;
    private int _dayTimeEnds = 5;
    private int _nightTimeStarts = 6;
    private int _day = 1; // don't need
    private float _clockHours = 9f;
    private int _dropTime = 0;
    
    private void Awake()
    {
        StartCoroutine(HourlyTimer());
    }

    private IEnumerator HourlyTimer()
    {
        if (_timePaused.boolValue == true) yield return null;

        HourManager();

        DayTime();
        NightTime();
        UpdateClock();
        
        _clockHours++;
        _hoursInDay++;
        
        onDropEachHour.Raise();
        
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
            elapsedTime.Value = 0;
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

    public void NextDay()
    {
        if (bufferNextDay.boolValue == false)
        {
            _day++; // don't need ?
            // update day saturday => Sunday
            // 
            _clockHours = 9;
            onResetDay.Raise();
            _hoursInDay = 1; 
        }
    }

    public void CheckForBuffer()
    {
        if (_hoursInDay >= 21)
        {
            _day++; // don't need ?
            // update day saturday => Sunday
            // 
            _clockHours = 9;
            onResetDay.Raise();
            _hoursInDay = 1; 
        }
    }
    
    private int HourManager()
    {
        if (_hoursInDay >= 12)
        {
            onExhaustion.Raise();
            _hoursInDay = 1;
            return _hoursInDay;
        }
        return _hoursInDay;
    }

    private void UpdateClock()
    {
        if (_clockHours < 10)
        {
            clock.text = $"0{_clockHours}:00";
        }
        else clock.text = $"{_clockHours}:00";
    }
}