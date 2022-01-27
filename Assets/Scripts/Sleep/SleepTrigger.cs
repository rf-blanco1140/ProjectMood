using UnityEngine;

public class SleepTrigger : MonoBehaviour
{
    [SerializeField] private GameObject textObject;
    
    private void OnTriggerStay(Collider other)
    {
        textObject.SetActive(true);
        if(TryGetComponent(out Sleep sleep) && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(sleep.GoingToSleep());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textObject.SetActive(false);
    }
}