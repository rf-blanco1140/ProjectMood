using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using MoreMountains;
using MoreMountains.Feedbacks;

public class MinigameStartAndStop : MonoBehaviour
{
    public GameObject _cameraManager;
    [SerializeField] private GameObject _Player;
    


    private void OnEnable()
    {
        
        Debug.Log("MiniGame Time!");
        _cameraManager.GetComponent<CameraManager>().SwapCamera();
        _Player.GetComponent<PlayerMovement>().enabled = false;
    }

    private void OnDisable()
    {
        if (_cameraManager != null)
            _cameraManager.GetComponent<CameraManager>().SwapCamera();
        _Player.GetComponent<PlayerMovement>().enabled = true;
    }
}

