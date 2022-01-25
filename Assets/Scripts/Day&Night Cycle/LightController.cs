using Unity.Mathematics;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private Color _colorA;
    [SerializeField] private Color _colorB;
    [SerializeField] private Light light;
    
    [SerializeField][Range(0,10)] private float _timer;
    private float t;

    private void Update()
    {
        //RotateLightSource();
        ColorBlend();
    }

    private Quaternion RotateLightSource() 
    {
        quaternion _middleRotation = quaternion.Euler(90,0,0);
        quaternion _endRotation = quaternion.Euler(190,0,0);

        
        return transform.rotation = Quaternion.RotateTowards(transform.rotation, _middleRotation,_timer * Time.deltaTime);
    }

    private void ColorBlend()
    {
        //var lightie = GetComponent<Light>();
        t = Time.deltaTime / 2f;
        light.color = Color.Lerp(_colorA, _colorB, Time.deltaTime / 5f);
    }
}
