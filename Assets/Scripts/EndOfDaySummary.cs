using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EndOfDaySummary : MonoBehaviour
{
    [SerializeField] private FloatVariable body;
    [SerializeField] private FloatVariable mind;
    [SerializeField] private FloatVariable appetite;
    [SerializeField] private FloatVariable hygiene;
    [SerializeField] private FloatVariable social;

    [Header("Body")]
    [SerializeField] private string[] bodyString;
    [SerializeField] private string[] badBodyString;
    
    [Header("Mind")]
    [SerializeField] private string[] mindString;
    [SerializeField] private string[] badMindString;
    
    [Header("Appetite")]
    [SerializeField] private string[] appetiteString;
    [SerializeField] private string[] badAppetiteString;
    
    [Header("Hygiene")]
    [SerializeField] private string[] hygieneString;
    [SerializeField] private string[] badHygieneString;
    
    [Header("Social")]
    [SerializeField] private string[] socialString;
    [SerializeField] private string[] badSocialString;

    [SerializeField] private GameObject textObject;
    private float _overAllMood;

    private List<FloatVariable> moodList = new List<FloatVariable>();
    private List<int> intValues = new List<int>();

    public void DisplayText()
    {
        CalculateAverageMood();
        
        if (_overAllMood >= 90)
        {
            PerfectMood();
        }
        if (_overAllMood >= 50 && _overAllMood <= 89)
        {
            GoodMood();
        }
        if (_overAllMood >= 25 && _overAllMood <= 49)
        {
            OkayMood();
        }
        if (_overAllMood <= 24)
        {
            BadMood();
        }
    }

    #region Moods
    
    private void BadMood() 
    {
        textObject.GetComponent<Text>().text =
            $"Today was horrible!" +
            $"\n I feel like I'm going to break down if I don't work on " +
            $"{GetLowestMoods(1)} {GetLowestMoods(2)} {GetLowestMoods(3)}" +
            $"\n Hopefully tomorrow is better..";
    }
    
    private void OkayMood()
    {
        textObject.GetComponent<Text>().text =
            $"Dear diary." +
            $"\nToday felt so-so" +
            $"\n{ChooseBadOrGoodString(body, bodyString, badBodyString)} {PickFiller(body, hygiene)}" +
            $" {ChooseBadOrGoodString(hygiene, hygieneString, badHygieneString)}" +
            $"\n{ChooseBadOrGoodString(appetite, appetiteString, badAppetiteString)}" +
            $"\n{ChooseBadOrGoodString(mind, mindString, badMindString)} {PickFiller(mind, social)}" +
            $" {ChooseBadOrGoodString(social, socialString, badSocialString)}" +
            $"\nI hope that tomorrow is better";
    }
    
    private void GoodMood()
    {
        textObject.GetComponent<Text>().text =
            $"Dear diary." +
            $"\nToday was great!" +
            $"\n{ChooseBadOrGoodString(body, bodyString, badBodyString)} {PickFiller(body, hygiene)}" +
            $" {ChooseBadOrGoodString(hygiene, hygieneString, badHygieneString)}" +
            $"\n{ChooseBadOrGoodString(appetite, appetiteString, badAppetiteString)}" +
            $"\n{ChooseBadOrGoodString(mind, mindString, badMindString)} {PickFiller(mind, social)}" +
            $" {ChooseBadOrGoodString(social, socialString, badSocialString)}" +
            $"\nI Can't wait for tomorrow!";
    }
    
    private void PerfectMood()
    {
        textObject.GetComponent<Text>().text =
            $"Dear diary." +
            $"\nToday was perfect!" +
            $"\nI can't think of a single bad thing that happened today!";
    }
    
    #endregion


    #region Conversion and sorting
    
    private void ConvertListToIntValues()
    {
        foreach (var mood in moodList)    
        {
            intValues.Add((int)mood.Value);
        }
    }
    
    private void Sort(List<int> _list)
    {
        int _minIndex = 0;
        for (int i = 0; i < moodList.Count - 1; i++)
        {
            _minIndex = i;
            
            for (int j = i + 1; j < moodList.Count; j++)
            {
                if (_list[j] < _list[_minIndex])
                {
                    _minIndex = j;
                }
            }

            (moodList[_minIndex], moodList[i]) = (moodList[i], moodList[_minIndex]);
            (_list[_minIndex], _list[i]) = (_list[i], _list[_minIndex]);
        }
    }

    private void ConvertIntValuesToList()
    {
        int i = 0;
        foreach (var mood in moodList)
        {
            mood.Value = intValues[i];
            i++;
            Debug.Log(mood.Value);
        }
    }
    
    #endregion
    
    private string GetLowestMoods(int test)
    {
        ConvertListToIntValues();
        Sort(intValues);
        ConvertIntValuesToList();

        string returnString = null;
        
        switch (test)
        {
            case 1:
                returnString = moodList[0].name;
                break;
            case 2:
                returnString = moodList[1].name;
                break;
            case 3:
                returnString = moodList[2].name;
                break;
        }
        return returnString;
    }

    private string ChooseBadOrGoodString(FloatVariable mood, string[] goodString, string[] badString)
    {
        if (mood.Value >= 50)
        {
            return goodString[Random.Range(0, goodString.Length)];
        }

        return badString[Random.Range(0, badString.Length)];
    }
    
    private void CalculateAverageMood()
    {
        _overAllMood = (body.Value + appetite.Value + hygiene.Value + mind.Value + social.Value) / 5;
    }

    private string PickFiller(FloatVariable a, FloatVariable b)
    {
        if (a.Value < b.Value && b.Value >= 50)
        {
            return "but at least";
        }
        else if (a.Value > b.Value && b.Value <= 49)
        {
            return "but";
        }
        
        return "and";
    }
}