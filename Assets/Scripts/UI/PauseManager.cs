using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{

    PlayerInputs action;
    public GameObject pauseMenu;
    public GameObject pauseButtons;
    public GameObject saveMenu;
    public GameObject optionsMenu;
    public GameObject lineImg;
    bool paused;
    // Start is called before the first frame update
    void Start()
    {
        
        action.Player.Pause.performed += _ => DeterminePause();
    }
    private void Awake()
    {
        action = new PlayerInputs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeterminePause()
    {
        if (paused)
            ResumeGame();
        else
            PauseGame();

    }
    private void OnEnable()
    {
        action.Enable();
    }
    private void OnDisable()
    {
        action.Disable();
    }
    public void PauseGame()
    {
        AudioListener.pause = true;
        Time.timeScale = 0;
        paused = true;
        pauseMenu.SetActive(true);
        pauseButtons.SetActive(true);
        lineImg.SetActive(true);
    }
    public void ResumeGame()
    {
        AudioListener.pause = false;
        pauseMenu.SetActive(false);
        saveMenu.SetActive(false);
        optionsMenu.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
