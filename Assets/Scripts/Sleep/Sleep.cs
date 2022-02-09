using System.Collections;
using UnityEngine;

public class Sleep : MonoBehaviour
{
    [SerializeField] private VoidEvent onNextDay;
    [SerializeField] private VoidEvent onSummary;
    
    [SerializeField] private FloatVariable body;
    
    [SerializeField] private GameObject exhausted;
    [SerializeField] private GameObject summary;
    [SerializeField] private GameObject sleepUI;
    
    [SerializeField] private BoolVariable canWalk;
    [SerializeField] private BoolVariable pauseRotation;
    [SerializeField] private BoolVariable timePaused;

    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject player;

    public IEnumerator GoingToSleep()
    {
        sleepUI.GetComponent<SleepUI>().ResetTimers();
        sleepUI.GetComponent<SleepUI>().FadeToBlack();
        
        canWalk.boolValue = false;
        pauseRotation.boolValue = true;
        timePaused.boolValue = true;

        yield return new WaitForSeconds(3); // fade to black    
        
        summary.SetActive(true);
        onSummary.Raise(); //doesn't work in testing but will work in mainscene
        sleepUI.GetComponent<SleepUI>().SetStartPosition();
        sleepUI.GetComponent<SleepUI>().ResetTimers();
        sleepUI.GetComponent<SleepUI>().TransitionToEndOfDaySummary();
        
        body.ApplyChange(20); // whatever stats 
        
        yield return new WaitForSeconds(8); // fade to black    
        nextButton.SetActive(true);
    }

    public IEnumerator WakingUp()
    {
        sleepUI.GetComponent<SleepUI>().SetFinalPosition();
        sleepUI.GetComponent<SleepUI>().ResetTimers();
        sleepUI.GetComponent<SleepUI>().TransitionOutOfEndOfDaySummary();

        yield return new WaitForSeconds(3); // amount it takes for transition to end 
        sleepUI.GetComponent<SleepUI>()._startUI = false;
        sleepUI.GetComponent<SleepUI>()._continueUI = false;

        summary.SetActive(false);

        pauseRotation.boolValue = false;
        timePaused.boolValue = false;
        onNextDay.Raise();
        canWalk.boolValue = true;

        player.transform.position = new Vector3(-7f, 1f, 10.5f);
    }

    public void StartExhaustion()
    {
        StartCoroutine(Exhausted());
    }
    
    private IEnumerator Exhausted()
    {
        sleepUI.GetComponent<SleepUI>().ResetTimers();
        sleepUI.GetComponent<SleepUI>().FadeToBlack();
        
        exhausted.SetActive(true); // fade in
        sleepUI.GetComponent<SleepUI>().FadeText(exhausted);
        
        yield return new WaitForSeconds(4); // however long it should be up
        StartCoroutine(GoingToSleep());
    }

    public void Button()
    {
        StartCoroutine(WakingUp());
        nextButton.SetActive(false);
    }
}