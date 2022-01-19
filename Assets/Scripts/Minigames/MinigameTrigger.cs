using System;
using UnityEngine;

public class MinigameTrigger : MonoBehaviour
{
    [SerializeField] GameObject CameraManager;
    [SerializeField] private GameObject textGameObject;
    [SerializeField] private GameObject MiniGame;

    private bool _canInteract = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canInteract = true;
            textGameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _canInteract = false;
        textGameObject.SetActive(false);
    }

    private void Update()
    {
        if (_canInteract && Input.GetKeyDown(KeyCode.F))
        {
            MiniGame.SetActive(true);
            _canInteract = false;
            textGameObject.SetActive(false);
        }
    }
}
