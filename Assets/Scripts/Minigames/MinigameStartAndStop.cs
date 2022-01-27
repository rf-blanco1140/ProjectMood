using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using MoreMountains;
using MoreMountains.Feedbacks;

public class MinigameStartAndStop : MonoBehaviour
{
    public GameObject _cameraManager;
    [SerializeField] private BoolVariable _canWalk;
    


    private void OnEnable()
    {
        
        Debug.Log("MiniGame Time!");
        _canWalk.boolValue = false;
        _cameraManager.GetComponent<CameraManager>().SwapCamera();
    }

    private void OnDisable()
    {
        _canWalk.boolValue = true;
        if (_cameraManager != null)
            _cameraManager.GetComponent<CameraManager>().SwapCamera();
    }
}

