using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private Color morningColor;
    [SerializeField] private Color dayColor;
    [SerializeField] private Color nightColor;
    
    private float _timeDividedByDegrees = 9;
    [SerializeField] private float _timeInSeconds = 10f;
    private float _elapsedTime;

    [SerializeField] private bool _morningNight = true;
    
    private quaternion _startRotation = quaternion.Euler(0,0,0);
    private quaternion _middleRotation = quaternion.Euler(90,0,0);
    private quaternion _endRotation = quaternion.Euler(180,0,0);
    
    private Light light;

    private void Awake()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        //Debug.Log(_elapsedTime);
        //RotateLightSource();
        //ColorBlend();
        if (_morningNight)
        {
            Morning();
        }
        else
        {
            Night();
        }
        //SuperRotation();
    }

    private Quaternion RotateLightSource(Quaternion eulerDegree) // time manager dependencies..
    {
        return transform.rotation = Quaternion.RotateTowards(transform.rotation, eulerDegree,_timeDividedByDegrees * Time.deltaTime);
    }

    private void ColorBlend(Color colorA, Color colorB)
    {
        light.color = Color.Lerp(colorA, colorB, _elapsedTime / _timeInSeconds);
    }

    private void Morning()
    {
        RotateLightSource(_middleRotation);
        ColorBlend(morningColor, dayColor);
    }

    private void Night()
    {
        
        RotateLightSource(_endRotation);
        ColorBlend(dayColor,nightColor);
    }

    private void SuperRotation()
    {
        RotateLightSource(_middleRotation);
        //if (transform.rotation == _middleRotation)
        //{
        //    RotateLightSource(_endRotation);
        //}
    }
}