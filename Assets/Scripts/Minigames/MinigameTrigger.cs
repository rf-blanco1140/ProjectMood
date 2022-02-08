using System;
using System.Collections;
using UnityEngine;
using MoreMountains.Feedbacks;


public class MinigameTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _textGameObject;
    [SerializeField] private GameObject _miniGame;
    [SerializeField] private GameObject _imageF;
    [SerializeField] private GameObject _imageStat;
    [SerializeField] private AudioClip _newTrack;
    [SerializeField] private MMFeedbacks _fadeIn;
    [SerializeField] private MMFeedbacks _fadeOut;
    [SerializeField] private MMFeedbacks _startSound;

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
            _imageStat.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _canInteract = false;
        _textGameObject.SetActive(false);
        _imageF.SetActive(false);
        _imageStat.SetActive(false);
    }

    private void Update()
    {
        if (_canInteract && Input.GetKeyDown(KeyCode.F))
        {
            _fadeIn.PlayFeedbacks();
            _startSound.PlayFeedbacks();
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
        _imageStat.SetActive(false);
    }
}
