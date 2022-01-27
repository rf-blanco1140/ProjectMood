using System.Collections;
using UnityEngine;

public class Sleep : MonoBehaviour
{
    [SerializeField] private VoidEvent onNextDay;
    [SerializeField] private FloatVariable body;
    [SerializeField] private GameObject exhausted;
    [SerializeField] private GameObject rested;
    

    private IEnumerator GoingToSleep()
    {
        rested.SetActive(true);
        onNextDay.Raise();
        body.SetValue(+20);
        yield return new WaitForSeconds(2);
        rested.SetActive(false);
    }

    private IEnumerator Exhausted()
    {
        exhausted.SetActive(true);
        onNextDay.Raise();
        yield return new WaitForSeconds(2);
        exhausted.SetActive(false);
    }
}
