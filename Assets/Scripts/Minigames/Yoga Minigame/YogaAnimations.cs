using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class YogaAnimations : MonoBehaviour
{
    [SerializeField] private Animator controller;
    [SerializeField] private BoolVariable animationIsPlaying;
    private float timeBeforeTransition = 2f;
    private int hihi = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            hihi = 1;
            StartCoroutine(PlayYogaAnimation(hihi));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            hihi = 2;
            StartCoroutine(PlayYogaAnimation(hihi));
        }
    }

    public IEnumerator PlayYogaAnimation(int i)
    {
        animationIsPlaying.boolValue = true;
        
        controller.Play($"Armature|Yoga {i} Up");
        
        yield return new WaitForSeconds(timeBeforeTransition);
        controller.Play($"Armature|Yoga {i} Down");
        
        yield return new WaitForSeconds(timeBeforeTransition);
        animationIsPlaying.boolValue = false;
    }
}