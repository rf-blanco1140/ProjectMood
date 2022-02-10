using System.Collections;
using TMPro;
using UnityEngine;

public class Sleep : MonoBehaviour
{
    [SerializeField] private VoidEvent onSummary;
    [SerializeField] private VoidEvent onToggleUI;

    [SerializeField] private BoolVariable canWalk;
    [SerializeField] private BoolVariable pauseRotation;
    [SerializeField] private BoolVariable timePaused;
    
    [SerializeField] private GameObject summary;
    [SerializeField] private GameObject nextButton;
    
    [SerializeField] private GameObject player;
    private Vector3 playerStartPosition = new Vector3(-7f, 1f, 10.5f);
    
    [SerializeField] private SleepUI sleepUI;
    [SerializeField] private SleepTrigger sleepTrigger;
    [SerializeField] private BoolVariable bufferNextDay;
    [SerializeField] private TimeManager time;
    
    public void StartSleeping()
    {
        StartCoroutine(Sleeping());
    }
    
    public IEnumerator Sleeping()
    {
        bufferNextDay.boolValue = true;
        sleepUI.ResetTimers();
        sleepUI.FadeToBlack();
        onToggleUI.Raise();
        
        canWalk.boolValue = false;
        pauseRotation.boolValue = true;
        timePaused.boolValue = true;

        yield return new WaitForSeconds(3);  
        
        summary.SetActive(true);
        onSummary.Raise(); 
        sleepUI.SetStartPosition();
        sleepUI.ResetTimers();
        sleepUI.TransitionToEndOfDaySummary();
        
        yield return new WaitForSeconds(8);  
        nextButton.SetActive(true);
    }

    public IEnumerator WakingUp()
    {
        sleepUI.SetFinalPosition();
        sleepUI.ResetTimers();
        sleepUI.TransitionOutOfEndOfDaySummary();
        
        yield return new WaitForSeconds(5); 
        sleepUI.ResetTimers();
        sleepUI.FadeFromBlack();
        
        sleepUI._startUI = false;
        sleepUI._continueUI = false;

        summary.SetActive(false);

        pauseRotation.boolValue = false;
        timePaused.boolValue = false;
        canWalk.boolValue = true;
        
        onToggleUI.Raise();
        player.transform.position = playerStartPosition;
        sleepTrigger.pressed = false;
        
        time._clockHours = 8;
        StartCoroutine(time.DailyTimer());
        bufferNextDay.boolValue = false;
    }

    public void Button()
    {
        StartCoroutine(WakingUp());
        nextButton.SetActive(false);
    }
}