using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class MinigameStartAndStop : MonoBehaviour
{
    public GameObject _cameraManager;
    [SerializeField] private GameObject _PlayerBody;

    private void OnEnable()
    {
        Debug.Log("MiniGame Time!");
        _cameraManager.GetComponent<CameraManager>().SwapCamera();
        _PlayerBody.GetComponent<PlayerMovement>().enabled = false;
    }

    private void OnDisable()
    {
        if (_cameraManager != null)
            _cameraManager.GetComponent<CameraManager>().SwapCamera();
        _PlayerBody.GetComponent<PlayerMovement>().enabled = true;
    }
}

