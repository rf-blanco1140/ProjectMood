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

        soap.transform.position = soapStartPosition;
        powerWash.transform.position = washerStartPosition;
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
    
    private Vector3 SetPosition(GameObject washObject, Vector3 targetPosition)
    {
        return washObject.transform.position = targetPosition;
    }
}