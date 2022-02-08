using System;
using UnityEngine;

public class MoodSystem : MonoBehaviour
{
    [SerializeField] private FloatVariable mind;
    [SerializeField] private FloatVariable social;
    [SerializeField] private FloatVariable hygiene;
    [SerializeField] private FloatVariable body;
    [SerializeField] private FloatVariable appetite;
    [SerializeField] private IntEvent _onMoodChange;

    [SerializeField] private Animator _animator1, _animator2, _animator3;

    [SerializeField] private float _dropValue = -7.5f;
    [SerializeField] private float _startValue = 70f;

    [SerializeField] private GameObject moodSystemUI;

    private float _overAllMood = 0;
    private int current = 0;
    
    private enum MoodEnum
    {
        Sad = 1,
        Normal = 2,
        Happy = 3
    }

    [SerializeField] private MoodEnum currentMood;
    
    public void CalculateAverageMood()
    {
        _overAllMood = (body.Value + appetite.Value + hygiene.Value + mind.Value + social.Value) / 5;

        if (_animator1.gameObject.activeSelf)
            _animator1.SetFloat("animMood", _overAllMood);
        if (_animator2.gameObject.activeSelf)
            _animator2.SetFloat("animMood", _overAllMood);
        if (_animator3.gameObject.activeSelf)
            _animator3.SetFloat("animMood", _overAllMood);


        if (_overAllMood >= 75f && currentMood != MoodEnum.Happy)
        {
            currentMood = MoodEnum.Happy;
            _onMoodChange.Raise(3);
        }
        else if (_overAllMood <= 25f && currentMood != MoodEnum.Sad)
        {
            currentMood = MoodEnum.Sad;
            _onMoodChange.Raise(1);
        }
        
        else if (_overAllMood < 75 && _overAllMood > 25 && currentMood != MoodEnum.Normal)
        {
            currentMood = MoodEnum.Normal;
            _onMoodChange.Raise(2);
        } 
    }


    private void Start()
    {
        mind.SetValue(_startValue);
        social.SetValue(_startValue);
        hygiene.SetValue(_startValue);
        body.SetValue(_startValue);
        appetite.SetValue(_startValue);
        moodSystemUI.GetComponent<MoodSystemUI>().DisplayUI();
        CalculateAverageMood();
    }

    // drop over time
    public void DropResources()
    {
        mind.ApplyChange(_dropValue);
        social.ApplyChange(_dropValue);
        hygiene.ApplyChange(_dropValue);
        body.ApplyChange(_dropValue);
        appetite.ApplyChange(_dropValue);
        CalculateAverageMood();
    }

    public void EnableMoodUI()
    {
        moodSystemUI.gameObject.SetActive(true);
    }

    public void DisableMoodUI()
    {
        moodSystemUI.gameObject.SetActive(false);
    }

}