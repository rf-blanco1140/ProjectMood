using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains;
using MoreMountains.Feedbacks;

public class FadeManager : MonoBehaviour
{

    [SerializeField] private MMFeedbacks fadeOut;
    [SerializeField] private MMFeedbacks fadeIn;
    // Start is called before the first frame update
    private void Start()
    {
        fadeOut.PlayFeedbacks();
    }

    public void FadeIn()
    {
        fadeIn.PlayFeedbacks();
    }
    
    public void FadeOut()
    {
        fadeOut.PlayFeedbacks();
    }
}
