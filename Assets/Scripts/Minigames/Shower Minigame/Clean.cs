using System;
using UnityEngine;
using MoreMountains.Feedbacks;
public class Clean : MonoBehaviour
{
    [SerializeField] private Material dirty;
    [SerializeField] private Material clean;
    [SerializeField] [Range(0f,0.5f)] private float washerPower;
    [SerializeField] [Range(0f,0.5f)] private float soapPower;
    [SerializeField] private VoidEvent onTransparent;
    [SerializeField] private MMFeedbacks soapSfx;
    [SerializeField] private GameObject bubblesParticles;

    private bool _transparent = false;
    private Renderer renderer;
    private float duration = 0f;
    private float durationPassed = 0f;

    private void OnEnable()
    {
        _transparent = false;
        renderer = GetComponent<Renderer>();
        renderer.material = dirty;
        duration = 0f;
        durationPassed = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out WaterDrop waterDrop))
        {
            durationPassed = washerPower;
        }
        else
        {
            durationPassed = soapPower;
            Instantiate(bubblesParticles, transform.position, transform.rotation);
            soapSfx.PlayFeedbacks();     
        }
        LerpToTransparency();
    }


    private void LerpToTransparency()
    {
        renderer.material.Lerp(dirty, clean, duration);
        duration += durationPassed;
        
        if (duration >= 1 && !_transparent)
        {
            _transparent = true;
            onTransparent.Raise();
        }
    }
}