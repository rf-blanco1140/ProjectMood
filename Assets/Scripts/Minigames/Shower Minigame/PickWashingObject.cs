using System;
using UnityEngine;

public class PickWashingObject : MonoBehaviour
{
    [SerializeField] private GameObject soap;
    [SerializeField] private GameObject powerWash;
    
    private AudioSource audioSource;

    private bool _active;
    private Vector3 soapStartPosition;
    private Vector3 washerStartPosition;

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();

        soapStartPosition = soap.transform.position;
        washerStartPosition = powerWash.transform.position;
        soap.SetActive(false);
        powerWash.SetActive(false);
    }

    public void UseSoap()
    {
        soap.transform.position = soapStartPosition;
        audioSource.Stop();
        soap.SetActive(true);
        powerWash.SetActive(false);
    }
    
    public void UsePowerWash()
    {
        powerWash.transform.position = washerStartPosition;
        audioSource.Play();
        powerWash.SetActive(true);
        soap.SetActive(false);
    }
}