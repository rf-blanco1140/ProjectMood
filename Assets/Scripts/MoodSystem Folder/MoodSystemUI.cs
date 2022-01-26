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
    
    private void Start()
    {
        DisplayUI();
    }

    public void DisplayUI()
    {
        bodyText.text = "Body: " + body.Value.ToString();
        mindText.text = "Mind: " + mind.Value.ToString();
        appetiteText.text = "Appetite: " + appetite.Value.ToString();
        hygieneText.text = "Hygiene: " + hygiene.Value.ToString();
        socialText.text = "Social: " + social.Value.ToString();
    }
}