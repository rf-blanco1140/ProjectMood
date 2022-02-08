using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private List<Camera> _minigameCameras;
    [SerializeField] private Camera camMain;

    [SerializeField] private AudioListener audioMain;

    private void Start()
    {
        camMain.enabled = true;
        foreach(Camera cam in _minigameCameras)
        {
            cam.enabled = false;
        }

        audioMain.enabled = true;
    }

    public void SwapToMinigameCamera(int cameraIndex)
    {
        camMain.enabled = false;
        _minigameCameras[cameraIndex].enabled = true;
    }

    public void SwapToMainCamera(int cameraIndex)
    {
        _minigameCameras[cameraIndex].enabled = false;
        camMain.enabled = true;
    }
}
