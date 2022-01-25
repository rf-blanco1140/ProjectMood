using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugTool : MonoBehaviour
{
    [SerializeField] private GameObject debugMenu;
    [SerializeField] private GameObject debugText;
    private bool _toggleDebug = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            _toggleDebug = !_toggleDebug;
            debugMenu.SetActive(_toggleDebug);
            debugText.SetActive(!_toggleDebug);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}