using System;
using UnityEngine;

public class Clean : MonoBehaviour
{
    [SerializeField] private Material dirty;
    [SerializeField] private Material clean;
    private Renderer renderer;
    private float duration = 0f;
    private float durationPassed = .1f;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = dirty;
    }

    private void OnTriggerEnter(Collider other)
    {
        LerpToTransparency();
    }

    private void LerpToTransparency()
    {
        renderer.material.Lerp(dirty, clean, duration);
        duration += durationPassed;
    }
}