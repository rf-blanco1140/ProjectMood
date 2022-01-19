using System;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Minigames__Scene_based_
{
    public class MiniGameTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject textGameObject;
        [SerializeField] private String _sceneName;
        [SerializeField] private BoolVariable minigameIsRunning;
        [SerializeField] private PlayerMovement player;
        
        private void Awake()
        {
            player.GetComponent<PlayerMovement>();
            minigameIsRunning.SetInactive();
        }

        private void OnTriggerStay(Collider other)
        {
            if (minigameIsRunning.boolValue == true)
            {
                PlayerMovementToggle(false);
            }
            
            else if (minigameIsRunning.boolValue == false)
            {
                PlayerMovementToggle(true);
                
                textGameObject.SetActive(true);
                
                if (Input.GetKeyDown(KeyCode.F))
                {
                    minigameIsRunning.SetActive();
                    LoadSceneAdditive();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            textGameObject.SetActive(false);
        }

        private void PlayerMovementToggle(bool canMove)
        {
            player.enabled = canMove;
        }

        private void LoadSceneAdditive()
        {
            SceneManager.LoadScene(_sceneName, LoadSceneMode.Additive);
        }
    }
}
