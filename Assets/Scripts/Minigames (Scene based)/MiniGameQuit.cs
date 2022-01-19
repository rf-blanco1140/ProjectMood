using UnityEngine;
using UnityEngine.SceneManagement;

namespace Minigames__Scene_based_
{
    public class MiniGameQuit : MonoBehaviour   
    {
        [SerializeField] private BoolVariable minigameIsRunning;
        
        public void QuitMiniGame()
        {
            minigameIsRunning.SetInactive();
            SceneManager.UnloadSceneAsync("JespersMiniGameScene");
        }
    }
}

