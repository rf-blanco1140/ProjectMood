using UnityEngine;

public class EndOfDaySummary : MonoBehaviour
{
    [SerializeField] private GameObject summaryWindow;
    
    
    
    private void Start()
    {
        ActionEventSystem.current.onDayIsOver += EnableSummary;
    }

    private void EnableSummary()
    {
        //summaryWindow.SetActive(true);
        Debug.Log("event system works");
    }
}
