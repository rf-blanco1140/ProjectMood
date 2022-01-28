using UnityEngine;
using MoreMountains.Feedbacks;
public class SleepTrigger : MonoBehaviour
{
    [SerializeField] private GameObject textObject;
    [SerializeField] private MMFeedbacks _endSound;

   private void OnTriggerStay(Collider other)
    {
        textObject.SetActive(true);
        if(TryGetComponent(out Sleep sleep) && Input.GetKeyDown(KeyCode.F))
        {
            _endSound.PlayFeedbacks();
            StartCoroutine(sleep.GoingToSleep());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textObject.SetActive(false);
    }
}