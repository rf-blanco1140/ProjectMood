using System;
using UnityEngine;
using MoreMountains.Feedbacks;


public class MinigameTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _textGameObject;
    [SerializeField] private GameObject _miniGame;
    [SerializeField] private GameObject _imageF;
    [SerializeField] private AudioClip _newTrack;
    [SerializeField] private MMFeedbacks fadeFeedbacks;

    private bool _canInteract = false;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            _canInteract = true;
            _textGameObject.SetActive(true);
            _imageF.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _canInteract = false;
        _textGameObject.SetActive(false);
        _imageF.SetActive(false);
    }

    private void Update()
    {
        if (_canInteract && Input.GetKeyDown(KeyCode.F))
        {
            //AudioManager.instance.SwapTrack(newTrack);
            //fadeFeedbacks.PlayFeedbacks();
            _miniGame.SetActive(true);
            _canInteract = false;
            _textGameObject.SetActive(false);
            _imageF.SetActive(false);
        }
    }
}
