using System;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameTrigger : MonoBehaviour
{
    [SerializeField] private GameObject textGameObject;
    [SerializeField] private String _sceneName;
    private bool _playingMiniGame = false;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement playerMovement))
        {
            textGameObject.SetActive(true);
        
            if (Input.GetKeyDown(KeyCode.F) && !_playingMiniGame) // player action ?
            {
                LoadSceneAdditive();
                playerMovement.enabled = false; // SO ?
                _playingMiniGame = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textGameObject.SetActive(false);
    }

    private void LoadSceneAdditive()
    {
        SceneManager.LoadScene(_sceneName, LoadSceneMode.Additive);
    }
}
