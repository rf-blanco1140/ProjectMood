using System;
using System.Collections;
using UnityEngine;
using MoreMountains.Feedbacks;


public class MinigameTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _textGameObject;
    [SerializeField] private GameObject _miniGame;
    [SerializeField] private GameObject _imageF;
    [SerializeField] private AudioClip _newTrack;
    [SerializeField] private MMFeedbacks _fadeIn;
    [SerializeField] private MMFeedbacks _fadeOut;

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
            _fadeIn.PlayFeedbacks();
            StartCoroutine(Delay());
            
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        _fadeOut.PlayFeedbacks();
        AudioManager.instance.SwapTrack(_newTrack);
        _miniGame.SetActive(true);
        _canInteract = false;
        _textGameObject.SetActive(false);
        _imageF.SetActive(false);
    }
}
