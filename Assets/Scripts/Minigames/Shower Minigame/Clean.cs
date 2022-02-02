using System;
using UnityEngine;

public class Clean : MonoBehaviour
{
    [SerializeField] private Material dirty;
    [SerializeField] private Material clean;
    [SerializeField] [Range(0f,0.5f)] private float washerPower;
    [SerializeField] [Range(0f,0.5f)] private float soapPower;
    [SerializeField] private VoidEvent onTransparent;

    private bool _transparent = false;
    private Renderer renderer;
    private float duration = 0f;
    private float durationPassed = 0f;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = dirty;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out WaterDrop water))
        {
            durationPassed = washerPower;
        }
        else durationPassed = soapPower;
        
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