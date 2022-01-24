using System;
using UnityEngine;

public class ActionEventSystem : MonoBehaviour
{
    public static ActionEventSystem current;
    private void Awake()
    {
        current = this;
    }

    public event Action onDayIsOver;
    public void endDaySummaryTrigger()
    {
        if (onDayIsOver != null)
        {
            onDayIsOver();
        }
    }
}
