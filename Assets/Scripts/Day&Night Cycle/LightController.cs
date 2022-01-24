using Unity.Mathematics;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private Color _colorA;
    [SerializeField] private Color _colorB;

    // rotate and change color deppending on rotation angle ?
    // blend the colors togehter
    // using timemanager somehow
    
    // rotate + color morning
    // rotate + color evening

    private void Update()
    {
        RotateLightSource();
        //ColorBlend();
    }
    
    private void MorningRotation()
    {
        Quaternion poopie;
        quaternion pooooooop = quaternion.Euler(190,0,0);
        poopie = Quaternion.RotateTowards(transform.rotation,pooooooop, 5 * Time.deltaTime );
        transform.rotation = poopie;
    }
    private void EveningRotation()
    {
        Quaternion poopsss = Quaternion.Euler(90, 0, 0);
        transform.rotation = poopsss;
        quaternion euh = quaternion.Euler(190,0,0);
        quaternion popiii = Quaternion.RotateTowards(transform.rotation, euh, 5 * Time.deltaTime);
        transform.rotation = popiii;
    }

    private void RotateLightSource()
    {
        //var roflmao = quaternion.Euler(180, 0, 0);
        
        transform.Rotate(.1f, 0, 0, Space.Self);
        quaternion _maxRotation = Quaternion.Euler(180,0,0);

        //transform.rotation = Vector3.Lerp(transform.rotation,_maxRotation,Time.deltaTime);
        
        if (transform.rotation == _maxRotation)
        {
            quaternion _startPos = Quaternion.Euler(0,0,0);
            transform.rotation = _startPos;
        } 
        

        // _startRotation = quaternion.Euler(0,0,0);
        //quaternion _endRotation = quaternion.Euler(190,0,0);
    }

    private void ColorBlend()
    {
        var lightie = GetComponent<Light>();
        lightie.color = Color.Lerp(_colorA, _colorB, Mathf.Pow(0,1)* Time.deltaTime); 
        //lightie.color = _colorC;
    }
}
