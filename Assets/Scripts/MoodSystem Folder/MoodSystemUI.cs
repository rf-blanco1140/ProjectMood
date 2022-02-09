using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;


public class MoodSystemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bodyText;
    [SerializeField] private TextMeshProUGUI mindText;
    [SerializeField] private TextMeshProUGUI appetiteText;
    [SerializeField] private TextMeshProUGUI hygieneText;
    [SerializeField] private TextMeshProUGUI socialText;

    [SerializeField] private Image bodyIcon;
    [SerializeField] private Image mindIcon;
    [SerializeField] private Image appetiteIcon;
    [SerializeField] private Image hygieneIcon;
    [SerializeField] private Image socialIcon;

    [SerializeField] private FloatVariable body;
    [SerializeField] private FloatVariable mind;
    [SerializeField] private FloatVariable appetite;
    [SerializeField] private FloatVariable hygiene;
    [SerializeField] private FloatVariable social;

    private float uiAnimationTime;
    private float elapsedTime;
    private TextMeshProUGUI updatedText;
    private Image updatedIcon;
    private bool uiAnimationPlaying;
    private bool finishedGrowing;

    private void Start()
    {
        uiAnimationTime = 0.4f;
        elapsedTime = 0;
    }

    private void OnEnable()
    {
        DisplayUI();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            uiAnimationPlaying = true;
        }
        if (uiAnimationPlaying && !finishedGrowing)
        {
            elapsedTime += Time.deltaTime;
            float percentageCOmplete = elapsedTime / uiAnimationTime;

            updatedIcon.gameObject.transform.localScale = Vector3.Lerp(new Vector3(1,1,1), new Vector3(1.3f, 1.3f, 1.3f),percentageCOmplete);
            updatedIcon.color = Color.green;
            updatedText.color = Color.green;
            //bodyIcon.gameObject.transform.localScale = Vector3.Lerp(new Vector3(1, 1, 1), new Vector3(1.3f, 1.3f, 1.3f), percentageCOmplete);
            if(elapsedTime >= uiAnimationTime)
            {
                finishedGrowing = true;
                elapsedTime = 0;
            }
        }
        if(uiAnimationPlaying && finishedGrowing)
        {
            elapsedTime += Time.deltaTime;
            float percentageCOmplete = elapsedTime / uiAnimationTime;
            updatedIcon.gameObject.transform.localScale = Vector3.Lerp(new Vector3(1.3f, 1.3f, 1.3f), new Vector3(1, 1, 1), percentageCOmplete);
            if (elapsedTime >= uiAnimationTime)
            {
                finishedGrowing = false;
                elapsedTime = 0;
                uiAnimationPlaying = false;
                updatedIcon.color = Color.white;
                updatedText.color = Color.white;
            }
        }
    }

    public void DisplayUI()
    {
        bodyText.text = body.Value.ToString();
        mindText.text = mind.Value.ToString();
        appetiteText.text = appetite.Value.ToString();
        hygieneText.text = hygiene.Value.ToString();
        socialText.text = social.Value.ToString();
    }

    public void PlayIncreaseStatFeedback(Stats pStat)
    {
        switch(pStat)
        {
            case Stats.Body:
                updatedText = bodyText;
                updatedIcon = bodyIcon;
                break;
            case Stats.Mind:
                updatedText = mindText;
                updatedIcon = mindIcon;
                break;
            case Stats.Appetite:
                updatedText = appetiteText;
                updatedIcon = appetiteIcon;
                break;
            case Stats.Hygiene:
                updatedText = hygieneText;
                updatedIcon = hygieneIcon;
                break;
            case Stats.Social:
                updatedText = socialText;
                updatedIcon = socialIcon;
                break;
        }
        uiAnimationPlaying = true;
    }
}