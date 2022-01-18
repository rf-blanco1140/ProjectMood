using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameQuit : MonoBehaviour
{
    public void QuitMiniGame()
    {
        // set playerMove SO to true 
        SceneManager.UnloadSceneAsync("JespersMiniGameScene");
    }
}
