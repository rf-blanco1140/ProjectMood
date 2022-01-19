using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameStartAndStop : MonoBehaviour
{
    public GameObject _cameraManager;

    private void OnEnable()
    {
        Debug.Log("MiniGame Time!");
        _cameraManager.GetComponent<CameraManager>().SwapCamera();
    }

    private void OnDisable()
    {
        if (_cameraManager != null)
            _cameraManager.GetComponent<CameraManager>().SwapCamera();
    }
}

