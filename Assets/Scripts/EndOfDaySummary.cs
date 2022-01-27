using System;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField] private string[] badAppetiteString
        ;
    [Header("Hygiene")]
    [SerializeField] private string[] hygieneString;
    [SerializeField] private string[] badHygieneString;
    
    [Header("Social")]
    [SerializeField] private string[] socialString;
    [SerializeField] private string[] badSocialString;

    [SerializeField] private GameObject textObject;
    private float _overAllMood;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            //DisplayText();
            GenericMoodDisplay();
            //CalculateAverageMood();
            //GetLowestMoods();
            //Debug.Log(_overAllMood);
        }
    }

    /*private void SystemTest()
    {
        textObject.GetComponent<Text>().text =
            $"{generalMoodString[Random.Range(0, generalMoodString.Length)]}" +
            $"\n{bodyString[Random.Range(0, bodyString.Length)]} " +
            $"{PickFiller(body,appetite)} " +
            $"{hygieneString[Random.Range(0, hygieneString.Length)]} " +
            $"\n{appetiteString[Random.Range(0, appetiteString.Length)]}" +
            $"\n{mindString[Random.Range(0, mindString.Length)]} " +
            $"{PickFiller(mind,social)} " +
            $"{socialString[Random.Range(0, socialString.Length)]}";
    }*/
    

    private void DisplayText()
    {
        CalculateAverageMood();
        
        if (_overAllMood >= 90)
        {
            BadMood();
        }
        if (_overAllMood >= 75 && _overAllMood <= 89)
        {
            OkayMood();
        }
        if (_overAllMood >= 50 && _overAllMood <= 74)
        {
            GoodMood();
        }
        if (_overAllMood <= 25)
        {
            PerfectMood();
        }
    }

    private void GenericMoodDisplay()
    {
        textObject.GetComponent<Text>().text =
            $"Dear diary." +
            $"\nToday felt ok," +
            $"\n{ChooseBadOrGoodString(body, bodyString, badBodyString)} {PickFiller(body, hygiene)}" +
            $" {ChooseBadOrGoodString(hygiene, hygieneString, badHygieneString)}" +
            $"\n{ChooseBadOrGoodString(appetite, appetiteString, badAppetiteString)}" +
            $"\n{ChooseBadOrGoodString(mind, mindString, badMindString)} {PickFiller(mind, social)}" +
            $" {ChooseBadOrGoodString(social, socialString, badSocialString)}" +
            $"\nLooking forward to tomorrow!";
    }

    private void BadMood() // done -ish
    {
        textObject.GetComponent<Text>().text =
            $"Today was horrible!" +
            $"\n I feel like I'm going to break down if I don't work on {body.name}{appetite.name}{mind.name}" +
            $"\n {PickFiller(mind, hygiene)} {hygiene.name}" + // lowest to best stats
            $"\n Hopefully tomorrow is better..";
    }
    private void OkayMood()
    {
        textObject.GetComponent<Text>().text =
            $"Today was ok" +
            $"\n I feel like I'm going to break down if I don't work on {body.name}{appetite.name}{mind.name}" +
            $"\n {PickFiller(mind, hygiene)} {hygiene.name}" + // lowest to best stats
            $"\n Hopefully tomorrow is better..";
    }
    private void GoodMood()
    {
        textObject.GetComponent<Text>().text =
            $"Today was good" +
            $"\n I feel like I'm going to break down if I don't work on {body.name}{appetite.name}{mind.name}" +
            $"\n {PickFiller(mind, hygiene)} {hygiene.name}" + // lowest to best stats
            $"\n Hopefully tomorrow is better..";
    }
    private void PerfectMood()
    {
        textObject.GetComponent<Text>().text =
            $"Today was perfect" +
            $"\n I feel like I'm going to break down if I don't work on {body.name}{appetite.name}{mind.name}" +
            $"\n {PickFiller(mind, hygiene)} {hygiene.name}" + // lowest to best stats
            $"\n Hopefully tomorrow is better..";
    }

    private void GetLowestMoods()
    {
        List<FloatVariable> moodList = new List<FloatVariable>();
        moodList.Sort();
        Debug.Log(moodList.OrderByDescending(moodList => moodList).Take(3));
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