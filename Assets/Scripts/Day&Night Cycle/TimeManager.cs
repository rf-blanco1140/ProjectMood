using System.Collections;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private BoolVariable bufferNextDay;
    [SerializeField] private VoidEvent onDropEachHour;
    [SerializeField] private VoidEvent onSleep;
    [SerializeField] private TextMeshProUGUI clock;
    [SerializeField] private IntVariable day;
    [SerializeField] private Ending ending;

    private float _inGameHourInSeconds = 3f;
    public float _clockHours = 8f;
    
    private void Awake()
    {
        day.Value = 0;
        StartCoroutine(DailyTimer());
    }

    public IEnumerator DailyTimer()
    {
        if (day.Value == 2)
        {
            Debug.Log("Done");
            ending.GetAverageForEnding();
            bufferNextDay.boolValue = true;
            StopCoroutine(DailyTimer());
        }
        
        GoingToSleepExhausted();
        
        UpdateClock();
        _clockHours++;
        
        onDropEachHour.Raise();
        
        yield return new WaitForSeconds(_inGameHourInSeconds);
        StartCoroutine(DailyTimer());
    }

    //public void GoingToSleep()
    //{
    //    StopCoroutine(DailyTimer());
    //    onSleep.Raise();
    //    _clockHours = 8;
    //    day.ApplyChange(1);
    //}
    
    private void GoingToSleepExhausted()
    {
        if (_clockHours >= 21 && bufferNextDay.boolValue == false)
        {
            StopCoroutine(DailyTimer());
            onSleep.Raise();
            // play some tired sound bell noise idk
            _clockHours = 8;
        }
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