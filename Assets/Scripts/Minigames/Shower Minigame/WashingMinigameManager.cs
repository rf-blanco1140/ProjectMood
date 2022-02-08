using System;
using UnityEngine;
using MoreMountains.Feedbacks;

public class WashingMinigameManager : MonoBehaviour
{
    [SerializeField] private Transform[] dirt;
    [SerializeField] private Material dirtMaterial;
    [SerializeField] private VoidEvent _onWinGame;
    [SerializeField] private FloatVariable hygiene;
    [SerializeField] private MMFeedbacks _finishedSFX;
    private int _totalDirtTransparency = 0;
    private void OnEnable()
    {
        _totalDirtTransparency = 0;
        for (int i = 0; i < dirt.Length; i++)
        {
            dirt[i].GetComponent<Renderer>().material = dirtMaterial;
        }
        Debug.Log(dirt.Length);
    }

    private void Update()
    {
        Debug.Log(_totalDirtTransparency);
    }

    private void OnFinish()
    {
        _finishedSFX.PlayFeedbacks();
        AudioManager.instance.ReturnToDefault();
        hygiene.ApplyChange(20);
        _onWinGame.Raise();
        transform.parent.gameObject.SetActive(false);
    }

    public void GetAverageTransparency()
    {
        _totalDirtTransparency += 1;
        
        if (_totalDirtTransparency >= dirt.Length)
        {
            OnFinish();
        }
    }
}