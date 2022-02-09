using UnityEngine;

public class MinigameStartAndStop : MonoBehaviour
{
    public GameObject _cameraManager;
    public MoodSystem _moodManager;
    [SerializeField] private BoolVariable _canWalk;
    [SerializeField] private BoolVariable bufferNextDay;
    
    [SerializeField] private VoidEvent OnToggleUI;
    
    [SerializeField] private int _cameraIndex;

    private void OnEnable()
    {
        OnToggleUI.Raise();
        _canWalk.boolValue = false;
        bufferNextDay.boolValue = true;
        _moodManager.DisableMoodUI();
        _cameraManager.GetComponent<CameraManager>().SwapToMinigameCamera(_cameraIndex);
    }

    private void OnDisable()
    {
        OnToggleUI.Raise();
        _canWalk.boolValue = true;
        bufferNextDay.boolValue = false;
        _moodManager.EnableMoodUI();
        if (_cameraManager != null)
            _cameraManager.GetComponent<CameraManager>().SwapToMainCamera(_cameraIndex);
    }
}