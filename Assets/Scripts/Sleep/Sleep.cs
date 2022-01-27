using System.Collections;
using UnityEngine;

public class Sleep : MonoBehaviour
{
    [SerializeField] private VoidEvent onNextDay;
    [SerializeField] private VoidEvent onSummary;
    
    [SerializeField] private FloatVariable body;
    
    [SerializeField] private GameObject exhausted;
    [SerializeField] private GameObject rested;
    [SerializeField] private GameObject summary;
    
    
    public IEnumerator GoingToSleep()
    {
        rested.SetActive(true);
        onNextDay.Raise();
        body.SetValue(+20);
        yield return new WaitForSeconds(2);        
        rested.SetActive(false);
        onSummary.Raise();
        summary.SetActive(true);
        yield return new WaitForSeconds(6);
        summary.SetActive(false);
    }

    public void StartExhaustion()
    {
        StartCoroutine(Exhausted());
    }
    
    private IEnumerator Exhausted()
    {
        exhausted.SetActive(true);
        onNextDay.Raise();
        yield return new WaitForSeconds(2);
        exhausted.SetActive(false);
        summary.SetActive(true);
        yield return new WaitForSeconds(6);
        summary.SetActive(false);
    }
}