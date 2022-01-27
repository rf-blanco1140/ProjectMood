using System;
using UnityEngine;

public class MoodSystem : MonoBehaviour
{
    [SerializeField] private FloatVariable mind;
    [SerializeField] private FloatVariable social;
    [SerializeField] private FloatVariable hygiene;
    [SerializeField] private FloatVariable body;
    [SerializeField] private FloatVariable appetite;
    
    [SerializeField] private float _dropValue = 7.5f;
    [SerializeField] private float _startValue = 100f;

    [SerializeField] private MoodSystemUI moodSystemUI;

    private float _overAllMood = 0;
    private int current = 0;
    
    private enum MoodEnum
    {
        Sad = 1,
        Normal = 2,
        Happy = 3
    }

    private MoodEnum currentMood = MoodEnum.Normal;
    
    private void CalculateAverageMood()
    {
        _overAllMood = (body.Value + appetite.Value + hygiene.Value + mind.Value + social.Value) / 5;

        if (_overAllMood >= 75f && currentMood != MoodEnum.Happy)
        {
            currentMood = MoodEnum.Happy;
            // void event raise
            // change light / audio / whatever
        }
        else if (_overAllMood <= 25f && currentMood != MoodEnum.Sad)
        {
            currentMood = MoodEnum.Sad;
        }
        
        else if (currentMood != MoodEnum.Normal)
        {
            currentMood = MoodEnum.Normal;
        } 
    }


    private void Start()
    {
        mind.SetValue(_startValue);
        social.SetValue(_startValue);
        hygiene.SetValue(_startValue);
        body.SetValue(_startValue);
        appetite.SetValue(_startValue);
        moodSystemUI.DisplayUI();
    }

    // drop over time
    public void DropResources()
    {
        mind.Value -= _dropValue;
        social.Value -= _dropValue;
        hygiene.Value -= _dropValue;
        body.Value -= _dropValue;
        appetite.Value -= _dropValue;
    }
}