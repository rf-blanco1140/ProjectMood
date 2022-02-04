using UnityEngine;

public class PickWashingObject : MonoBehaviour
{
    [SerializeField] private GameObject soap;
    [SerializeField] private GameObject powerWash;
    
    private AudioSource audioSource;

    private bool _active;
    Vector3 soapStartPosition;
    Vector3 washerStartPosition;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        soapStartPosition = soap.transform.position;
        washerStartPosition = powerWash.transform.position;
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