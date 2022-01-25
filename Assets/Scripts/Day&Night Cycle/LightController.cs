using Unity.Mathematics;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private Color morningColor;
    [SerializeField] private Color dayColor;
    [SerializeField] private Color nightColor;
    
    [SerializeField] private FloatVariable elapsedTime;
    [SerializeField] private BoolVariable nightTime;
    [SerializeField] private float _timeInSeconds = 240f;
    private float _timeDividedByDegrees = 0.75f;

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
        elapsedTime.Value += Time.deltaTime;

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
    
    private quaternion RotateLightSource(Quaternion eulerDegree) // time manager dependencies..
    {
        return transform.rotation = Quaternion.RotateTowards(transform.rotation, eulerDegree,_timeDividedByDegrees * Time.deltaTime);
    }

    private quaternion ResetRotation()
    {
        return transform.rotation = _startRotation;
    }
}