using System.Collections;
using UnityEngine;
using MoreMountains.Feedbacks;
using TMPro;

public class SleepTrigger : MonoBehaviour
{
    [SerializeField] private GameObject textObject;
    [SerializeField] private MMFeedbacks _endSound;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private TextMeshProUGUI notTiredResponseText;
    
   private void OnTriggerStay(Collider other)
    {
        textObject.SetActive(true);
        if(TryGetComponent(out Sleep sleep) && Input.GetKeyDown(KeyCode.F))
        {
            if (timeManager._clockHours >= 19)
            {
                _endSound.PlayFeedbacks();
                StartCoroutine(sleep.Sleeping());
            }
            else
            {
                StartCoroutine(Response());
            }
        }
    }

   private IEnumerator Response()
   {
       notTiredResponseText.text = $"I don't feel tired yet..";
       yield return new WaitForSeconds(2);
       notTiredResponseText.text = $"";
   }

    private void OnTriggerExit(Collider other)
    {
        textObject.SetActive(false);
    }
}