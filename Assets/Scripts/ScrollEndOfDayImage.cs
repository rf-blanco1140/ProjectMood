using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ScrollEndOfDayImage : MonoBehaviour
{
    [SerializeField] private Text textUI;
    
    private Vector3 _finalPosition = new Vector3(0, -10.8f, 0);
    private Color _startColor;
    private Color _endColor;
    private float _lerpTime;
    private float _colorLerpTime;
    private bool _startUI;

    private void Awake()
    {
        _startColor = new Color(0, 0, 0, 0);
        _endColor = new Color(1, 1, 1, 1);
        textUI.color = _startColor;
    }

    private void Update()
    {
        if(_startUI)
        {
            _lerpTime = Time.deltaTime / 5;
            _colorLerpTime += Time.deltaTime / 10;

            transform.position = Vector3.Lerp(transform.position, _finalPosition, _lerpTime);
            textUI.color = Color.Lerp(_startColor, _endColor, _colorLerpTime);
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            _startUI = true;
            _lerpTime = 0;
            _colorLerpTime = 0;
        }
    }
}
