using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject minigameCameraObject;
    [SerializeField] private Camera camMain;
    [SerializeField] private Camera camMiniGame;
    [SerializeField] private AudioListener audioMain;
    [SerializeField] private AudioListener audioMiniGame;

    private void Start()
    {
        if(minigameCameraObject)
            minigameCameraObject.SetActive(true);
        camMain.enabled = true;
        camMiniGame.enabled = false;
        audioMain.enabled = true;
        audioMiniGame.enabled = false;
    }

    public void SwapCamera()
    {
        camMain.enabled = !camMain.enabled;
        camMiniGame.enabled = !camMiniGame.enabled;
        audioMain.enabled = !audioMain.enabled;
        audioMiniGame.enabled = !audioMiniGame.enabled;
    }

}
