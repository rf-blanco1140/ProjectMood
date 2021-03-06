using Unity.Mathematics;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private Color morningColor;
    [SerializeField] private Color dayColor;
    [SerializeField] private Color nightColor;
    
    [SerializeField] private FloatVariable elapsedTime;
    [SerializeField] private BoolVariable nightTime;
    [SerializeField] private BoolVariable pauseRotation;
    
    [SerializeField] private float _timeInSeconds;
    private float _timeDividedByDegrees = 0.5f;

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
        if(pauseRotation) return;
        elapsedTime.Value += Time.deltaTime;
        //_timeDividedByDegrees = 90 / _timeInSeconds;

        if (!nightTime.boolValue)
        {
            Morning();
        }
        else
        {
            Night();
        }
    }
    
    private void Morning()
    {
        ColorBlend(morningColor, dayColor);
        RotateLightSource(_middleRotation);
    }

    private void Night()
    {
        ColorBlend(dayColor,nightColor);
        RotateLightSource(_endRotation);
    }
    
    private void ColorBlend(Color colorA, Color colorB)
    {
        light.color = Color.Lerp(colorA, colorB, elapsedTime.Value / _timeInSeconds);
    }
    
    private void RotateLightSource(Quaternion eulerDegree) 
    {
        if (_timeDividedByDegrees <= elapsedTime.Value) // broken
        {
            transform.rotation = Quaternion.RotateTowards
                (transform.rotation, eulerDegree,_timeDividedByDegrees * Time.deltaTime);
        }
    }

    public void ResetRotation()
    {
        transform.rotation = _startRotation;
        light.color = morningColor;
    }
}