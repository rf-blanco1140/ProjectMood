using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using MoreMountains;
using MoreMountains.Feedbacks;

public class MinigameStartAndStop : MonoBehaviour
{
    public GameObject _cameraManager;
    public MoodSystem _moodManager;
    [SerializeField] private BoolVariable _canWalk;

    [SerializeField] private int _cameraIndex;

    private void OnEnable()
    {
        _canWalk.boolValue = false;
        _moodManager.DisableMoodUI();
        _cameraManager.GetComponent<CameraManager>().SwapToMinigameCamera(_cameraIndex);
    }

    private void OnDisable()
    {
        _canWalk.boolValue = true;
        _moodManager.EnableMoodUI();
        if (_cameraManager != null)
            _cameraManager.GetComponent<CameraManager>().SwapToMainCamera(_cameraIndex);
    }
}

