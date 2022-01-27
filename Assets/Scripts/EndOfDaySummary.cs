using System;
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
    
    [Header("General Mood"), Tooltip("E.G: Today was ...")]
    [SerializeField] private string[] generalMoodString;
    
    [Header("Body")]
    [SerializeField] private string[] bodyString;
    [SerializeField, 
     Tooltip("should be able to follow (but not include) \"but\" " + "E.G: \"but\" I got some exercise done")] 
    private string[] badBodyString;
    
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
        /*if (Input.GetKeyDown(KeyCode.T))
        {
            //DisplayText();
            SystemTest();
            CalculateAverageMood();
            Debug.Log(_overAllMood);
        }*/
    }

    private void SystemTest()
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
    }

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
    
    private void BadMood()
    {
        textObject.GetComponent<Text>().text =
            $"{generalMoodString}" +
            $"\n I feel like I'm going to break down if I don't work on {body.name}{appetite.name}{mind.name}" +
            $"\n {PickFiller(mind, hygiene)} {hygiene.name}" + // lowest to best stats
            $"\n Hopefully tomorrow is better..";
    }
    private void OkayMood()
    {
    }
    private void GoodMood()
    {
    }
    private void PerfectMood()
    {
        //textObject.GetComponent<Text>().text =
            //$"Dear diary." +
            //$" \n Today was { /* general mood */} { /*lowest stat*/}. " +
            //$"\n I cut my bonsai { /*amount of times*/}." +
            //$"\n I ate { /*amount of times*/}." +
            //$"\n I { /*took / didn't take*/} a shower" +
            //$"\n I { /*did call someone / didn't call someone*/}" +
            //$"\n It was a { /*good day / okay day / bad day*/}!" +
            //$"\n Although,"; // if it was okay / bad?
    }

    private void ChooseString(FloatVariable mood ,string moodString)
    {
        if (mood.Value >= 50)
        {
            
        }
    }
    
    private void CalculateAverageMood()
    {
        _overAllMood = (body.Value + appetite.Value + hygiene.Value + mind.Value + social.Value) / 5;
    }

    private string PickFiller(FloatVariable a, FloatVariable b)
    {
        if (a.Value <= b.Value && b.Value >= 50)
        {
            return "but at least";
        }
        if (a.Value >= b.Value && b.Value <= 49)
        {
            return "but";
        }
        if (Math.Abs(a.Value - b.Value) < 2f)
        {
            return "and";
        }

        return null;
    }
}