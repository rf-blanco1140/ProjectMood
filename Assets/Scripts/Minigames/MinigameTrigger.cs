using System;
using UnityEngine;

public class MinigameTrigger : MonoBehaviour
{
    [SerializeField] private GameObject textGameObject;
    [SerializeField] private GameObject MiniGame;
    [SerializeField] private GameObject imageF;
    [SerializeField] private AudioClip newTrack;
   
 
    private bool _canInteract = false;


    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canInteract = true;
            textGameObject.SetActive(true);
            imageF.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _canInteract = false;
        textGameObject.SetActive(false);
        imageF.SetActive(false);
    }

    private void Update()
    {
        if (_canInteract && Input.GetKeyDown(KeyCode.F))
        {
            AudioManager.instance.SwapTrack(newTrack);
            MiniGame.SetActive(true);
            _canInteract = false;
            textGameObject.SetActive(false);
            imageF.SetActive(false);
        }
    }
}
