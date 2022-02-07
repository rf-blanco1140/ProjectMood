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
    


    private void OnEnable()
    {
        
        Debug.Log("MiniGame Time!");
        _canWalk.boolValue = false;
        _moodManager.DisableMoodUI();
        _cameraManager.GetComponent<CameraManager>().SwapCamera();
    }

    private void OnDisable()
    {
        _canWalk.boolValue = true;
        _moodManager.EnableMoodUI();
        if (_cameraManager != null)
            _cameraManager.GetComponent<CameraManager>().SwapCamera();
    }
}

