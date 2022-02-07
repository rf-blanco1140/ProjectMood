using TMPro;
using UnityEngine;

public class MoodSystemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bodyText;
    [SerializeField] private TextMeshProUGUI mindText;
    [SerializeField] private TextMeshProUGUI appetiteText;
    [SerializeField] private TextMeshProUGUI hygieneText;
    [SerializeField] private TextMeshProUGUI socialText;

    [SerializeField] private FloatVariable body;
    [SerializeField] private FloatVariable mind;
    [SerializeField] private FloatVariable appetite;
    [SerializeField] private FloatVariable hygiene;
    [SerializeField] private FloatVariable social;

    private void OnEnable()
    {
        DisplayUI();
    }

    public void DisplayUI()
    {
        bodyText.text = body.Value.ToString();
        mindText.text = mind.Value.ToString();
        appetiteText.text = appetite.Value.ToString();
        hygieneText.text = hygiene.Value.ToString();
        socialText.text = social.Value.ToString();
    }

}