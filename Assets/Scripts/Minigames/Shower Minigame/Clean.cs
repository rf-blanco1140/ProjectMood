using System;
using UnityEngine;

public class Clean : MonoBehaviour
{
    [SerializeField] private Material dirty;
    [SerializeField] private Material clean;
    private float duration = 2f;
    private Renderer renderer;
    float poopie = 0f;
    // lerp 2 meshes 1 inv - 1 dirty

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = dirty;
    }

    private void OnMouseDown()
    {
        CleanOnClick();
    }

    private void CleanOnClick() // poopie name
    {
        renderer.material.Lerp(dirty, clean, poopie);
        poopie += .1f;
    }
}