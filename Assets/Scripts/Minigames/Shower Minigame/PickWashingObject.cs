using System;
using UnityEngine;

public class PickWashingObject : MonoBehaviour
{
    [SerializeField] private GameObject soap;
    [SerializeField] private GameObject powerWash;
    
    private AudioSource audioSource;

    private bool _active;
    private Vector3 soapStartPosition = new Vector3(-4.27f,0f,10.31f);
    private Vector3 washerStartPosition = new Vector3(2.33f, -1.34f, 5.67f);

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();

        SetPosition(soap, new Vector3(-4.27f,0f,10.31f));
        SetPosition(powerWash, new Vector3(2.33f, -1.34f, 5.67f));
    }

    public void UseSoap()
    {
        SetPosition(soap, soapStartPosition);
        audioSource.Stop();
        soap.SetActive(true);
        powerWash.SetActive(false);
    }
    
    public void UsePowerWash()
    {
        SetPosition(powerWash, washerStartPosition);
        audioSource.Play();
        powerWash.SetActive(true);
        soap.SetActive(false);
    }
    
    private Vector3 SetPosition(GameObject washObject, Vector3 targetPosition)
    {
        return washObject.transform.position = targetPosition;
    }
}