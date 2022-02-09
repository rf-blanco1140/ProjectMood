using UnityEngine;

public class HideClock : MonoBehaviour
{
    [SerializeField] private GameObject _clock;
    [SerializeField] private GameObject _moodPanels;
    private bool _toggle;
    
    public void ToggleUI()
    {
        _toggle = !_toggle;
        _moodPanels.SetActive(!_toggle);
        _clock.SetActive(!_toggle);
    }
}